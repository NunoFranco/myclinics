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
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Ris.Application.Common;

namespace ClearCanvas.Ris.Client
{
    /// <summary>
    /// Extension point for views onto <see cref="StaffClinicsEditorComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class StaffClinicsEditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// StaffClinicsEditorComponent class.
    /// </summary>
    [AssociateView(typeof(StaffClinicsEditorComponentViewExtensionPoint))]
    public class StaffClinicsEditorComponent : ApplicationComponent
    {
        public Enterprise.Common.EntityRef StaffRef { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        public StaffClinicsEditorComponent()
        {
        }

        class StaffFacilityTable : Table<FacilitySummary>
        {
            public StaffFacilityTable()
            {
                this.Columns.Add(new TableColumn<FacilitySummary, string>(SR.StaffFacilityColumnName,
                    delegate(FacilitySummary item) { return item.Name; }));
            }
        }

        private readonly bool _readOnly;
        private readonly StaffFacilityTable _availableFacilities;
        private readonly StaffFacilityTable _selectedFacilities;

        /// <summary>
        /// Protected constructor.
        /// </summary>
        protected StaffClinicsEditorComponent(bool readOnly)
            : this(new FacilitySummary[0], new FacilitySummary[0], readOnly)
        {
        }

        /// <summary>
        /// Constructs an editor to edit an existing staff profile
        /// </summary>
        public StaffClinicsEditorComponent(IList<FacilitySummary> facilities, IList<FacilitySummary> facilityChoices, bool readOnly)
        {
            _readOnly = readOnly;
            _selectedFacilities = new StaffFacilityTable();
            _availableFacilities = new StaffFacilityTable();

            Initialize(facilities, facilityChoices);
        }

        public IList<FacilitySummary> SelectedItems
        {
            get { return _selectedFacilities.Items; }
        }

        #region Presentation Model

        public bool ReadOnly
        {
            get { return _readOnly; }
        }

        public ITable AvailableFacilitiesTable
        {
            get { return _availableFacilities; }
        }

        public ITable SelectedFacilitiesTable
        {
            get { return _selectedFacilities; }
        }

        public void ItemsAddedOrRemoved()
        {
            this.Modified = true;
        }

        #endregion

        /// <summary>
        /// Protected method to re-initialize the component.
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="groupChoices"></param>
        protected void Initialize(IList<FacilitySummary> Facilities, IList<FacilitySummary> facilitiesChoices)
        {
            _selectedFacilities.Items.Clear();
            _selectedFacilities.Items.AddRange(Facilities);
            if (_selectedFacilities.Items.Count == 0)
                _selectedFacilities.Items.Add(LoginSession.Current.WorkingFacility);
            _availableFacilities.Items.Clear();
            _availableFacilities.Items.AddRange(CollectionUtils.Reject(facilitiesChoices,
                delegate(FacilitySummary x)
                {
                    return CollectionUtils.Contains(_selectedFacilities.Items,
                        delegate(FacilitySummary y) { return x.FacilityRef.Equals(y.FacilityRef, true); });
                }));
        }

    }

}
