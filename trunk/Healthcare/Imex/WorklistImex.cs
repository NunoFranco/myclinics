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
using System.Runtime.Serialization;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Imex;
using ClearCanvas.Healthcare.Brokers;

namespace ClearCanvas.Healthcare.Imex
{
    [ExtensionOf(typeof(XmlDataImexExtensionPoint))]
    [ImexDataClass("Worklist")]
    public class WorklistImex : XmlEntityImex<Worklist, WorklistImex.WorklistData>
    {
        #region Data Contracts

        [DataContract]
        public class WorklistData
        {
            [DataContract]
            public class StaffSubscriberData
            {
                [DataMember]
                public string StaffId;
            }

           
            [DataContract]
            public class GroupSubscriberData
            {
                [DataMember]
                public string StaffGroupName;
            }

            [DataContract]
            public abstract class FilterData
            {
                [DataMember]
                public bool Enabled;
            }

            [DataContract]
            public class SingleValuedFilterData<TValue> : FilterData
            {
                [DataMember]
                public TValue Value;
            }

            [DataContract]
            public class MultiValuedFilterData<TValue> : FilterData
            {
                public MultiValuedFilterData()
                {
                    this.Values = new List<TValue>();
                }

                [DataMember]
                public List<TValue> Values;
            }

            [DataContract]
            public class ProcedureTypeGroupData
            {
                [DataMember]
                public string Name;

                [DataMember]
                public string Class;
            }

            [DataContract]
            public class LocationData
            {
                public LocationData()
                {
                }

                public LocationData(string id)
                {
                    this.Id = id;
                }

                [DataMember]
                public string Id;
            }

            [DataContract]
            public class PractitionerData
            {
                public PractitionerData()
                {

                }

                public PractitionerData(string familyName, string givenName, string licenseNumber, string billingNumber)
                {
                    FamilyName = familyName;
                    GivenName = givenName;
                    LicenseNumber = licenseNumber;
                    BillingNumber = billingNumber;
                }

                [DataMember]
                public string FamilyName;

                [DataMember]
                public string GivenName;

                [DataMember]
                public string LicenseNumber;

                [DataMember]
                public string BillingNumber;
            }

            [DataContract]
            public class EnumValueData
            {
                public EnumValueData()
                {

                }

                public EnumValueData(string code,ClinicData c)
                {
                    this.Code = code;
                    clinic = c;
                }

                [DataMember]
                public string Code;

                [DataMember]
                public ClinicData  clinic;
            }

            [DataContract]
            public class FacilitiesFilterData : MultiValuedFilterData<EnumValueData>
            {
                public FacilitiesFilterData()
                {

                }

                public FacilitiesFilterData(MultiValuedFilterData<EnumValueData> x)
                {
                    this.Enabled = x.Enabled;
                    this.Values = x.Values;
                }

                [DataMember]
                public bool IncludeWorkingFacility;
            }

            [DataContract]
            public class StaffFilterData : MultiValuedFilterData<StaffSubscriberData>
            {
                public StaffFilterData()
                {
                }

                public StaffFilterData(MultiValuedFilterData<StaffSubscriberData> s)
                {
                    this.Enabled = s.Enabled;
                    this.Values = s.Values;
                }

                [DataMember]
                public bool IncludeCurrentStaff;
            }

            [DataContract]
            public class TimeRangeData
            {
                public TimeRangeData()
                {
                }

                public TimeRangeData(WorklistTimeRange tr)
                {
                    this.Start = tr.Start == null ? null : new TimePointData(tr.Start);
                    this.End = tr.End == null ? null : new TimePointData(tr.End);
                }

                public WorklistTimeRange CreateTimeRange()
                {
                    return new WorklistTimeRange(
                        this.Start == null ? null : this.Start.CreateTimePoint(),
                        this.End == null ? null : this.End.CreateTimePoint());
                }

                [DataMember]
                public TimePointData Start;

                [DataMember]
                public TimePointData End;
            }

            [DataContract]
            public class TimePointData
            {
                public TimePointData()
                {
                }

