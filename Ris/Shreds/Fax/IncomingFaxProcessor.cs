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
using ClearCanvas.Common.Shreds;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Ris.Shreds.Fax
{
	/// <summary>
	/// This processor move the incoming fax files to another directory and schedules a FaxStorageWorkQueueItem.
	/// </summary>
	internal class IncomingFaxProcessor : QueueProcessor<FaxFileSet>
	{
		private readonly ReceivedFaxShredSettings _settings;

		public IncomingFaxProcessor(ReceivedFaxShredSettings settings)
			: base(settings.BatchSize, TimeSpan.FromSeconds(settings.EmptyQueueSleepTime))
		{
			_settings = settings;

			// Only start the processor if the these directories are validated.
			ValidateDirectoryWriteAccess(settings.IncomingFaxDirectory);
			ValidateDirectoryWriteAccess(settings.ReceivedFaxWorkQueueItemDirectory);
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
		/// Move the incoming fax files to another directory and schedules a FaxStorageWorkQueueItem.
		/// </summary>
		/// <param name="fileSet"></param>
		protected override void ProcessItem(FaxFileSet fileSet)
		{
			using (var scope = new PersistenceScope(PersistenceContextType.Update))
			{
				var context = (IUpdateContext)PersistenceScope.CurrentContext;
				context.ChangeSetRecorder.OperationName = GetType().FullName;

				var faxStorageItem = new ReceivedFaxWorkQueueItem();
				context.Lock(faxStorageItem.WorkQueueItem, DirtyState.New);

				try
				{
					fileSet.MoveToFolder(_settings.ReceivedFaxWorkQueueItemDirectory);

					fileSet.InitializeMetaData(_settings.MetaDataDelimiters);

					if (!fileSet.HasMetaData)
					{
						faxStorageItem.WorkQueueItem.Fail(SR.MessageMetaDataFileEmpty);
					}
					else
					{
						UpdateWorkQueueItem(faxStorageItem, fileSet);

						if (string.IsNullOrEmpty(faxStorageItem.DestinationNumber))
							faxStorageItem.WorkQueueItem.Fail(SR.MessageRequiredFieldsMissing);
					}
				}
				catch (Exception)
				{
					faxStorageItem.WorkQueueItem.Fail(SR.ExceptionFailedToParseMetaDataFile);
				}

				scope.Complete();
			}
		}

		private static void UpdateWorkQueueItem(ReceivedFaxWorkQueueItem faxStorageItem, FaxFileSet fileSet)
		{
			faxStorageItem.ReceivedTime = fileSet.GetMetadataProperty<DateTime>("DATE");
			faxStorageItem.Pages = fileSet.GetMetadataProperty<int>("PAGES");
			faxStorageItem.SenderName = fileSet.GetMetadataProperty<string>("FROMCSID");
			faxStorageItem.SenderNumber = fileSet.GetMetadataProperty<string>("FROM");
			faxStorageItem.DestinationNumber = fileSet.GetMetadataProperty<string>("USERFAXNUMBER");
			faxStorageItem.MetaDataFile = fileSet.MetaDataFile;
			faxStorageItem.ImageDataFile = fileSet.ImageDataFile;
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
