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
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Dicom;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare.Mwl;
using ClearCanvas.Healthcare.Mwl.Brokers;
using ClearCanvas.Ris.Shreds.MwlServer;

namespace ClearCanvas.Ris.Shreds.MwlServer.CCRisQueryConnector
{
	/// <summary>
	/// Defines an <see cref="IQueryConnector"/> that connects to a ClearCanvas Ris database.
	/// </summary>
	[ExtensionOf(typeof(MwlServerExtensionPoint))]
	public class CCRisConnector : IQueryConnector
	{
		class MwlQueryFilterContext : IMwlQueryFilterContext
		{
			private readonly DicomMessage _message;
			private readonly string _callingAE;

			public MwlQueryFilterContext(DicomMessage message, string callingAE)
			{
				_message = message;
				_callingAE = callingAE;
			}

			public DicomMessage QueryMessage
			{
				get { return _message; }
			}

			public string CallingAE
			{
				get { return _callingAE; }
			}
		}

		class MwlResultFilterContext : IMwlResultFilterContext
		{
			private readonly WorklistItem _item;
			private readonly DicomMessage _message;
			private readonly string _callingAE;

			public MwlResultFilterContext(WorklistItem item, DicomMessage message, string callingAE)
			{
				_item = item;
				_message = message;
				_callingAE = callingAE;
			}

			public WorklistItem WorklistItem
			{
				get { return _item;  }
			}

			public DicomMessage QueryMessage
			{
				get { return _message; }
			}

			public string CallingAE
			{
				get { return _callingAE; }
			}
		}

		private readonly InitialMwlFilter _initialFilter;
		private readonly object[] _mwlFilterExtensions;

		public CCRisConnector()
		{
			_initialFilter = new InitialMwlFilter();
			_mwlFilterExtensions = new MwlFilterExtensionPoint().CreateExtensions();
		}

		#region IQueryConnector Members

		public IList<DicomMessage> Query(DicomMessage message, string callingAE)
		{
			IEnumerable<MwlItemSearchCriteria> where = BuildSearchCriteria(message, callingAE);

			IList<WorklistItem> items = DoQuery(where);

			IEnumerable<DicomMessage> messages = BuildReturnDicomMessages(items, message, callingAE);

			return new List<DicomMessage>(messages);
		}

		#endregion

		#region Helper

		private IEnumerable<MwlItemSearchCriteria> BuildSearchCriteria(DicomMessage message, string callingAE)
		{
			MwlQueryFilterContext context = new MwlQueryFilterContext(message, callingAE);
			IEnumerable<MwlItemSearchCriteria> where = _initialFilter.QueryFilter(null, context);

			// Let each filter has a chance to modify the search criteria
			foreach (IMwlFilter filter in _mwlFilterExtensions)
			{
				where = filter.QueryFilter(where, context);
			}

			return where;
		}

		private static IList<WorklistItem> DoQuery(IEnumerable<MwlItemSearchCriteria> where)
		{
			bool noCriteriaSpecified = CollectionUtils.TrueForAll(where,
				delegate(MwlItemSearchCriteria c) { return c.IsEmpty; });

			if (noCriteriaSpecified)
				return new List<WorklistItem>();

			SearchResultPage page = new SearchResultPage();
			page.FirstRow = 0;
			page.MaxRows = MwlQuerySettings.Default.MaxResultsPerQuery;

			using (PersistenceScope scope = new PersistenceScope(PersistenceContextType.Read))
			{
				IReadContext context = (IReadContext)PersistenceScope.CurrentContext;

				IList<WorklistItem> items = context.GetBroker<IMwlItemBroker>().GetWorklistItems(where, new MwlQueryContext(page));
				scope.Complete();
				return items;
			}
		}

		private IEnumerable<DicomMessage> BuildReturnDicomMessages(IEnumerable<WorklistItem> items, DicomMessage queryMessage, string callingAE)
		{
			List<DicomMessage> messages = new List<DicomMessage>();

			// Let each filter has a chance to modify the returning DicomMessage
			foreach (WorklistItem item in items)
			{
				MwlResultFilterContext context = new MwlResultFilterContext(item, queryMessage, callingAE);
				DicomMessage message = _initialFilter.ResultFilter(null, context);

				foreach (IMwlFilter filter in _mwlFilterExtensions)
				{
					message = filter.ResultFilter(message, context);
				}

				messages.Add(message);
			}

			return messages;
		}

		#endregion
	}
}
