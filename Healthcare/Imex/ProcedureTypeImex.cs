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
using System.Xml;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Imex;
using ClearCanvas.Healthcare.Brokers;

namespace ClearCanvas.Healthcare.Imex
{
	[ExtensionOf(typeof(XmlDataImexExtensionPoint))]
	[ImexDataClass("ProcedureType")]
	public class ProcedureTypeImex : XmlEntityImex<ProcedureType, ProcedureTypeImex.ProcedureTypeData>
	{
		[DataContract]
		public class ProcedureTypeData : ReferenceEntityDataBase
		{
			[DataMember]
			public string Id;

			[DataMember]
			public string Name;

			[DataMember]
			public string BaseTypeId;

			[DataMember]
			public XmlDocument PlanXml;

            [DataMember]
            public ClinicData Clinic;
		}



		#region Overrides

		protected override IList<ProcedureType> GetItemsForExport(IReadContext context, int firstRow, int maxRows)
		{
			var where = new ProcedureTypeSearchCriteria();
			where.Id.SortAsc(0);

			return context.GetBroker<IProcedureTypeBroker>().Find(where, new SearchResultPage(firstRow, maxRows));
		}

		protected override ProcedureTypeData Export(ProcedureType entity, IReadContext context)
		{
			var data = new ProcedureTypeData
						{
							Deactivated = entity.Deactivated, 
							Id = entity.Id, 
							Name = entity.Name
						};

			if (entity.BaseType != null)
			{
				data.BaseTypeId = entity.BaseType.Id;
			}
			data.PlanXml = entity.GetPlanXml();
            data.Clinic = new ClinicData(entity.Clinic);

			return data;
		}

		protected override void Import(ProcedureTypeData data, string clinicCode, IUpdateContext context)
		{
            Facility Currentclinic = Common.GetClinic(clinicCode, context);
			var pt = LoadOrCreateProcedureType(data.Id, data.Name, Currentclinic , context);
			pt.Deactivated = data.Deactivated;
			if (!string.IsNullOrEmpty(data.BaseTypeId))
			{
				pt.BaseType = LoadOrCreateProcedureType(data.BaseTypeId, data.BaseTypeId, Currentclinic , context);
			}

			if (data.PlanXml != null)
			{
				pt.SetPlanXml(data.PlanXml);
			}
		}

		#endregion

		private static ProcedureType LoadOrCreateProcedureType(string id, string name, Facility clinic, IPersistenceContext context)
		{
			ProcedureType pt;
			try
			{
				// see if already exists in db
				var where = new ProcedureTypeSearchCriteria();
				where.Id.EqualTo(id);
                where.Clinic.EqualTo(clinic);
				pt = context.GetBroker<IProcedureTypeBroker>().FindOne(where);
			}
			catch (EntityNotFoundException)
			{
				// create it
				pt = new ProcedureType(id, name);
                pt.Clinic = clinic;
				context.Lock(pt, DirtyState.New);
			}

			return pt;
		}
	}
}