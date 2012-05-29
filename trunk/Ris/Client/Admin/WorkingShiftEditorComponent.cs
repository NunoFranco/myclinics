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
using ClearCanvas.Desktop;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin.WorkingShiftAdmin;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Desktop.Tables;

namespace ClearCanvas.Ris.Client.Admin
{
    /// <summary>
    /// Extension point for views onto <see cref="WorkingShiftEditorComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class WorkingShiftEditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// WorkingShiftEditorComponent class.
    /// </summary>
    [AssociateView(typeof(WorkingShiftEditorComponentViewExtensionPoint))]
    public class WorkingShiftEditorComponent : ApplicationComponent
    {

        private readonly EntityRef _WorkingShiftRef;
        private readonly bool _isNew;
        private WorkingShiftDetail _detail;
        private WorkingShiftSummary _WorkingShiftSummary;
        public WorkingShiftSummary WSSummary { get { return _WorkingShiftSummary; } }
        public WorkingShiftDetail Detail { get { return _detail; } set { _detail = value; } }


        class StaffTable : Table<StaffSummary >
        {
            public StaffTable()
            {
                this.Columns.Add(new TableColumn<StaffSummary, string>(SR.StaffIDColumnName,
               delegate(StaffSummary item) { return item.StaffId ; }));
                this.Columns.Add(new TableColumn<StaffSummary, string>(SR.StaffNameColumnName,
                    delegate(StaffSummary item) { return item.Name.ToString() ; }));
           
                this.Columns.Add(new TableColumn<StaffSummary, string>(SR.StaffTypeColumnName,
                    delegate(StaffSummary item) { return item.StaffType.Value ; }));
            }
        }

        private readonly bool _readOnly;
        private readonly StaffTable _availablestaffs;
        private readonly StaffTable _selectedstaffs;
        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkingShiftEditorComponent()
        {
            _isNew = true;
            _availablestaffs = new StaffTable();
            _selectedstaffs = new StaffTable();
        }

        public WorkingShiftEditorComponent(EntityRef workinfShiftRef)
        {
            _WorkingShiftRef = workinfShiftRef;
            _isNew = false ;
            _availablestaffs = new StaffTable();
            _selectedstaffs = new StaffTable();
        }

        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            
            Platform.GetService<IWorkingShiftAdminService>(
                delegate(IWorkingShiftAdminService service)
            {
                LoadWorkingShiftEditorFormDataResponse  response = service.LoadWorkingShiftEditorFormData (
                    new LoadWorkingShiftEditorFormDataRequest(LoginSession.Current.WorkingFacility.FacilityRef)
                    );
              
                _availablestaffs.Items.AddRange( response.staffs);
            });
            if (_isNew)
            {
                _detail = new WorkingShiftDetail();
            }
            else
            {
                Platform.GetService<IWorkingShiftAdminService>(
                    delegate(IWorkingShiftAdminService service)
                    {
                        LoadWorkingShiftForEditResponse response = service.LoadWorkingShiftForEdit(
                            new LoadWorkingShiftForEditRequest(_WorkingShiftRef));
                        _detail = response.WorkingShiftdetail ;
                        _selectedstaffs.Items.AddRange(_detail.Doctors);
                    });
            }

            // TODO prepare the component for its live phase
            base.Start();
        }

        /// <summary>
        /// Called by the host when the application component is being terminated.
        /// </summary>
        public override void Stop()
        {
            // TODO prepare the component to exit the live phase
            // This is a good place to do any clean up
            base.Stop();
        }
        public ITable AvailableStaffTable
        {
            get { return _availablestaffs; }
        }

