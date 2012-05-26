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
using ClearCanvas.Common.Utilities;
using ClearCanvas.Healthcare;

namespace ClearCanvas.Ris.Shreds.MwlServer.CCRisQueryConnector
{
	public class InitialMwlFilter : MwlFilterBase
	{
		private readonly List<IDicomAttributeHandler> _handlersDefined;
		private IDictionary<IDicomAttributeHandler, string> _handlersInUse;

		public InitialMwlFilter()
		{
			_handlersDefined = new List<IDicomAttributeHandler>();

			_handlersDefined.Add(new PatientsNameHandler());
			_handlersDefined.Add(new PatientIdHandler());
			_handlersDefined.Add(new PatientsBirthDateHandler());
			_handlersDefined.Add(new PatientsSexHandler());
			_handlersDefined.Add(new AdmissionIdHandler());
			_handlersDefined.Add(new AccessionNumberHandler());
			_handlersDefined.Add(new ReferringPhysiciansNameHandler());
			_handlersDefined.Add(new StudyInstanceUidHandler());
			_handlersDefined.Add(new CurrentPatientLocationHandler());
			_handlersDefined.Add(new FillerOrderNumberImagingServiceRequestHandler());
			_handlersDefined.Add(new InstitutionNameHandler());
			_handlersDefined.Add(new RequestedProcedureIdHandler());
			_handlersDefined.Add(new RequestedProcedureDescriptionHandler());

			_handlersDefined.Add(new ScheduledProcedureStepStartDateHandler());
			_handlersDefined.Add(new ScheduledProcedureStepStartTimeHandler());
			_handlersDefined.Add(new ScheduledProcedureStepDescriptionHandler());
			_handlersDefined.Add(new ScheduledProcedureStepIdHandler());
		}

		#region IMwlFilter Members

		public override IEnumerable<MwlItemSearchCriteria> QueryFilter(IEnumerable<MwlItemSearchCriteria> where, IMwlQueryFilterContext context)
		{
			// From list of handlers defined, get the ones that are requested in the query DICOM message.
			_handlersInUse = GetHandlersInUse(_handlersDefined, context.QueryMessage);

			MwlItemSearchCriteria baseCriteria = new MwlItemSearchCriteria(typeof(ModalityProcedureStep));

			foreach (IDicomAttributeHandler handler in _handlersInUse.Keys)
			{
				string attributeValue = _handlersInUse[handler];
				handler.BuildSearchCriteria(attributeValue, baseCriteria);
			}

			return new MwlItemSearchCriteria[] { baseCriteria };
		}

		public override DicomMessage ResultFilter(DicomMessage resultMessageToBeIgnored, IMwlResultFilterContext context)
		{
			// Create the result message based on all the tags in the query message.  This make sure all the requested tags
			// existed in the result message.  Then make sure to clear all the values in the result message.
			// the handlers and other filters will then populate the attribute values appropriately.
			DicomMessage newResultMessage = new DicomMessage(null, context.QueryMessage.DataSet.Copy(false, false, false));
			SetAllAttributeValue(newResultMessage.DataSet, "");

			foreach (IDicomAttributeHandler handler in _handlersInUse.Keys)
			{
				handler.BuildDicomMessage(context.WorklistItem, newResultMessage);
			}

			return newResultMessage;
		}

		#endregion

		private static IDictionary<IDicomAttributeHandler, string> GetHandlersInUse(IEnumerable<IDicomAttributeHandler> handlersDefined, DicomMessageBase message)
		{
			// Consturction a list of all attribute collections in this Dicom message
			IList<DicomAttributeCollection> attributeCollections = new List<DicomAttributeCollection>();
			attributeCollections.Add(message.DataSet);
			if (message.DataSet.Contains(DicomTags.ScheduledProcedureStepSequence))
			{
				DicomSequenceItem[] items = (DicomSequenceItem[])message.DataSet.GetAttribute(DicomTags.ScheduledProcedureStepSequence).Values;

				// there should only be one
				attributeCollections.Add(items[0]);
			}

			// Construct a map of all the DicomAttributesHandlers that will be used, and the corresponding attribute values
			Dictionary<IDicomAttributeHandler, string> attributeHandlerInUse = new Dictionary<IDicomAttributeHandler, string>();
			foreach (DicomAttributeCollection collection in attributeCollections)
			{
				foreach (DicomAttribute attribute in collection)
				{
					// attribute.IsNull is okay, because client may send request with null value, asking for the tag to be populated in return messages
					if (attribute.IsEmpty)
						continue;

					string attributeValue = attribute.GetString(0, "");

					IDicomAttributeHandler handler = CollectionUtils.SelectFirst(handlersDefined,
						delegate(IDicomAttributeHandler h) { return h.DicomTag == attribute.Tag.TagValue; });

					if (handler != null)
						attributeHandlerInUse[handler] = attributeValue;
				}
			}

			return attributeHandlerInUse;
		}
	}
}
