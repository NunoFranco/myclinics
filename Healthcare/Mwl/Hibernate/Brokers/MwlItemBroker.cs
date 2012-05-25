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
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Enterprise.Hibernate.Hql;
using ClearCanvas.Healthcare.Mwl.Brokers;
using System.Collections.Generic;
using ClearCanvas.Workflow;

namespace ClearCanvas.Healthcare.Mwl.Hibernate.Brokers
{
    /// <summary>
    /// Implementation of <see cref="IMwlItemBroker"/>.
    /// </summary>
    [ExtensionOf(typeof(BrokerExtensionPoint))]
	public class MwlItemBroker : Broker, IMwlItemBroker
    {
		/// <summary>
		/// Provides mappings from criteria "keys" to HQL expressions.
		/// </summary>
		private readonly Dictionary<string, string> _mapCriteriaKeyToHql = new Dictionary<string, string>();

		public MwlItemBroker()
		{
			// add a default set of mappings useful to all broker subclasses
			_mapCriteriaKeyToHql.Add("Order", "o");
			_mapCriteriaKeyToHql.Add("Visit", "v");
			_mapCriteriaKeyToHql.Add("PatientProfile", "pp");
			_mapCriteriaKeyToHql.Add("Procedure", "rp");
			_mapCriteriaKeyToHql.Add("ProcedureStep", "ps");
			_mapCriteriaKeyToHql.Add("Modality", "m");
		}

		#region HQL Constants

		protected static readonly HqlSelect SelectProcedureStep = new HqlSelect("ps");
		protected static readonly HqlSelect SelectProcedure = new HqlSelect("rp");
		protected static readonly HqlSelect SelectOrder = new HqlSelect("o");
		protected static readonly HqlSelect SelectPatient = new HqlSelect("p");
		protected static readonly HqlSelect SelectPatientProfile = new HqlSelect("pp");
		protected static readonly HqlSelect SelectMrn = new HqlSelect("pp.Mrn");
		protected static readonly HqlSelect SelectPatientName = new HqlSelect("pp.Name");
		protected static readonly HqlSelect SelectAccessionNumber = new HqlSelect("o.AccessionNumber");
		protected static readonly HqlSelect SelectOrderingPractitionerName = new HqlSelect("xp.Name");
		protected static readonly HqlSelect SelectPriority = new HqlSelect("o.Priority");
		protected static readonly HqlSelect SelectVisitNumber = new HqlSelect("v.VisitNumber");
		protected static readonly HqlSelect SelectCurrentLocation = new HqlSelect("l");
		protected static readonly HqlSelect SelectPatientClass = new HqlSelect("v.PatientClass");
		protected static readonly HqlSelect SelectDiagnosticServiceName = new HqlSelect("ds.Name");
		protected static readonly HqlSelect SelectProcedureTypeId = new HqlSelect("rpt.Id");
		protected static readonly HqlSelect SelectProcedureTypeName = new HqlSelect("rpt.Name");
		protected static readonly HqlSelect SelectProcedureStepState = new HqlSelect("ps.State");
		protected static readonly HqlSelect SelectHealthcard = new HqlSelect("pp.Healthcard");
		protected static readonly HqlSelect SelectDateOfBirth = new HqlSelect("pp.DateOfBirth");
		protected static readonly HqlSelect SelectSex = new HqlSelect("pp.Sex");

		protected static readonly HqlSelect SelectPerformingFacilityCode = new HqlSelect("f.Code");
		protected static readonly HqlSelect SelectProcedurePortable = new HqlSelect("rp.Portable");
		protected static readonly HqlSelect SelectProcedureLaterality = new HqlSelect("rp.Laterality");

		protected static readonly HqlSelect SelectProcedureStepScheduledStartTime = new HqlSelect("ps.Scheduling.StartTime");
		protected static readonly HqlSelect SelectModalityName = new HqlSelect("m.Name");

		protected static readonly HqlJoin JoinProcedure = new HqlJoin("ps.Procedure", "rp");
		protected static readonly HqlJoin JoinProcedureType = new HqlJoin("rp.Type", "rpt");
		protected static readonly HqlJoin JoinOrder = new HqlJoin("rp.Order", "o");
		protected static readonly HqlJoin JoinDiagnosticService = new HqlJoin("o.DiagnosticService", "ds");
		protected static readonly HqlJoin JoinVisit = new HqlJoin("o.Visit", "v");
		protected static readonly HqlJoin JoinPatient = new HqlJoin("o.Patient", "p");
		protected static readonly HqlJoin JoinPatientProfile = new HqlJoin("p.Profiles", "pp");

		protected static readonly HqlJoin LeftJoinVisitLocation = new HqlJoin("v.CurrentLocation", "l", HqlJoinMode.Left);
		protected static readonly HqlJoin LeftJoinModality = new HqlJoin("ps.Modality", "m", HqlJoinMode.Left);
		protected static readonly HqlJoin LeftJoinPerformingFacility = new HqlJoin("rp.PerformingFacility", "f", HqlJoinMode.Left);
		protected static readonly HqlJoin LeftJoinOrderingPractitioner = new HqlJoin("o.OrderingPractitioner", "xp", HqlJoinMode.Left);

