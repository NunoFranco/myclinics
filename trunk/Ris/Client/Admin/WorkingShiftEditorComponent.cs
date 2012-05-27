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
        /// <summary>
        /// Constructor.
        /// </summary>
        public WorkingShiftEditorComponent()
        {
            _isNew = true;
        }

        public WorkingShiftEditorComponent(EntityRef workinfShiftRef)
        {
            _WorkingShiftRef = workinfShiftRef;
            _isNew = true;
        }

        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
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

        public bool AcceptEnabled
        {
            get { return this.Modified; }
        }

        public List<DoctorWorkingPlanSummary> Doctors
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
