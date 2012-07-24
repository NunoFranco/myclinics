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

using ClearCanvas.Common.Authorization;

namespace ClearCanvas.Material.Application.Common
{
	/// <summary>
	/// Defines constants for all core Material authority tokens.
	/// </summary>
	public static class AuthorityTokens
	{
		/// <summary>
		/// Tokens that allow access to administrative functionality.
		/// </summary>
		public static class Admin
		{
			public static class Data
			{
				[AuthorityToken(Description = "Allow administration of Facilities.")]
				public const string Contact = "Material/Admin/Data/Contact";

                [AuthorityToken(Description = "Allow administration of MaterialLot.")]
                public const string MaterialLot = "Material/Admin/Data/MaterialLot";

                [AuthorityToken(Description = "Allow administration of Warehouses.")]
                public const string Warehouse = "Material/Admin/Data/Warehouse";

                [AuthorityToken(Description = "Allow administration of MedicineCounter.")]
                public const string MedicineCounter = "Material/Admin/Data/MedicineCounter";

				[AuthorityToken(Description = "Allow administration of Procedure Type Groups (such as Performing, Reading, and Relevance Groups.")]
				public const string ProcedureTypeGroup = "Material/Admin/Data/Procedure Type Group";

				[AuthorityToken(Description = "Allow administration of Imaging Services and the Imaging Service Tree.")]
				public const string DiagnosticService = "Material/Admin/Data/Imaging Service";

				[AuthorityToken(Description = "Allow administration of Enumerations.")]
				public const string Enumeration = "Material/Admin/Data/Enumeration";

				[AuthorityToken(Description = "Allow administration of Worklists.")]
				public const string Worklist = "Material/Admin/Data/Worklist";

				[AuthorityToken(Description = "Allow administration of Protocol Groups and Codes.")]
				public const string ProtocolGroups = "Material/Admin/Data/Protocol Groups";

				[AuthorityToken(Description = "Allow administration of Staff.")]
				public const string Staff = "Material/Admin/Data/Staff";

				[AuthorityToken(Description = "Allow administration of Staff Groups.")]
				public const string StaffGroup = "Material/Admin/Data/Staff Group";

				[AuthorityToken(Description = "Allow administration of External Practitioners.")]
				public const string ExternalPractitioner = "Material/Admin/Data/External Practitioner";

				[AuthorityToken(Description = "Allow administration of Patient Note Categories.")]
				public const string PatientNoteCategory = "Material/Admin/Data/Patient Note Category";

                [AuthorityToken(Description = "Allow administration of Working Shift.")]
                public const string WorkingShift = "Material/Admin/Data/Working Shift";

                [AuthorityToken(Description = "Allow access to the Add new Prescription")]
                public const string DoctorPrescription = "Material/Admin/DoctorPrescription";

			}

		}

	}
}