		protected static readonly HqlCondition ConditionActiveProcedureStep = new HqlCondition("(ps.State in (?, ?))", ActivityStatus.SC, ActivityStatus.IP);
		protected static readonly HqlCondition ConditionProfileInformationAuthority = new HqlCondition("pp.Mrn.AssigningAuthority = rp.PerformingFacility.InformationAuthority");

		protected static readonly HqlSort SortByProcedureStepScheduledStartTime = new HqlSort("ps.Scheduling.StartTime", true, 0);

		protected static readonly HqlSelect[] WorklistCountProjection
			= {
                  new HqlSelect("count(*)"),
              };

		private static readonly HqlSelect[] WorklistProjections
			= {
					SelectProcedureStep,
					SelectProcedure,
					SelectOrder,
					SelectPatient,
					SelectPatientProfile,

					// PatientProfile
					SelectMrn,
					SelectPatientName,
					SelectDateOfBirth,
					SelectSex,

					// Order
					SelectAccessionNumber,
					SelectPriority,
					SelectOrderingPractitionerName,

					// Visit
					SelectVisitNumber,
					SelectCurrentLocation,
					SelectPatientClass,

					// Procedure
                    SelectDiagnosticServiceName,
					SelectProcedureTypeId,
					SelectProcedureTypeName,
					SelectProcedurePortable,
					SelectProcedureLaterality,
					SelectPerformingFacilityCode,

					// ProcedureStep
					SelectModalityName,
					SelectProcedureStepScheduledStartTime
                };

		private static readonly HqlJoin[] WorklistJoins
			= {
                JoinProcedure,
                JoinProcedureType,
                JoinOrder,
                JoinDiagnosticService,
                JoinVisit,
                JoinPatient,
                JoinPatientProfile,
				
				LeftJoinVisitLocation,
				LeftJoinModality,
				LeftJoinPerformingFacility,
				LeftJoinOrderingPractitioner
              };

		private static readonly HqlFrom WorklistFrom = new HqlFrom("ModalityProcedureStep", "ps", WorklistJoins);

		#endregion

		#region IMwlItemBroker Members

		public IList<WorklistItem> GetWorklistItems(IEnumerable<MwlItemSearchCriteria> where, IMwlQueryContext qc)
		{
			HqlProjectionQuery query = BuildMwlQuery(where, qc, false);
			IList<WorklistItem> items = DoQuery(query);
			return items;
		}

		public int CountWorklistItems(IEnumerable<MwlItemSearchCriteria> where, IMwlQueryContext qc)
		{
			HqlProjectionQuery query = BuildMwlQuery(where, qc, true);
			return DoQueryCount(query);
		}

		#endregion

		#region Helpers

		private HqlProjectionQuery BuildMwlQuery(IEnumerable<MwlItemSearchCriteria> where, IMwlQueryContext qc, bool countQuery)
		{
			HqlProjectionQuery query = new HqlProjectionQuery(WorklistFrom, countQuery ? WorklistCountProjection : WorklistProjections);
			AddConditions(query, where);

			// add paging if not a count query
			if (!countQuery)
			{
				query.Page = qc.Page;
			}

			return query;
		}

		private void AddConditions(HqlQuery query, IEnumerable<MwlItemSearchCriteria> where)
		{
			HqlOr or = new HqlOr();
			foreach (MwlItemSearchCriteria c in where)
			{
				HqlAnd and = new HqlAnd();
				foreach (KeyValuePair<string, SearchCriteria> kvp in c.SubCriteria)
				{
					string alias;
					if (MapCriteriaKeyToHql(kvp.Key, out alias))
						and.Conditions.AddRange(HqlCondition.FromSearchCriteria(alias, kvp.Value));
				}
				if (and.Conditions.Count > 0)
					or.Conditions.Add(and);
			}

			if (or.Conditions.Count > 0)
				query.Conditions.Add(or);

			query.Conditions.Add(ConditionActiveProcedureStep);
			query.Conditions.Add(ConditionProfileInformationAuthority);
			query.Sorts.Add(SortByProcedureStepScheduledStartTime);
		}

		private IList<WorklistItem> DoQuery(HqlQuery query)
		{
			IList<object[]> list = ExecuteHql<object[]>(query);
			IList<WorklistItem> results = new List<WorklistItem>();
			foreach (object[] tuple in list)
			{
				WorklistItem item = (WorklistItem)Activator.CreateInstance(typeof(WorklistItem), tuple);
				results.Add(item);
			}

			return results;
		}

		private int DoQueryCount(HqlQuery query)
		{
			return (int)ExecuteHqlUnique<long>(query);
		}

		private bool MapCriteriaKeyToHql(string criteriaKey, out string alias)
		{
			return _mapCriteriaKeyToHql.TryGetValue(criteriaKey, out alias);
		}

		#endregion
	}
}
