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
		/// Move files to another directory.
		/// </summary>
		public void MoveToFolder(string newFolder)
		{
			var newMetaDataFile = Path.Combine(newFolder, Path.GetFileName(this.MetaDataFile));
			var newImageDataFile = Path.Combine(newFolder, Path.GetFileName(this.ImageDataFile));

			if (File.Exists(newMetaDataFile))
			{
				File.Copy(this.MetaDataFile, newMetaDataFile, true);
				File.Delete(this.MetaDataFile);
			}
			else
			{
				File.Move(this.MetaDataFile, newMetaDataFile);
			}

			if (File.Exists(newImageDataFile))
			{
				File.Copy(this.ImageDataFile, newImageDataFile, true);
				File.Delete(this.ImageDataFile);
			}
			else
			{
				File.Move(this.ImageDataFile, newImageDataFile);
			}

			this.MetaDataFile = newMetaDataFile;
			this.ImageDataFile = newImageDataFile;
		}

		#endregion
	}


}