                public TimePointData(WorklistTimePoint tp)
                {
                    this.FixedValue = tp.IsFixed ? tp.FixedValue : null;
                    this.RelativeValue = tp.IsRelative ? tp.RelativeValue.Value.Ticks.ToString() : null;
                    this.Resolution = tp.Resolution;
                }

                public WorklistTimePoint CreateTimePoint()
                {
                    if (this.FixedValue != null)
                        return new WorklistTimePoint(this.FixedValue.Value, this.Resolution);
                    else if (this.RelativeValue != null)
                        return new WorklistTimePoint(TimeSpan.FromTicks(Int64.Parse(this.RelativeValue)), this.Resolution);
                    else
                        return null;
                }

                [DataMember]
                public DateTime? FixedValue;

                [DataMember]
                public string RelativeValue;

                [DataMember]
                public long Resolution;
            }

            [DataContract]
            public class FiltersData
            {
                public FiltersData()
                {
                    this.ProcedureTypeGroups = new MultiValuedFilterData<ProcedureTypeGroupData>();
                    this.Facilities = new FacilitiesFilterData();
                    this.OrderPriorities = new MultiValuedFilterData<EnumValueData>();
                    this.OrderingPractitioners = new MultiValuedFilterData<PractitionerData>();
                    this.PatientClasses = new MultiValuedFilterData<EnumValueData>();
                    this.PatientLocations = new MultiValuedFilterData<LocationData>();
                    this.Portable = new SingleValuedFilterData<bool>();
                    this.TimeWindow = new SingleValuedFilterData<TimeRangeData>();
                    this.InterpretedByStaff = new StaffFilterData();
                    this.TranscribedByStaff = new StaffFilterData();
                    this.VerifiedByStaff = new StaffFilterData();
                    this.SupervisedByStaff = new StaffFilterData();
                }

                [DataMember]
                public MultiValuedFilterData<ProcedureTypeGroupData> ProcedureTypeGroups;

                [DataMember]
                public FacilitiesFilterData Facilities;

                [DataMember]
                public MultiValuedFilterData<EnumValueData> OrderPriorities;

                [DataMember]
                public MultiValuedFilterData<PractitionerData> OrderingPractitioners;

                [DataMember]
                public MultiValuedFilterData<EnumValueData> PatientClasses;

                [DataMember]
                public MultiValuedFilterData<LocationData> PatientLocations;

                [DataMember]
                public SingleValuedFilterData<bool> Portable;

                [DataMember]
                public SingleValuedFilterData<TimeRangeData> TimeWindow;

                [DataMember]
                public StaffFilterData InterpretedByStaff;

                [DataMember]
                public StaffFilterData TranscribedByStaff;

                [DataMember]
                public StaffFilterData VerifiedByStaff;

                [DataMember]
                public StaffFilterData SupervisedByStaff;
            }

            public WorklistData()
            {
                this.Filters = new FiltersData();
            }

            [DataMember]
            public string Name;

            [DataMember]
            public string Class;

            [DataMember]
            public string Description;

            [DataMember]
            public FiltersData Filters;

            [DataMember]
            public List<StaffSubscriberData> StaffSubscribers;

            [DataMember]
            public List<GroupSubscriberData> GroupSubscribers;

            [DataMember]
            public ClinicData Clinic;
        }


        #endregion

        #region Overrides

        protected override IList<Worklist> GetItemsForExport(IReadContext context, int firstRow, int maxRows)
        {
            WorklistSearchCriteria where = new WorklistSearchCriteria();
            where.Name.SortAsc(0);
            where.FullClassName.SortAsc(1);
            return context.GetBroker<IWorklistBroker>().Find(where, new SearchResultPage(firstRow, maxRows));
        }