        public ITable SelectedStaffTable
        {
            get { return _selectedstaffs; }
        }
        public void ItemsAddedOrRemoved()
        {
            this.Modified = true;
        }
        #region Presentation Model
        public string Name
        {
            get { return _detail.Name; }
            set
            {
                _detail.Name = value;
                this.Modified = true;
            }
        }
        public string Description
        {
            get { return _detail.Description ; }
            set
            {
                _detail.Description  = value;
                this.Modified = true;
            }
        }
        public DateTime ValidFromDate
        {
            get { return _detail.ValidFromDate; }
            set
            {
                _detail.ValidFromDate = value;
                this.Modified = true;
            }
        }
        public DateTime ValidToDate
        {
            get { return _detail.ValidToDate; }
            set
            {
                _detail.ValidToDate = value;
                this.Modified = true;
            }
        }
        public DateTime StartTime
        {
            get { return _detail.StartTime; }
            set
            {
                _detail.StartTime = value;
                this.Modified = true;
            }
        }
        public DateTime EndTime
        {
            get { return _detail.EndTime; }
            set
            {
                _detail.EndTime = value;
                this.Modified = true;
            }
        }

        public bool  WorkingOnSunday
        {
            get { return _detail.WorkingOnSunday; }
            set
            {
                _detail.WorkingOnSunday = value;
                this.Modified = true;
            }
        }
        public bool  WorkingOnMonday
        {
            get { return _detail.WorkingOnMonday; }
            set
            {
                _detail.WorkingOnMonday = value;
                this.Modified = true;
            }
        }
        public bool  WorkingOnTuesday
        {
            get { return _detail.WorkingOnTuesday ; }
            set
            {
                _detail.WorkingOnTuesday = value;
                this.Modified = true;
            }
        }
        public bool WorkingOnWednesday
        {
            get { return _detail.WorkingOnWednesday ; }
            set
            {
                _detail.WorkingOnWednesday = value;
                this.Modified = true;
            }
        }
        public bool  WorkingOnThursday
        {
            get { return _detail.WorkingOnThursday ; }
            set
            {
                _detail.WorkingOnThursday = value;
                this.Modified = true;
            }
        }
        public bool WorkingOnFriday
        {
            get { return _detail.WorkingOnFriday ; }
            set
            {
                _detail.WorkingOnFriday = value;
                this.Modified = true;
            }
        }
        public bool WorkingOnSaturday
        {
            get { return _detail.WorkingOnSaturday; }
            set
            {
                _detail.WorkingOnSaturday = value;
                this.Modified = true;
            }
        }
        public DateTime ExactDate
        {
            get { return _detail.PlanDate; }
            set
            {
                _detail.PlanDate = value;
                this.Modified = true;
            }
        }

        public bool AcceptEnabled
        {
            get { return this.Modified; }
        }

        public List<StaffSummary> Doctors
        {
            get { return _detail.Doctors; }
            set
            {
                _detail.Doctors = value;
                this.Modified = true;
            }
        }
        #endregion

        public void Cancel()
        {
            this.ExitCode = ApplicationComponentExitCode.None;
            Host.Exit();
        }

        public void Accept()
        {
            if (this.HasValidationErrors)
            {
                this.ShowValidation(true);
            }
            else
            {
                try
                {
                    SaveChanges();
                    this.Exit(ApplicationComponentExitCode.Accepted);
                }
                catch (Exception e)
                {
                    ExceptionHandler.Report(e, SR.ExceptionSaveWorkingShift, this.Host.DesktopWindow,
                        delegate()
                        {
                            this.ExitCode = ApplicationComponentExitCode.Error;
                            this.Host.Exit();
                        });
                }
            }
        }
        private void SaveChanges()
        {
            Platform.GetService<IWorkingShiftAdminService>(
                delegate(IWorkingShiftAdminService service)
                {
                    if (_isNew)
                    {
                        AddWorkingShiftResponse response = service.AddWorkingShift(new AddWorkingShiftRequest(_detail));
                        _WorkingShiftSummary = response.WorkingShift;
                    }
                    else
                    {
                        UpdateWorkingShiftResponse response = service.UpdateWorkingShift(new UpdateWorkingShiftRequest(_detail));
                        _WorkingShiftSummary = response.WorkingShift;
                    }
                });
        }
    }
}
