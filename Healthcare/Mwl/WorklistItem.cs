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
using ClearCanvas.Healthcare;

namespace ClearCanvas.Healthcare.Mwl
{
	public class WorklistItem : WorklistItemBase
	{
		private readonly DateTime? _dateOfBirth;
		private readonly Sex _sex;
		private readonly PersonName _orderingPractitionerName;
		private readonly VisitNumber _visitNumber;
		private readonly Location _currentLocation;
		private readonly string _procedureTypeId;
		private readonly string _procedureTypeName;
		private readonly string _performingFacilityCode;
		private readonly string _modalityName;

		public WorklistItem(
			ProcedureStep procedureStep,
			Procedure procedure,
			Order order,
			Patient patient,
			PatientProfile profile,
			PatientIdentifier mrn,
			PersonName patientName,
			DateTime? patientDateOfBirth,
			Sex patientSex,
			string accessionNumber,
			OrderPriority orderPriority,
			PersonName orderingPractitionerName,
			VisitNumber visitNumber,
			Location currentLocation,
			PatientClassEnum patientClass,
			string diagnosticServiceName,
			string procedureTypeId,
			string procedureTypeName,
			bool procedurePortable,
			Laterality procedureLaterality,
			string performingFacilityCode,
			string modalityName,
			DateTime? time)
			: base(
				procedureStep,
				procedure,
				order,
				patient,
				profile,
				mrn,
				patientName,
				accessionNumber,
				orderPriority,
				patientClass,
				diagnosticServiceName,
				procedureTypeName,
				procedurePortable,
				procedureLaterality,
				time
			)
		{
			_dateOfBirth = patientDateOfBirth;
			_sex = patientSex;
			_orderingPractitionerName = orderingPractitionerName;
			_visitNumber = visitNumber;
			_currentLocation = currentLocation;
			_procedureTypeId = procedureTypeId;
			_procedureTypeName = procedureTypeName;
			_performingFacilityCode = performingFacilityCode;
			_modalityName = modalityName;
		}

		public DateTime? DateOfBirth
		{
			get { return _dateOfBirth; }
		}

		public Sex PatientSex
		{
			get { return _sex; }
		}

		public PersonName OrderingPractitionerName
		{
			get { return _orderingPractitionerName; }
		}

		public VisitNumber VisitNumber
		{
			get { return _visitNumber; }
		}

		public Location CurrentLocation
		{
			get { return _currentLocation; }
		}

		public string ProcedureTypeId
		{
			get { return _procedureTypeId; }
		}

		public string ProcedureTypeName
		{
			get { return _procedureTypeName; }
		}

		public string PerformingFacilityCode
		{
			get { return _performingFacilityCode; }
		}

		public string ModalityName
		{
			get { return _modalityName; }
		}
	}
}
