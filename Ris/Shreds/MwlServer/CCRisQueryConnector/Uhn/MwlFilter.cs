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
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Dicom;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Healthcare.Mwl;
using ClearCanvas.Healthcare.Uhn;
using ClearCanvas.Healthcare.Uhn.Brokers;
using ClearCanvas.Ris.Shreds.MwlServer.CCRisQueryConnector;

namespace ClearCanvas.Ris.Shreds.MwlServer.CCRisQueryConnector.Uhn
{
	/// <summary>
	/// Defines a MWL Filter that is specific to Uhn using a ClearCanvas Ris database.
	/// </summary>
	[ExtensionOf(typeof(MwlFilterExtensionPoint))]
	public class MwlFilter : MwlFilterBase
	{
		#region IMwlFilter Members

		public override IEnumerable<MwlItemSearchCriteria> QueryFilter(IEnumerable<MwlItemSearchCriteria> where, IMwlQueryFilterContext context)
		{
			List<MwlItemSearchCriteria> returnCriteria = new List<MwlItemSearchCriteria>();

			DicomAttribute modalityAttribute;
			string modalityAttributeValue = null;
			if (TryGetAttribute(context.QueryMessage.DataSet, DicomTags.Modality, out modalityAttribute))
				modalityAttributeValue = modalityAttribute.GetString(0, "");

			// Look for a list of procedures that are assigned to this AETitle.
			List<string> procedureIdsFromAE = GetProcedureIdForModalityAETitle(context.CallingAE);

			foreach (MwlItemSearchCriteria c in where)
			{
				List<string> procedureIds = new List<string>(procedureIdsFromAE);

				// Map DICOM modality value to Uhn's notion of modality.
				switch (modalityAttributeValue)
				{
					case "CR":
						c.Modality.Name.In(new string[] {"General Radiography", "CR"});
						break;

					case "NM":
						c.Modality.Name.EqualTo("Nuclear Medicine");
						break;

					case "MR":
						c.Modality.Name.EqualTo("MRI");
						break;

					case "XA":
						c.Modality.Name.EqualTo("Angiography");
						break;

					case "MG":
						c.Modality.Name.EqualTo("Breast Imaging");
						break;

					case "CT":
						c.Modality.Name.EqualTo("CT");
						break;

					case "US":
						// Query base on Modality == Ultrasound
						c.Modality.Name.EqualTo("Ultrasound");

						// Or ProcedureTypeId in one of the following Breast Imaging procedures that are considered to be "US" modality in the DICOM sense.
						procedureIds.AddRange(MwlFilterSettings.Default.BreastImagingUltrasoundProcedureIDs.Replace(" ", "").Split(','));

						break;

					default:
						// do nothing
						break;
				}

				if (procedureIds.Count > 0)
					c.Procedure.Type.Id.In(procedureIds);

				returnCriteria.Add(c);
			}

			return returnCriteria;
		}

		public override DicomMessage ResultFilter(DicomMessage resultMessage, IMwlResultFilterContext context)
		{
			DicomAttribute modalityAttribute;
			if (TryGetAttribute(resultMessage.DataSet, DicomTags.Modality, out modalityAttribute))
			{
				string attributeValue = modalityAttribute.GetString(0, "");

				// Map Uhn modality back to DICOM modality.
				switch (context.WorklistItem.ModalityName)
				{
					case "General Radiography": 
						attributeValue = "CR";
						break;
					case "Nuclear Medicine": 
						attributeValue = "NM";
						break;
					case "MRI": 
						attributeValue = "MR";
						break;
					case "Angiography": 
						attributeValue = "XA";
						break;
					case "CT": 
						attributeValue = "CT";
						break;
					case "GI/GU": 
						attributeValue = "CR";
						break;
					case "Ultrasound": 
						attributeValue = "US";
						break;
					case "Breast Imaging":
						// return "US" as the modality for the following Breast Imaging procedures that are considered to be "US" modality in the DICOM sense.
						List<string> procedureIDs = new List<string>(MwlFilterSettings.Default.BreastImagingUltrasoundProcedureIDs.Replace(" ", "").Split(','));
						if (procedureIDs.Contains(context.WorklistItem.ProcedureTypeId))
							attributeValue = "US";
						else
							attributeValue = "MG";

						break;

					default:
						break;
				}

				modalityAttribute.SetStringValue(attributeValue);
			}

			TagReplacement(resultMessage, context.CallingAE);

			return resultMessage;
		}

		#endregion

		/// <summary>
		/// Look up a list of procedures that are assigned to a modality AETitle.
		/// </summary>
		private static List<string> GetProcedureIdForModalityAETitle(string modalityAETitle)
		{
			List<string> procedureIds = new List<string>();

			try
			{
				MwlProcedureModalityAEMappingSearchCriteria where = new MwlProcedureModalityAEMappingSearchCriteria();
				where.ModalityAETitle.EqualTo(modalityAETitle);

				using (PersistenceScope scope = new PersistenceScope(PersistenceContextType.Read))
				{
					IReadContext context = (IReadContext)PersistenceScope.CurrentContext;

					IList<MwlProcedureModalityAEMapping> mappings = context.GetBroker<IMwlProcedureModalityAEMappingBroker>().Find(where);

					procedureIds = CollectionUtils.Map<MwlProcedureModalityAEMapping, string>(mappings,
						delegate(MwlProcedureModalityAEMapping m) { return m.ProcedureId; });

					scope.Complete();
				} 
			}
			catch (Exception e)
			{
				Platform.Log(LogLevel.Error, e, "Problem performing ProcedureId-ModalityAETitle mapping");
			}

			return procedureIds;
		}

		/// <summary>
		/// Look up the tag replacement rules.  , and replace value of the attribute value 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="modalityAETitle"></param>
		private static void TagReplacement(DicomMessageBase message, string modalityAETitle)
		{
			try
			{
				List<TagReplacementRule> rules = TagReplacementSettingsHelper.Instance.GetRulesForAETitle(modalityAETitle);

				DicomAttribute attributeFound;
				foreach (TagReplacementRule rule in rules)
				{
					if (TryGetAttribute(message.DataSet, rule.DicomTag, out attributeFound))
						attributeFound.SetStringValue(rule.NewValue);
				}
			}
			catch (Exception e)
			{
				Platform.Log(LogLevel.Error, e, "Problem performing tag-replacement");
			}
		}
	
	}
}