        protected override WorklistData Export(Worklist worklist, IReadContext context)
        {

            Facility Currentclinic = worklist.Clinic;
            WorklistData data = new WorklistData();
            data.Class = worklist.GetClass().FullName;
            data.Name = worklist.Name;
            data.Description = worklist.Description;

            data.StaffSubscribers = CollectionUtils.Map<Staff, WorklistData.StaffSubscriberData>(
                worklist.StaffSubscribers,
                delegate(Staff staff)
                {
                    WorklistData.StaffSubscriberData s = new WorklistData.StaffSubscriberData();
                    s.StaffId = staff.Id;
                    return s;
                });

            data.GroupSubscribers = CollectionUtils.Map<StaffGroup, WorklistData.GroupSubscriberData>(
                worklist.GroupSubscribers,
                delegate(StaffGroup group)
                {
                    WorklistData.GroupSubscriberData s = new WorklistData.GroupSubscriberData();
                    s.StaffGroupName = group.Name;
                    return s;
                });

            ExportFilter(
                worklist.ProcedureTypeGroupFilter,
                data.Filters.ProcedureTypeGroups,
                delegate(ProcedureTypeGroup group)
                {
                    WorklistData.ProcedureTypeGroupData s = new WorklistData.ProcedureTypeGroupData();
                    s.Class = group.GetClass().FullName;
                    s.Name = group.Name;
                    return s;
                });

            data.Filters.Facilities.IncludeWorkingFacility = worklist.FacilityFilter.IncludeWorkingFacility;
            ExportFilter(
                worklist.FacilityFilter,
                data.Filters.Facilities,
                delegate(Facility item) { return new WorklistData.EnumValueData(item.Code , new ClinicData(Currentclinic)); });



            ExportFilter(worklist.OrderPriorityFilter, data.Filters.OrderPriorities,
                delegate(OrderPriorityEnum item) { return new WorklistData.EnumValueData(item.Code, new ClinicData(Currentclinic)); });

            ExportFilter(worklist.OrderingPractitionerFilter, data.Filters.OrderingPractitioners,
                delegate(ExternalPractitioner item)
                {
                    return new WorklistData.PractitionerData(
                        item.Name.FamilyName, item.Name.GivenName, item.LicenseNumber, item.BillingNumber);
                });

            ExportFilter(worklist.PatientClassFilter, data.Filters.PatientClasses,
                delegate(PatientClassEnum item) { return new WorklistData.EnumValueData(item.Code, new ClinicData(Currentclinic)); });
            ExportFilter(worklist.PatientLocationFilter, data.Filters.PatientLocations,
                delegate(Location item) { return new WorklistData.LocationData(item.Id); });

            data.Filters.Portable.Enabled = worklist.PortableFilter.IsEnabled;
            data.Filters.Portable.Value = worklist.PortableFilter.Value;

            //Bug #2429: don't forget to include the time filter
            data.Filters.TimeWindow.Enabled = worklist.TimeFilter.IsEnabled;
            data.Filters.TimeWindow.Value = worklist.TimeFilter.Value == null ? null :
                new WorklistData.TimeRangeData(worklist.TimeFilter.Value);

            if (Worklist.GetSupportsReportingStaffRoleFilter(worklist.GetClass()))
                ExportReportingWorklistFilters(data, worklist.As<ReportingWorklist>());

            return data;
        }

        private void ExportReportingWorklistFilters(WorklistData data, ReportingWorklist worklist)
        {
            ExportStaffFilter(worklist.InterpretedByStaffFilter, data.Filters.InterpretedByStaff);
            ExportStaffFilter(worklist.TranscribedByStaffFilter, data.Filters.TranscribedByStaff);
            ExportStaffFilter(worklist.VerifiedByStaffFilter, data.Filters.VerifiedByStaff);
            ExportStaffFilter(worklist.SupervisedByStaffFilter, data.Filters.SupervisedByStaff);
        }

        public void ExportStaffFilter(WorklistStaffFilter filter, WorklistData.StaffFilterData data)
        {
            ExportFilter(filter, data,
                delegate(Staff staff)
                {
                    WorklistData.StaffSubscriberData s = new WorklistData.StaffSubscriberData();
                    s.StaffId = staff.Id;
                    return s;
                });
            data.IncludeCurrentStaff = filter.IncludeCurrentStaff;
        }

