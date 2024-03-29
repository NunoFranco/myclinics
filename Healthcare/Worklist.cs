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
using System.Collections;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;
using Iesi.Collections.Generic;
using ClearCanvas.Enterprise.Hibernate;

namespace ClearCanvas.Healthcare
{
    /// <summary>
    /// Worklist entity.  Represents a worklist.
    /// </summary>
    [UniqueKey("WorklistUniqueKey", new string[] { "Name", "FullClassName", "Owner.Staff", "Owner.Group" })]
    public abstract class Worklist : Entity, IWorklist
    {
       
        /// <summary>
        /// Defines values for how a worklist is ordered in terms of which items are given priority
        /// when the full worklist cannot be displayed.
        /// </summary>
        protected enum WorklistOrdering
        {
            /// <summary>
            /// Ensure the oldest items are given priority.
            /// </summary>
            PrioritizeOldestItems,

            /// <summary>
            /// Ensure the newest items are given priority.
            /// </summary>
            PrioritizeNewestItems
        }

        #region Static members

        /// <summary>
        /// Gets the logical class name for the specified worklist class, which may or may not be identical
        /// to its .NET class name.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static string GetClassName(Type worklistClass)
        {
            // could use a logical class name here to decouple from the actual .NET class name,
            // but is it worth the added complexity?
            return worklistClass.Name;
        }

        /// <summary>
        /// Gets the procedure-type group class for the specified worklist class, as specified by
        /// the <see cref="WorklistProcedureTypeGroupClassAttribute"/>.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static Type GetProcedureTypeGroupClass(Type worklistClass)
        {
            WorklistProcedureTypeGroupClassAttribute a =
                AttributeUtils.GetAttribute<WorklistProcedureTypeGroupClassAttribute>(worklistClass, true);
            return a == null ? null : a.ProcedureTypeGroupClass;
        }

        /// <summary>
        /// Gets the category for the specified worklist class, as specified by
        /// the <see cref="WorklistCategoryAttribute"/>, or null if not specified.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static string GetCategory(Type worklistClass)
        {
            WorklistCategoryAttribute a =
                AttributeUtils.GetAttribute<WorklistCategoryAttribute>(worklistClass, true);
            if(a == null)
                return null;

            ResourceResolver resolver = new ResourceResolver(worklistClass, true);
            return resolver.LocalizeString(a.Category);
        }

        /// <summary>
        /// Gets the display name for the specified worklist class, obtained either from
        /// the <see cref="WorklistClassDisplayNameAttribute"/>, otherwise via the
        /// <see cref="TerminologyTranslator"/> class.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static string GetDisplayName(Type worklistClass)
        {
            WorklistClassDisplayNameAttribute a =
               AttributeUtils.GetAttribute<WorklistClassDisplayNameAttribute>(worklistClass, true);

            if (a != null)
            {
                ResourceResolver resolver = new ResourceResolver(worklistClass, true);
                return resolver.LocalizeString(a.DisplayName);
            }
            else
                return TerminologyTranslator.Translate(worklistClass);
        }

        /// <summary>
        /// Gets the description for the specified worklist class, as specified by
        /// the <see cref="WorklistCategoryAttribute"/>, or null if not specified.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static string GetDescription(Type worklistClass)
        {
            WorklistClassDescriptionAttribute a =
                AttributeUtils.GetAttribute<WorklistClassDescriptionAttribute>(worklistClass, true);
            if (a == null)
                return null;

            ResourceResolver resolver = new ResourceResolver(worklistClass, true);
            return resolver.LocalizeString(a.Description);
        }

        /// <summary>
        /// Gets a value indicating whether the specified worklist class supports time-filters, as specified by
        /// the <see cref="WorklistSupportsTimeFilterAttribute"/>.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static bool GetSupportsTimeFilter(Type worklistClass)
        {
            WorklistSupportsTimeFilterAttribute a =
                AttributeUtils.GetAttribute<WorklistSupportsTimeFilterAttribute>(worklistClass, true);
            return a == null ? false : a.SupportsTimeFilter;
        }

        /// <summary>
        /// Gets a value indicating whether the specified worklist class supports time-filters, as specified by
        /// the <see cref="WorklistSupportsTimeFilterAttribute"/>.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static bool GetSupportsReportingStaffRoleFilter(Type worklistClass)
        {
            WorklistSupportsReportingStaffRoleFilterAttribute a =
                AttributeUtils.GetAttribute<WorklistSupportsReportingStaffRoleFilterAttribute>(worklistClass, true);
            return a == null ? false : a.SupportsReportingStaffRoleFilter;
        }

