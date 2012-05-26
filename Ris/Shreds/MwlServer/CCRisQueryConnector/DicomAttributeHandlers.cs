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
using ClearCanvas.Dicom;
using ClearCanvas.Dicom.Utilities;
using ClearCanvas.Healthcare.Mwl;
using ClearCanvas.Healthcare;
using System.Text;

namespace ClearCanvas.Ris.Shreds.MwlServer.CCRisQueryConnector
{
	/// <summary>
	/// Defines an interface that knows how to handle a DICOM attribute from the incoming query message and the result messages.
	/// </summary>
	public interface IDicomAttributeHandler
	{
		/// <summary>
		/// The DICOM tag value defined in <see cref="DicomTags"/>.
		/// </summary>
		uint DicomTag { get; }

		/// <summary>
		/// The maximum string length for this attribute value.  This is defined by the DICOM standard.  
		/// This property is ignored if the value is less or equal to zero.
		/// </summary>
		int MaximumValueLength { get; }

		/// <summary>
		/// Builds the search criteria for the current DicomTag based on the specified attribute value.
		/// </summary>
		void BuildSearchCriteria(string attributeValue, MwlItemSearchCriteria criteria);

		/// <summary>
		/// Builds the return DICOM message that corredpond to the worklist item.
		/// </summary>
		void BuildDicomMessage(WorklistItem item, DicomMessage message);
	}

	public abstract class DicomAttributeHandlerBase : IDicomAttributeHandler
	{
		protected const char SqlWildcard = '%';
		protected const char DicomWildcard = '*';
		protected const char DicomNameDelimiter = '^';
		protected const char DicomDateRangeDelimiter = '-';
		protected const string DicomTimeFormat = "HHmmss";

		public abstract uint DicomTag { get; }

		public virtual int MaximumValueLength
		{
			get { return 0; }
		}

		public virtual void BuildSearchCriteria(string attributeValue, MwlItemSearchCriteria criteria)
		{
			// by default, do nothing.
		}

		public virtual void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			// by default, do nothing.
		}

		#region Helpers

		/// <summary>
		/// Set the attribute value for this DICOM tag.  This creates a top-level attribute.
		/// </summary>
		protected virtual void SetAttributeValue(DicomMessage message, string attributeValue)
		{
			if (string.IsNullOrEmpty(attributeValue))
				attributeValue = "";

			if (this.MaximumValueLength > 0)
				attributeValue = TrimValueToLength(attributeValue, this.MaximumValueLength);

			message.DataSet[DicomTagDictionary.GetDicomTag(this.DicomTag).TagValue].SetStringValue(attributeValue);
		}