        protected override void Import(WorklistData data, string clinicCode, IUpdateContext context)
        {
            Facility currentClinic = Common.GetClinic(clinicCode, context );
            Worklist worklist = LoadOrCreateWorklist(data.Name, data.Class, context);
            worklist.Description = data.Description;

            if (data.StaffSubscribers != null)
            {
                foreach (WorklistData.StaffSubscriberData s in data.StaffSubscribers)
                {
                    StaffSearchCriteria criteria = new StaffSearchCriteria();
                    criteria.Id.EqualTo(s.StaffId);

                    IList<Staff> staff = context.GetBroker<IStaffBroker>().Find(criteria);
                    if (staff.Count == 1)
                        worklist.StaffSubscribers.Add(CollectionUtils.FirstElement(staff));
                }
            }

            if (data.GroupSubscribers != null)
            {
                foreach (WorklistData.GroupSubscriberData s in data.GroupSubscribers)
                {
                    StaffGroupSearchCriteria criteria = new StaffGroupSearchCriteria();
                    criteria.Name.EqualTo(s.StaffGroupName);

                    IList<StaffGroup> groups = context.GetBroker<IStaffGroupBroker>().Find(criteria);
                    if (groups.Count == 1)
                        worklist.GroupSubscribers.Add(CollectionUtils.FirstElement(groups));
                }
            }

            ImportFilter(
                worklist.ProcedureTypeGroupFilter,
                data.Filters.ProcedureTypeGroups,
                delegate(WorklistData.ProcedureTypeGroupData s)
                {
                    ProcedureTypeGroupSearchCriteria criteria = new ProcedureTypeGroupSearchCriteria();
                    criteria.Name.EqualTo(s.Name);

                    IProcedureTypeGroupBroker broker = context.GetBroker<IProcedureTypeGroupBroker>();
                    return CollectionUtils.FirstElement(broker.Find(criteria, ProcedureTypeGroup.GetSubClass(s.Class, context)));
                });

            //Bug #2284: don't forget to set the IncludeWorkingFacility property
            worklist.FacilityFilter.IncludeWorkingFacility = data.Filters.Facilities.IncludeWorkingFacility;

            ImportFilter(
                worklist.FacilityFilter,
                data.Filters.Facilities,
                delegate(WorklistData.EnumValueData s)
                {
                    FacilitySearchCriteria criteria = new FacilitySearchCriteria();
                    criteria.Code.EqualTo(s.Code);

                    IFacilityBroker broker = context.GetBroker<IFacilityBroker>();
                    return CollectionUtils.FirstElement(broker.Find(criteria));
                });

            ImportFilter(
                worklist.OrderPriorityFilter,
                data.Filters.OrderPriorities,
                delegate(WorklistData.EnumValueData s)
                {
                    IEnumBroker broker = context.GetBroker<IEnumBroker>();
                    return broker.Find<OrderPriorityEnum>(s.Code,(System.Guid ) currentClinic.OID );
                });

            ImportFilter(
                worklist.OrderingPractitionerFilter,
                data.Filters.OrderingPractitioners,
                delegate(WorklistData.PractitionerData s)
                {
                    ExternalPractitionerSearchCriteria criteria = new ExternalPractitionerSearchCriteria();
                    criteria.Name.FamilyName.EqualTo(s.FamilyName);
                    criteria.Name.GivenName.EqualTo(s.GivenName);

                    // these criteria may not be provided (the data may not existed when exported),
                    // but if available, they help to ensure the correct practitioner is being mapped
                    if (!string.IsNullOrEmpty(s.BillingNumber))
                        criteria.BillingNumber.EqualTo(s.BillingNumber);
                    if (!string.IsNullOrEmpty(s.LicenseNumber))
                        criteria.LicenseNumber.EqualTo(s.LicenseNumber);

                    IExternalPractitionerBroker broker = context.GetBroker<IExternalPractitionerBroker>();
                    return CollectionUtils.FirstElement(broker.Find(criteria));
                });

            ImportFilter(
                worklist.PatientClassFilter,
                data.Filters.PatientClasses,
                delegate(WorklistData.EnumValueData s)
                {
                    IEnumBroker broker = context.GetBroker<IEnumBroker>();
                    return broker.Find<PatientClassEnum>(s.Code,(System.Guid )currentClinic.OID );
                });

            ImportFilter(
                worklist.PatientLocationFilter,
                data.Filters.PatientLocations,
                delegate(WorklistData.LocationData s)
                {
                    LocationSearchCriteria criteria = new LocationSearchCriteria();
                    criteria.Id.EqualTo(s.Id);

                    ILocationBroker broker = context.GetBroker<ILocationBroker>();
                    return CollectionUtils.FirstElement(broker.Find(criteria));
                });

            worklist.PortableFilter.IsEnabled = data.Filters.Portable.Enabled;
            worklist.PortableFilter.Value = data.Filters.Portable.Value;

            //Bug #2429: don't forget to include the time filter
            worklist.TimeFilter.IsEnabled = data.Filters.TimeWindow.Enabled;
            worklist.TimeFilter.Value = data.Filters.TimeWindow == null || data.Filters.TimeWindow.Value == null
                                            ? null
                                            : data.Filters.TimeWindow.Value.CreateTimeRange();

            if (Worklist.GetSupportsReportingStaffRoleFilter(worklist.GetClass()))
                ImportReportingWorklistFilters(data, worklist.As<ReportingWorklist>(), context);
        }

