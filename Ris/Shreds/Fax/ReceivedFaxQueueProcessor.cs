#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.IO;
using ClearCanvas.Common;
using ClearCanvas.Common.Shreds;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare.Fax;
using ClearCanvas.Healthcare.Fax.Brokers;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Shreds.Fax
{
	internal class FaxFileSet
	{
		private Dictionary<string, string> _metaData;

		public FaxFileSet(string metaDataFile, string imageDataFile)
		{
			MetaDataFile = metaDataFile;
			ImageDataFile = imageDataFile;
		}

		#region Public Properties

		public string MetaDataFile { get; private set; }

		public string ImageDataFile { get; private set; }

		public bool HasMetaData
		{
			get { return _metaData == null ? false : _metaData.Count > 0; }
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Load meta data from the the file into a dictionary.
		/// </summary>
		/// <param name="metaDataDelimiters"></param>
		/// <remarks>This initialization must be called before all other public methods.</remarks>
		public void InitializeMetaData(string metaDataDelimiters)
		{
			_metaData = new Dictionary<string, string>();

			var lines = File.ReadAllLines(this.MetaDataFile);
			if (lines.Length == 0)
				return;

			foreach (var line in lines)
			{
				var trimmedLine = line.Trim();
				if (string.IsNullOrEmpty(trimmedLine))
					continue;

				var parts = trimmedLine.Split(metaDataDelimiters.ToCharArray());
				if (parts.Length == 2)
				{
					// Parsed exactly 2 parts, first one is field name, second is field value
					_metaData[parts[0].Trim()] = parts[1].Trim();
				}
				else if (parts.Length > 2)
				{
					// Parsed more than 2 parts, take the first as field name, the remainder as field value
					_metaData[parts[0].Trim()] = trimmedLine.Substring(trimmedLine.IndexOf(metaDataDelimiters) + 1);
				}
			}
		}

		/// <summary>
		/// Gets the value of a meta data field.  Convert the value to the speicfied type, or null if the operation fails.
		/// </summary>
		/// <param name="field"></param>
		/// <returns>Returns parsed field value of type inputted, or null if the operation fails.</returns>
		public TypeOfField GetMetadataProperty<TypeOfField>(string field)
		{
			if (!_metaData.ContainsKey(field) || string.IsNullOrEmpty(_metaData[field]))
				return default(TypeOfField);

			return (TypeOfField)Convert.ChangeType(_metaData[field], typeof(TypeOfField));
		}

		/// <summary>
		/// Deletes the files within this fileset.
		/// </summary>
		public void DeleteFiles()
		{
			File.Delete(this.MetaDataFile);
			File.Delete(this.ImageDataFile);

			this.MetaDataFile = null;
			this.ImageDataFile = null;

			_metaData = null;
		}

		/// <summary>
		/// Move files to another directory.
		/// </summary>
		public void MoveToFolder(string newFolder)
		{
			var newMetaDataFile = Path.Combine(newFolder, Path.GetFileName(this.MetaDataFile));
			var newImageDataFile = Path.Combine(newFolder, Path.GetFileName(this.ImageDataFile));

			if (File.Exists(newMetaDataFile))
				File.Delete(this.MetaDataFile);
			else
				File.Move(this.MetaDataFile, newMetaDataFile);

			if (File.Exists(newImageDataFile))
				File.Delete(this.ImageDataFile);
			else
				File.Move(this.ImageDataFile, newImageDataFile);

			this.MetaDataFile = newMetaDataFile;
			this.ImageDataFile = newImageDataFile;
		}

		#endregion
	}

	internal class ReceivedFaxQueueProcessor : QueueProcessor<FaxFileSet>
	{
		private readonly ReceivedFaxQueueProcessorSettings _settings;

		public ReceivedFaxQueueProcessor(ReceivedFaxQueueProcessorSettings settings)
			: base(settings.BatchSize, TimeSpan.FromSeconds(settings.SleepTime))
		{
			_settings = settings;

			// Only start the processor if the incoming and error directories are validated.
			ValidateDirectoryWriteAccess(settings.IncomingFaxDirectory);
			ValidateDirectoryWriteAccess(settings.ErrorFaxDirectory);
		}

		/// <summary>
		/// Retrieves new incoming fax file groups from the incoming folder.
		/// Any metadata file without a corresponding image data file are ignored.
		/// </summary>
		/// <param name="batchSize"></param>
		/// <returns>A list of FaxFileSet.</returns>
		protected override IList<FaxFileSet> GetNextBatch(int batchSize)
		{
			var faxFileSets = new List<FaxFileSet>();

			// Search for all metadata files in the incoming directory.
			var metaDataFileSearchPattern = string.Format("*.{0}", _settings.MetaDataFileExtension);
			var metadataFileNames = Directory.GetFiles(_settings.IncomingFaxDirectory, metaDataFileSearchPattern);

			foreach (var metadataFileName in metadataFileNames)
			{
				if (faxFileSets.Count == batchSize) 
					break;

				// An image files has identical name as its corresponding metadata file but with different file extension.
				var fileDirectory = Path.GetDirectoryName(metadataFileName);
				var imageFileName = Path.Combine(
					fileDirectory, 
					string.Format("{0}.{1}", Path.GetFileNameWithoutExtension(metadataFileName) , _settings.ImageDataFileExtension));

				// Skip any metadata file that does not have an image file.  Perhaps the image file has not arrived yet.
				if (!File.Exists(imageFileName)) 
					continue;

				var set = new FaxFileSet(metadataFileName, imageFileName);
				faxFileSets.Add(set);
			}

			return faxFileSets;
		}

		/// <summary>
		/// Convert FaxFileSet to ReceivedFax.  Any erroneous FaxFileSet are moved to another folder to prevent future processing.
		/// </summary>
		/// <param name="item"></param>
		protected override void ProcessItem(FaxFileSet item)
		{
			string destNumber = null;

			try
			{
				var ftpSettings = new AttachedDocumentFtpSettings();
				var ftpFileTransfer = new FtpFileTransfer(
					ftpSettings.FtpUserId,
					ftpSettings.FtpPassword,
					ftpSettings.FtpBaseUrl,
					ftpSettings.FtpPassiveMode);

				item.InitializeMetaData(_settings.MetaDataDelimiters);

				if (!item.HasMetaData)
				{
					Platform.Log(LogLevel.Error, SR.MessageMetaDataFileEmpty);
					item.MoveToFolder(_settings.ErrorFaxDirectory);
					return;
				}

				// check for minimum required fields
				destNumber = item.GetMetadataProperty<string>("USERFAXNUMBER");
				if (string.IsNullOrEmpty(destNumber))
				{
					Platform.Log(LogLevel.Error, SR.MessageRequiredFieldsMissing);
					item.MoveToFolder(_settings.ErrorFaxDirectory);
					return;
				}

				using (var scope = new PersistenceScope(PersistenceContextType.Update))
				{
					var context = (IUpdateContext)PersistenceScope.CurrentContext;
					context.ChangeSetRecorder.OperationName = GetType().FullName;

					// Find a fax machine based on the destination phone number
					var criteria = new FaxMachineSearchCriteria();
					criteria.Number.EqualTo(destNumber);
					var targetFaxMachine = context.GetBroker<IFaxMachineBroker>().FindOne(criteria);

					var receivedFax = new ReceivedFax(
						ReceivedFaxStatus.PD,
						Platform.Time,
						item.GetMetadataProperty<int>("PAGES"),
						targetFaxMachine,
						item.GetMetadataProperty<string>("FROMCSID"),
						item.GetMetadataProperty<string>("FROM"))
							{
								FileExtension = _settings.ImageDataFileExtension,
								MimeType = _settings.ImageDataFileExtension,
								ReceivedTime = item.GetMetadataProperty<DateTime>("DATE"),
								DataRelativeUrl = "DUMMY" // DataRelativeUrl is a required field, fill with a dummy value first
							};

					context.Lock(receivedFax, DirtyState.New);

					// Upload after Lock, because we need the EntityRef of the new receivedFax to construct DataRelativeUrl
					receivedFax.UploadDocument(ftpFileTransfer, item.ImageDataFile);

					scope.Complete();
				}

				// Delete fileset
				item.DeleteFiles();
			}
			catch (EntityNotFoundException e)
			{
				// special case if the fax machine cannot be found in the database
				Platform.Log(LogLevel.Error, string.Format(SR.MessageErrorFaxMachineNotFound, destNumber));
				ExceptionLogger.Log(this.GetType().FullName + ".ProcessItem", e);
				item.MoveToFolder(_settings.ErrorFaxDirectory);
			}
			catch (Exception e)
			{
				// catch and report all exceptions then move the fileset to an error directory
				ExceptionLogger.Log(this.GetType().FullName + ".ProcessItem", e);
				item.MoveToFolder(_settings.ErrorFaxDirectory);
			}
		}

		/// <summary>
		/// Validate that the creator of this shred has the read/write previledge to the specified path.
		/// </summary>
		/// <param name="path"></param>
		private static void ValidateDirectoryWriteAccess(string path)
		{
			try
			{
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);

				// Test for file write access
				var tempFile = Path.GetTempFileName();
				var destination = Path.Combine(path, Path.GetFileName(tempFile));
				File.Move(tempFile, destination);
				File.Delete(destination);
			}
			catch (Exception e)
			{
				var message = string.Format(SR.ExceptionFailedToCreateOrWriteToDirectory, path);
				throw new Exception(message, e);
			}
		}
	}
}