		protected static string FormatDicomPersonName(PersonName name)
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(name.FamilyName);
			builder.Append(DicomNameDelimiter);
			builder.Append(name.GivenName);
			return builder.ToString();
		}

		protected static bool ReplaceDicomWildcard(ref string attributeValue)
		{
			if (attributeValue.EndsWith(DicomWildcard.ToString()))
			{
				attributeValue = attributeValue.Replace(DicomWildcard, SqlWildcard);
				return true;
			}

			return false;
		}

		protected static string TrimValueToLength(string attributeValue, int maximumLength)
		{
			if (string.IsNullOrEmpty(attributeValue))
				return attributeValue;

			if (attributeValue.Length < maximumLength)
				return attributeValue;

			return attributeValue.Substring(0, maximumLength);
		}

		#endregion
	}

	/// <summary>
	/// Defines a base class that handles sequence attributes.
	/// </summary>
	public abstract class SequenceHandlerBase : DicomAttributeHandlerBase
	{
		// TODO: This class is limited to sequence attribute that are one level deep only. It does not yet work with a sequence attribute that belongs to another sequence attribute.
		public abstract uint SequenceTag { get; }

		/// <summary>
		/// Overwrite the base class method, so the attribute value for this DICOM tag is created at the proper sequence level.
		/// </summary>
		protected override void SetAttributeValue(DicomMessage message, string attributeValue)
		{
			if (string.IsNullOrEmpty(attributeValue))
				attributeValue = "";

			DicomSequenceItem sequenceItem = GetOrCreateSequence(this.SequenceTag, message);

			if (this.MaximumValueLength > 0)
				attributeValue = TrimValueToLength(attributeValue, this.MaximumValueLength);

			sequenceItem[DicomTagDictionary.GetDicomTag(this.DicomTag).TagValue].SetStringValue(attributeValue);
		}

		/// <summary>
		/// Gets or creates a dicom sequence item in the specified message.
		/// </summary>
		/// <param name="sequenceTag">The DicomTag of the sequence item.</param>
		/// <param name="message">The DICOM message to store the sequence item.</param>
		/// <returns>The sequence item that matches the specified sequence tag.</returns>
		protected static DicomSequenceItem GetOrCreateSequence(uint sequenceTag, DicomMessageBase message)
		{
			if (!message.DataSet.Contains(sequenceTag))
			{
				DicomAttributeSQ newSQAttribute = new DicomAttributeSQ(sequenceTag);
				message.DataSet[sequenceTag] = newSQAttribute;

				DicomSequenceItem newSequence = new DicomSequenceItem();
				newSQAttribute.AddSequenceItem(newSequence);
			}

			DicomAttributeSQ existingSQAttribute = (DicomAttributeSQ)message.DataSet[sequenceTag];

			// there should only be one sequence per message for this specific SequenceTag, hence we always look for the sequence at index 0
			return existingSQAttribute[0];
		}
	}

	#region Top Level Attribute Handler

	public class PatientsNameHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.PatientsName; }
		}

		public override void BuildSearchCriteria(string attributeValue, MwlItemSearchCriteria criteria)
		{
			if (string.IsNullOrEmpty(attributeValue))
				return;

			string[] parts = attributeValue.Split(DicomNameDelimiter);
			if (parts.Length > 0 && !string.IsNullOrEmpty(parts[0]))
			{
				if (ReplaceDicomWildcard(ref parts[0]))
					criteria.PatientProfile.Name.FamilyName.Like(parts[0]);
				else
					criteria.PatientProfile.Name.FamilyName.EqualTo(parts[0]);
			}

			if (parts.Length > 1 && !string.IsNullOrEmpty(parts[1]))
			{
				if (ReplaceDicomWildcard(ref parts[1]))
					criteria.PatientProfile.Name.GivenName.Like(parts[1]);
				else
					criteria.PatientProfile.Name.GivenName.EqualTo(parts[1]);
			}
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, FormatDicomPersonName(item.PatientName));
		}
	}

	public class PatientIdHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.PatientId; }
		}

		public override void BuildSearchCriteria(string attributeValue, MwlItemSearchCriteria criteria)
		{
			if (string.IsNullOrEmpty(attributeValue))
				return;

			if (ReplaceDicomWildcard(ref attributeValue))
				criteria.PatientProfile.Mrn.Id.Like(attributeValue);
			else
				criteria.PatientProfile.Mrn.Id.EqualTo(attributeValue);
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			string tagValue = string.Format("{0} {1}", item.Mrn.Id, item.PerformingFacilityCode);
			SetAttributeValue(message, tagValue);
		}
	}

	public class PatientsBirthDateHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.PatientsBirthDate; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.DateOfBirth == null ? null : DateParser.ToDicomString(item.DateOfBirth.Value));
		}
	}

	public class PatientsSexHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.PatientsSex; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.PatientSex.ToString());
		}
	}

	public class AdmissionIdHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.AdmissionId; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.VisitNumber.Id);
		}
	}

	public class AccessionNumberHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.AccessionNumber; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.AccessionNumber);
		}
	}

	public class ReferringPhysiciansNameHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.ReferringPhysiciansName; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, FormatDicomPersonName(item.OrderingPractitionerName));
		}
	}

	public class StudyInstanceUidHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.StudyInstanceUid; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, DicomUid.GenerateUid().UID);
		}
	}

	public class CurrentPatientLocationHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.CurrentPatientLocation; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			if (item.CurrentLocation == null)
				return;

			SetAttributeValue(message, item.CurrentLocation.PointOfCare);
		}
	}

	public class FillerOrderNumberImagingServiceRequestHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.FillerOrderNumberImagingServiceRequest; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.AccessionNumber);
		}
	}

	public class InstitutionNameHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.InstitutionName; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.PerformingFacilityCode);
		}
	}

	public class RequestedProcedureIdHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.RequestedProcedureId; }
		}

		public override int MaximumValueLength
		{
			get { return 16; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.AccessionNumber);
		}
	}

	public class RequestedProcedureDescriptionHandler : DicomAttributeHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.RequestedProcedureDescription; }
		}

		public override int MaximumValueLength
		{
			get { return 64; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			string tagValue = item.ProcedureTypeName + (item.ProcedurePortable ? " Port." : "");
			SetAttributeValue(message, tagValue);
		}
	}

	#endregion

	#region Scheduled Procedure Step Sequence

	/// <summary>
	/// Defines a base class that handles ScheduledProcedureStepSequence related attributes.
	/// </summary>
	public abstract class ScheduledProcedureStepSequenceHandlerBase : SequenceHandlerBase
	{
		public override uint SequenceTag
		{
			get { return DicomTags.ScheduledProcedureStepSequence; }
		}
	}

	public class ScheduledProcedureStepStartDateHandler : ScheduledProcedureStepSequenceHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.ScheduledProcedureStepStartDate; }
		}

		public override void BuildSearchCriteria(string attributeValue, MwlItemSearchCriteria criteria)
		{
			if (string.IsNullOrEmpty(attributeValue))
			{
				if (!MwlQuerySettings.Default.EnableDefaultScheduledStartDateTimeQueryBound)
					return;

				// Use the default time bound
				DateTime now = DateTime.Now;
				DateTime lower = now.AddHours(-1*MwlQuerySettings.Default.DefaultScheduledStartDateTimeLowerBound);
				DateTime upper = now.AddHours(MwlQuerySettings.Default.DefaultScheduledStartDateTimeUpperBound);
				criteria.ProcedureStep.Scheduling.StartTime.Between(lower, upper);
			}
			else
			{
				// use the user supplied query parameter

				if (attributeValue.Contains(DicomDateRangeDelimiter.ToString()))
				{
					// range date query
					string[] parts = attributeValue.Split(DicomDateRangeDelimiter);
					DateTime? lower = DateParser.Parse(parts[0]);
					DateTime? upper = DateParser.Parse(parts[1]);
					if (upper != null)
						upper = upper.Value.AddDays(1);

					if (upper == null)
						criteria.ProcedureStep.Scheduling.StartTime.MoreThanOrEqualTo(lower);
					else if (lower == null)
						criteria.ProcedureStep.Scheduling.StartTime.LessThan(upper);
					else
						criteria.ProcedureStep.Scheduling.StartTime.Between(lower, upper);
				}
				else
				{
					// exact date query effectively query from the beginning to the end of the date
					DateTime? lower = DateParser.Parse(attributeValue);
					DateTime? upper = lower.Value.AddDays(1);
					criteria.ProcedureStep.Scheduling.StartTime.Between(lower, upper);
				}
			}
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.Time == null ? null : DateParser.ToDicomString(item.Time.Value));
		}
	}

	public class ScheduledProcedureStepStartTimeHandler : ScheduledProcedureStepSequenceHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.ScheduledProcedureStepStartTime; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.Time == null ? null : item.Time.Value.ToString(DicomTimeFormat));
		}
	}

	public class ScheduledProcedureStepDescriptionHandler : ScheduledProcedureStepSequenceHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.ScheduledProcedureStepDescription; }
		}

		public override int MaximumValueLength
		{
			get { return 64; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			string tagValue = item.ProcedureTypeName + (item.ProcedurePortable ? " Port." : "");
			SetAttributeValue(message, tagValue);
		}
	}

	public class ScheduledProcedureStepIdHandler : ScheduledProcedureStepSequenceHandlerBase
	{
		public override uint DicomTag
		{
			get { return DicomTags.ScheduledProcedureStepId; }
		}

		public override int MaximumValueLength
		{
			get { return 16; }
		}

		public override void BuildDicomMessage(WorklistItem item, DicomMessage message)
		{
			SetAttributeValue(message, item.AccessionNumber);
		}
	}

	#endregion
}
