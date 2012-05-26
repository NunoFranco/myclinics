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
using System.IO;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Fax;
using ClearCanvas.Healthcare.Fax.Brokers;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Workflow;

namespace ClearCanvas.Ris.Shreds.Fax
{
	/// <summary>
	/// This processor converts a FaxStorageWorkQueueItem to a ReceivedFax entity and upload the corresponding fax files.
	/// </summary>
	internal class ReceivedFaxWorkQueueProcessor : WorkQueueProcessor
	{
		/// <summary>
		/// Defines a workflow exception when no fax machine can be found for a specified destination number.
		/// </summary>
		private class FaxMachineNotFoundException : Exception
		{
			public FaxMachineNotFoundException(string destinationNumber, Exception inner)
				: base(string.Format(SR.MessageErrorFaxMachineNotFound, destinationNumber), inner)
			{
			}
		}

		private readonly ReceivedFaxShredSettings _faxSettings;
		private readonly AttachedDocumentSettings _ftpSettings;

		public ReceivedFaxWorkQueueProcessor(ReceivedFaxShredSettings faxSettings, AttachedDocumentSettings ftpSettings)
			: base(faxSettings.BatchSize, TimeSpan.FromSeconds(faxSettings.EmptyQueueSleepTime))
		{
			_faxSettings = faxSettings;
			_ftpSettings = ftpSettings;
		}

		protected override string WorkQueueItemType
		{
			get { return ReceivedFaxWorkQueueItem.ItemType; }
		}

		protected override bool ShouldRetry(WorkQueueItem item, Exception error, out DateTime retryTime)
		{
			// Do not retry if FaxMachine is not found.  Otherwise, reschedule with delay for all other errors
			retryTime = Platform.Time.AddSeconds(_faxSettings.FailedItemRetryDelay);

			if (error is FaxMachineNotFoundException)
				return false;

			return (item.FailureCount < _faxSettings.FailedItemRetryCount);
		}

		protected override void ActOnItem(WorkQueueItem item)
		{
			var faxStorageItem = new ReceivedFaxWorkQueueItem(item);

			try
			{
				using (var scope = new PersistenceScope(PersistenceContextType.Update))
				{
					var context = (IUpdateContext)PersistenceScope.CurrentContext;
					context.ChangeSetRecorder.OperationName = GetType().FullName;

					var criteria = new FaxMachineSearchCriteria();
					criteria.Number.EqualTo(faxStorageItem.DestinationNumber);
					criteria.Deactivated.EqualTo(false);
					var targetFaxMachine = context.GetBroker<IFaxMachineBroker>().FindOne(criteria);

					var receivedFax = new ReceivedFax
					{
						SenderName = faxStorageItem.SenderName,
						SenderNumber = faxStorageItem.SenderNumber,
						ReceivingFaxMachine = targetFaxMachine,
						ReceivedTime = faxStorageItem.ReceivedTime,
						PageCount = faxStorageItem.Pages,
						FileExtension = _faxSettings.ImageDataFileExtension,
						MimeType = _faxSettings.ImageDataFileExtension,
						ContentUrl = "DUMMY" // ContentUrl is a required field, fill with a dummy value first
						
					};

					context.Lock(receivedFax, DirtyState.New);

					// Upload after Lock, because we need the EntityRef of the new receivedFax to construct ContentUrl
					UploadFile(receivedFax, faxStorageItem.ImageDataFile);

					scope.Complete();
				}

				// Successfully processed this work queue item, delete the files
				File.Delete(faxStorageItem.MetaDataFile);
				File.Delete(faxStorageItem.ImageDataFile);
			}
			catch (EntityNotFoundException e)
			{
				throw new FaxMachineNotFoundException(faxStorageItem.DestinationNumber, e);
			}
		}

		private void UploadFile(AttachedDocument document, string localFilePath)
		{
			var ftpFileTransfer = new FtpFileTransfer(
				_ftpSettings.FtpUserId,
				_ftpSettings.FtpPassword,
				_ftpSettings.FtpBaseUrl,
				_ftpSettings.FtpPassiveMode);

			var pathDelimiter = ftpFileTransfer.BaseUri.Segments[0];
			document.ContentUrl = AttachedDocument.BuildContentUrl(document, pathDelimiter);
			var fullUrl = new Uri(ftpFileTransfer.BaseUri, document.ContentUrl);
			ftpFileTransfer.Upload(new FileTransferRequest(fullUrl, localFilePath));
		}
	}
}
