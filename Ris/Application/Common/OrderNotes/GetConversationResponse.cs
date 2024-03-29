﻿#region License

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

using System.Collections.Generic;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common.OrderNotes
{
	[DataContract]
	public class GetConversationResponse : DataContractBase
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="orderRef"></param>
		/// <param name="orderNotes"></param>
		/// <param name="count"></param>
		public GetConversationResponse(EntityRef orderRef, List<OrderNoteDetail> orderNotes, int count)
		{
			this.OrderRef = orderRef;
			this.OrderNotes = orderNotes;
			this.NoteCount = count;
		}

		/// <summary>
		/// Current OrderRef for the requested order.
		/// </summary>
		[DataMember]
		public EntityRef OrderRef;

		/// <summary>
		/// List of order notes in the conversation matching the specified filters,
		/// or null if <see cref="GetConversationRequest.CountOnly"/> was true.
		/// </summary>
		[DataMember]
		public List<OrderNoteDetail> OrderNotes;

		/// <summary>
		/// Count of notes in the conversation.
		/// </summary>
		[DataMember]
		public int NoteCount;
	}
}
