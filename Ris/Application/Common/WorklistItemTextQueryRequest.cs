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

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common
{
	[DataContract]
	public class WorklistItemTextQueryRequest : TextQueryRequest
	{
        [DataContract]
        public class AdvancedSearchFields : DataContractBase
        {
            [DataMember]
            public string FamilyName;

            [DataMember]
            public string GivenName;

            [DataMember]
            public string Mrn;

            [DataMember]
            public string HealthcardNumber;

            [DataMember]
            public string AccessionNumber;

        	[DataMember]
			public EntityRef DiagnosticServiceRef;

            [DataMember]
            public EntityRef ProcedureTypeRef;

            [DataMember]
            public EntityRef OrderingPractitionerRef;

            [DataMember]
            public DateTime? FromDate;

            [DataMember]
            public DateTime? UntilDate;

			/// <summary>
			/// Checks if all search fields are empty.
			/// </summary>
			/// <returns></returns>
			public bool IsEmpty()
			{
				return IsEmpty(FamilyName)
				       && IsEmpty(GivenName)
				       && IsEmpty(Mrn)
				       && IsEmpty(HealthcardNumber)
				       && IsEmpty(AccessionNumber)
					   && DiagnosticServiceRef == null
				       && ProcedureTypeRef == null
				       && OrderingPractitionerRef == null
				       && FromDate == null
				       && UntilDate == null;
			}

			/// <summary>
			/// Checks if non-patient search fields are emtpy.
			/// </summary>
			/// <returns></returns>
			public bool IsNonPatientFieldsEmpty()
			{
				return IsEmpty(AccessionNumber)
					   && DiagnosticServiceRef == null
					   && ProcedureTypeRef == null
					   && OrderingPractitionerRef == null
					   && FromDate == null
					   && UntilDate == null;
			}

			private static bool IsEmpty(string s)
			{
				return s == null || s.Trim().Length == 0;
			}
        }

        /// <summary>
		/// Constructor
		/// </summary>
		public WorklistItemTextQueryRequest(EntityRef clinicref):base( clinicref)
		{
            
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="textQuery"></param>
		/// <param name="specificityThreshold"></param>
		/// <param name="procedureStepClassName"></param>
		/// <param name="options"></param>
		public WorklistItemTextQueryRequest(string textQuery, int specificityThreshold, string procedureStepClassName, WorklistItemTextQueryOptions options)
			: base(textQuery, specificityThreshold)
		{
			ProcedureStepClassName = procedureStepClassName;
			Options = options;
		}

		/// <summary>
		/// Name of the procedure step class of interest.
		/// </summary>
		[DataMember]
		public string ProcedureStepClassName;

		/// <summary>
		/// Specifies options that affect how the search is executed.
		/// </summary>
		[DataMember]
		public WorklistItemTextQueryOptions Options;

        /// <summary>
        /// Specifies that "advanced" mode should be used, in which case the text query is ignored
        /// and the search is based on the content of the <see cref="SearchFields"/> member.
        /// </summary>
        [DataMember]
        public bool UseAdvancedSearch;

        /// <summary>
        /// Data used in the advanced search mode.
        /// </summary>
        [DataMember]
        public AdvancedSearchFields SearchFields;
	}
}
