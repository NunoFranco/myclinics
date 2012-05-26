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

using System.Collections.Generic;
using ClearCanvas.Dicom;
using ClearCanvas.Healthcare.Mwl;
using ClearCanvas.Common;

namespace ClearCanvas.Ris.Shreds.MwlServer.CCRisQueryConnector
{
	[ExtensionPoint]
	public class MwlFilterExtensionPoint : ExtensionPoint<IMwlFilter>
	{
	}

	/// <summary>
	/// Interface for filtering the search criteria and the result DICOM message.
	/// </summary>
	public interface IMwlFilter
	{
		/// <summary>
		/// Process the search criteria and return modified search criteria.
		/// </summary>
		/// <param name="where">The search criteria before processed.</param>
		/// <param name="context"></param>
		/// <returns>The modified search criteria.</returns>
		IEnumerable<MwlItemSearchCriteria> QueryFilter(IEnumerable<MwlItemSearchCriteria> where, IMwlQueryFilterContext context);

		/// <summary>
		/// Process the DicomMessage result and return a modified DicomMessage.
		/// </summary>
		/// <param name="resultMessage">The result DicomMessage to be returned to the MWL client before processed.</param>
		/// <param name="context"></param>
		/// <returns>The modified DicomMessage.</returns>
		DicomMessage ResultFilter(DicomMessage resultMessage, IMwlResultFilterContext context);
	}
	
	/// <summary>
	/// Defines the context for filtering search criteria.  Properties of this interface should not be modified.
	/// </summary>
	public interface IMwlQueryFilterContext
	{
		/// <summary>
		/// The original DICOM message send from the MWL client.
		/// </summary>
		DicomMessage QueryMessage { get; }

		/// <summary>
		/// The AETitle of the calling MWL client.
		/// </summary>
		string CallingAE { get; }
	}

	/// <summary>
	/// Defines the context for filtering result DicomMessage.  Properties of this interface should not be modified.
	/// </summary>
	public interface IMwlResultFilterContext
	{
		/// <summary>
		/// The worklist item that correpond to the return DicomMessage.
		/// </summary>
		WorklistItem WorklistItem { get; }

		/// <summary>
		/// The original DICOM message send from the MWL client.
		/// </summary>
		DicomMessage QueryMessage { get; }

		/// <summary>
		/// The AETitle of the calling MWL client.
		/// </summary>
		string CallingAE { get; }
	}
}
