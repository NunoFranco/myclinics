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
using ClearCanvas.Workflow;

namespace ClearCanvas.Ris.Shreds.Fax
{
	public class ReceivedFaxWorkQueueItem
	{
		public const string ItemType = "Received Fax";

		private readonly WorkQueueItem _item;

		public ReceivedFaxWorkQueueItem()
		{
			_item = new WorkQueueItem(ItemType);
		}

		public ReceivedFaxWorkQueueItem(WorkQueueItem item)
		{
			_item = item;
		}

		public WorkQueueItem WorkQueueItem
		{
			get { return _item; }
		}

		public DateTime ReceivedTime
		{
			get { return DateTime.Parse(_item.ExtendedProperties["ReceivedTime"]); }
			set { _item.ExtendedProperties["ReceivedTime"] = value.ToString(); }
		}

		public int Pages
		{
			get { return int.Parse(_item.ExtendedProperties["Pages"]); }
			set { _item.ExtendedProperties["Pages"] = value.ToString(); }
		}

		public string SenderName
		{
			get { return _item.ExtendedProperties["SenderName"]; }
			set { _item.ExtendedProperties["SenderName"] = value; }
		}

		public string SenderNumber
		{
			get { return _item.ExtendedProperties["SenderNumber"]; }
			set { _item.ExtendedProperties["SenderNumber"] = value; }
		}

		public string DestinationNumber
		{
			get { return _item.ExtendedProperties["DestinationNumber"]; }
			set { _item.ExtendedProperties["DestinationNumber"] = value; }
		}

		public string MetaDataFile
		{
			get { return _item.ExtendedProperties["MetaDataFile"]; }
			set { _item.ExtendedProperties["MetaDataFile"] = value; }
		}

		public string ImageDataFile
		{
			get { return _item.ExtendedProperties["ImageDataFile"]; }
			set { _item.ExtendedProperties["ImageDataFile"] = value; }
		}
	}
}