        /// <summary>
        /// Gets a value indicating whether the specified worklist class behaves as a singleton, as specified by
        /// the <see cref="StaticWorklistAttribute"/>.
        /// </summary>
        /// <param name="worklistClass"></param>
        /// <returns></returns>
        public static bool GetIsStatic(Type worklistClass)
        {
            StaticWorklistAttribute a =
                AttributeUtils.GetAttribute<StaticWorklistAttribute>(worklistClass, true);
            return a == null ? false : a.IsSingleton;
        }

        #endregion

        private string _name;
        private string _description;
        private WorklistProcedureTypeGroupFilter _procedureTypeGroupFilter;
        private WorklistFacilityFilter _facilityFilter;
        private WorklistPatientClassFilter _patientClassFilter;
        private WorklistPatientLocationFilter _patientLocationFilter;
        private WorklistOrderPriorityFilter _orderPriorityFilter;
        private WorklistPractitionerFilter _orderingPractitionerFilter;
        private WorklistPortableFilter _portableFilter;
        private WorklistTimeFilter _timeFilter;

        private ISet<Staff> _staffSubscribers;
        private ISet<StaffGroup> _groupSubscribers;

        private WorklistOwner _owner;
        public virtual Facility Clinic { get; set; }
        /// <summary>
        /// No-args constructor required by NHibernate.
        /// </summary>
        public Worklist(Facility f)
        {
            Clinic = f;
            _owner = WorklistOwner.Admin;   // admin owned by default
            _staffSubscribers = new HashedSet<Staff>();
            _groupSubscribers = new HashedSet<StaffGroup>();

            _procedureTypeGroupFilter = new WorklistProcedureTypeGroupFilter();
            _facilityFilter = new WorklistFacilityFilter();
            _patientClassFilter = new WorklistPatientClassFilter();
            _patientLocationFilter = new WorklistPatientLocationFilter();
            _orderPriorityFilter = new WorklistOrderPriorityFilter();
            _orderingPractitionerFilter = new WorklistPractitionerFilter();
            _portableFilter = new WorklistPortableFilter();
            _timeFilter = new WorklistTimeFilter();
        }
        public Worklist()
        {
        }
        /// <summary>
        /// Gets the logical name of this class, which may or may not be the same as its .NET class name.
        /// </summary>
        public virtual string ClassName
        {
            get { return GetClassName(this.GetClass()); }
        }

        #region Persistent Properties


        /// <summary>
        /// Gets the fully-qualified .NET class name of this worklist instance.
        /// </summary>
        //NOTE: this property is persistent only for the purpose of enforcing the unique-key across Name and ClassName
        //there is no need to persist the class name otherwise
        [PersistentProperty]
        [Required]
        public virtual string FullClassName
        {
            get { return this.GetClass().FullName; }
            protected set
            {
                // do nothing
            }
        }