        private void ImportReportingWorklistFilters(WorklistData data, ReportingWorklist worklist, IUpdateContext context)
        {
            ImportStaffFilter(worklist.InterpretedByStaffFilter, data.Filters.InterpretedByStaff, context);
            ImportStaffFilter(worklist.TranscribedByStaffFilter, data.Filters.TranscribedByStaff, context);
            ImportStaffFilter(worklist.VerifiedByStaffFilter, data.Filters.VerifiedByStaff, context);
            ImportStaffFilter(worklist.SupervisedByStaffFilter, data.Filters.SupervisedByStaff, context);
        }

        private void ImportStaffFilter(WorklistStaffFilter filter, WorklistData.StaffFilterData staff, IUpdateContext context)
        {
            ImportFilter(filter, staff,
                delegate(WorklistData.StaffSubscriberData s)
                {
                    StaffSearchCriteria criteria = new StaffSearchCriteria();
                    criteria.Id.EqualTo(s.StaffId);

                    IStaffBroker broker = context.GetBroker<IStaffBroker>();
                    return CollectionUtils.FirstElement(broker.Find(criteria));
                });
            filter.IncludeCurrentStaff = staff.IncludeCurrentStaff;
        }

        #endregion

        #region Helpers

        private void ExportFilter<TDomain, TData>(WorklistMultiValuedFilter<TDomain> filter, WorklistData.MultiValuedFilterData<TData> data,
            Converter<TDomain, TData> converter)
        {
            data.Enabled = filter.IsEnabled;
            data.Values = CollectionUtils.Map(filter.Values, converter);
        }

        private void ImportFilter<TDomain, TData>(WorklistMultiValuedFilter<TDomain> filter, WorklistData.MultiValuedFilterData<TData> data,
            Converter<TData, TDomain> converter)
        {
            if (data != null)
            {
                filter.IsEnabled = data.Enabled;
                foreach (TData i in data.Values)
                {
                    TDomain value = converter(i);
                    if (value != null)
                        filter.Values.Add(value);
                }
            }
        }

        private Worklist LoadOrCreateWorklist(string name, string worklistClassName, IPersistenceContext context)
        {
            Worklist worklist;

            try
            {
                worklist = context.GetBroker<IWorklistBroker>().FindOne(name, worklistClassName);
            }
            catch (EntityNotFoundException)
            {
                worklist = WorklistFactory.Instance.CreateWorklist(worklistClassName);
                worklist.Name = name;

                context.Lock(worklist, DirtyState.New);
            }

            return worklist;
        }

        #endregion

    }
}