        /// <summary>
        /// Gets or sets the name of the worklist instance.
        /// </summary>
        [PersistentProperty]
        [Required]
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the description of the worklist instance.
        /// </summary>
        [PersistentProperty]
        public virtual string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// Gets or sets the owner of the worklist.
        /// </summary>
        [PersistentProperty]
        public virtual WorklistOwner Owner
        {
            get { return _owner == null ? WorklistOwner.Admin : _owner; }
            set
            {
                if (!Equals(_owner, value))
                {
                    _owner = value;

                    // if the owner is other than Admin, then the subscribers collections
                    // should contain only 1 value between them (the owner)
                    if (_owner != null && !_owner.IsAdminOwner)
                    {
                        _staffSubscribers.Clear();
                        _groupSubscribers.Clear();

                        if (_owner.IsStaffOwner)
                            _staffSubscribers.Add(_owner.Staff);
                        else if (_owner.IsGroupOwner)
                            _groupSubscribers.Add(_owner.Group);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the set of <see cref="Staff"/> that subscribe to this worklist.
        /// </summary>
        [PersistentProperty]
        public virtual ISet<Staff> StaffSubscribers
        {
            get { return _staffSubscribers; }
            protected set { _staffSubscribers = value; }
        }

        /// <summary>
        /// Gets the set of <see cref="StaffGroup"/>s that subscribe to this worklist.
        /// </summary>
        [PersistentProperty]
        public virtual ISet<StaffGroup> GroupSubscribers
        {
            get { return _groupSubscribers; }
            protected set { _groupSubscribers = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistProcedureTypeGroupFilter"/>.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistProcedureTypeGroupFilter ProcedureTypeGroupFilter
        {
            get { return _procedureTypeGroupFilter; }
            protected set { _procedureTypeGroupFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistFacilityFilter"/>.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistFacilityFilter FacilityFilter
        {
            get { return _facilityFilter; }
            protected set { _facilityFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistPatientClassFilter"/>.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistPatientClassFilter PatientClassFilter
        {
            get { return _patientClassFilter; }
            protected set { _patientClassFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistPatientLocationFilter"/>.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistPatientLocationFilter PatientLocationFilter
        {
            get { return _patientLocationFilter; }
            protected set { _patientLocationFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistOrderPriorityFilter"/>.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistOrderPriorityFilter OrderPriorityFilter
        {
            get { return _orderPriorityFilter; }
            protected set { _orderPriorityFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistPractitionerFilter"/> for the ordering practitioner.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistPractitionerFilter OrderingPractitionerFilter
        {
            get { return _orderingPractitionerFilter; }
            protected set { _orderingPractitionerFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistPortableFilter"/>.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistPortableFilter PortableFilter
        {
            get { return _portableFilter; }
            protected set { _portableFilter = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="WorklistTimeFilter"/>.
        /// </summary>
        [PersistentProperty]
        [EmbeddedValue]
        public virtual WorklistTimeFilter TimeFilter
        {
            get { return _timeFilter; }
            protected set { _timeFilter = value; }
        }

        #endregion

        #region Abstract and overridable members

        /// <summary>
        /// Gets the list of worklist items in this worklist.
        /// </summary>
        /// <param name="wqc"></param>
        /// <returns></returns>
        public abstract IList GetWorklistItems(IWorklistQueryContext wqc);

        /// <summary>
        /// Gets the number of worklist items in this worklist.
        /// </summary>
        /// <param name="wqc"></param>
        /// <returns></returns>
        public abstract int GetWorklistItemCount(IWorklistQueryContext wqc);

        /// <summary>
        /// Gets the criteria that define the invariant aspects of this worklist.
        /// </summary>
        /// <param name="wqc"></param>
        /// <returns></returns>
        protected abstract WorklistItemSearchCriteria[] GetInvariantCriteriaCore(IWorklistQueryContext wqc);

        #endregion

        #region Helpers

        /// <summary>
        /// Gets the criteria that define the invariant aspects of this worklist.
        /// </summary>
        /// <param name="wqc"></param>
        /// <remarks>
        /// This method is called by the worklist brokers and is not intended for use by application code.
        /// </remarks>
        /// <returns></returns>
        public WorklistItemSearchCriteria[] GetInvariantCriteria(IWorklistQueryContext wqc)
        {
            WorklistItemSearchCriteria[] criteria = GetInvariantCriteriaCore(wqc);

            // augment the criteria with the downtime flag
            foreach (WorklistItemSearchCriteria criterion in criteria)
            {
                criterion.Procedure.DowntimeRecoveryMode.EqualTo(wqc.DowntimeRecoveryMode);
            }
            return criteria;
        }

        protected void ApplyTimeCriteria(WorklistItemSearchCriteria criteria, WorklistTimeField timeField, WorklistTimeRange defaultValue, WorklistOrdering ordering, IWorklistQueryContext wqc)
        {
            criteria.TimeField = timeField;
            ISearchCondition searchCondition = timeField.GetSearchCondition(criteria);
            ApplyTimeRange(searchCondition, defaultValue, ordering, wqc);
        }

        /// <summary>
        /// Applies the time-range for this worklist to the specified search-condition.
        /// </summary>
        /// <remarks>
        /// If the <see cref="TimeFilter"/> is enabled, the range specified by the filter is applied.
        /// If the filter is not enabled, then the specified <paramref name="defaultValue"/> is applied.
        /// The <paramref name="defaultValue"/> may be null, in which case no time range is applied by default.
        /// </remarks>
        /// <param name="condition"></param>
        /// <param name="defaultValue"></param>
        /// <param name="ordering"></param>
        /// <param name="wqc"></param>
        private void ApplyTimeRange(ISearchCondition condition, WorklistTimeRange defaultValue, WorklistOrdering ordering, IWorklistQueryContext wqc)
        {
            // apply ordering
            if (ordering == WorklistOrdering.PrioritizeOldestItems)
                condition.SortAsc(0);
            else
                condition.SortDesc(0);

            // apply range filtering, if supported by this class
            // note: time filter is not applied in downtime recovery mode
            if (GetSupportsTimeFilter(this.GetClass()) && !wqc.DowntimeRecoveryMode)
            {
                WorklistTimeRange range = _timeFilter.IsEnabled ? _timeFilter.Value : defaultValue;
                if (range != null)
                    range.Apply(condition, Platform.Time);
            }
        }

        #endregion
    }
}