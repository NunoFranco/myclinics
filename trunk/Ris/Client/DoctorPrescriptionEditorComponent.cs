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
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.DoctorPrescription;

namespace ClearCanvas.Ris.Client
{
    /// <summary>
    /// Extension point for views onto <see cref="DoctorPrescriptionEditorComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class DoctorPrescriptionEditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// DoctorPrescriptionEditorComponent class.
    /// </summary>
    [AssociateView(typeof(DoctorPrescriptionEditorComponentViewExtensionPoint))]
    public class DoctorPrescriptionEditorComponent : ApplicationComponent
    {
        private readonly bool _isReadOnly;
        private DoctorPrescriptionDetail _detail;
        //private readonly DoctorPrescriptionDetail _prescription;
        private readonly List<ProcedureSummary> _medicinesChoices;
        private EntityRef _prescriptionRef;
        public DoctorPrescriptionSummary summary { get; set; }

        private bool _isNew;
        public DoctorPrescriptionEditorComponent()
        {
            _isNew = true;
        }

        public DoctorPrescriptionEditorComponent(EntityRef prescriptionRef, List<ProcedureSummary> medicineChoices)
        {

            _prescriptionRef = prescriptionRef;
            _medicinesChoices = medicineChoices;
            _isNew = false;
            //this.Validation.Add(new ValidationRule("ExpiryDate",
            //    delegate
            //    {
            //        var valid = _prescription.ValidRangeUntil == null || _prescription.ValidRangeUntil >= Platform.Time.Date;
            //        return new ValidationResult(valid, SR.MessageInvalidExpiryDate);
            //    }));
        }

        #region Presentation Model
        private readonly ProcedureTypeSummaryTable _availableMedicines;
        private readonly ProcedureTypeSummaryTable _selectedMedicines;
        public ITable AvailableMedicineTable
        {
            get { return _availableMedicines; }
        }

        public ITable SelectedMedicineTable
        {
            get { return _selectedMedicines; }
        }

        public void ItemsAddedOrRemoved()
        {
            this.Modified = true;
            NotifyPropertyChanged("Modified");
        }

        [ValidateNotNull]
        public string Name
        {
            get
            {
                return _detail.Name;
            }
            set
            {
                if (_detail.Name == value)
                    return;

                _detail.Name = value;

                NotifyPropertyChanged("Name");
                this.Modified = true;
            }
        }


        public string Description
        {
            get
            {
                return _detail.Description;
            }
            set
            {
                if (_detail.Description == value)
                    return;

                _detail.Description = value;

                NotifyPropertyChanged("Description");
                this.Modified = true;
            }
        }
        #endregion
        public void SaveChange()
        {
            Platform.GetService<IDoctorPrescriptionService>(delegate(IDoctorPrescriptionService service)
            {
                if (_isNew)
                    service.AddDoctorPrescription(new AddDoctorPrescriptionRequest(_detail));
                else
                    service.UpdateDoctorPrescription(new UpdateDoctorPrescriptionRequest(_detail));
            });
        }
        public bool IsReadOnly
        {
            get { return _isReadOnly; }
        }

        public void Accept()
        {
            if (this.HasValidationErrors)
            {
                this.ShowValidation(true);
            }
            else
            {
                SaveChange();
                this.ExitCode = ApplicationComponentExitCode.Accepted;
                Host.Exit();
            }
        }

        public void Cancel()
        {
            this.ExitCode = ApplicationComponentExitCode.None;
            Host.Exit();
        }

        public bool AcceptEnabled
        {
            get { return this.Modified; }
        }

        public event EventHandler AcceptEnabledChanged
        {
            add { this.ModifiedChanged += value; }
            remove { this.ModifiedChanged -= value; }
        }

        public override void Start()
        {
            Platform.GetService<IDoctorPrescriptionService>(
                 delegate(IDoctorPrescriptionService service)
                 {
                     if (_isNew)
                     {
                         _detail = new DoctorPrescriptionDetail();
                         _detail.Clinic = LoginSession.Current.WorkingFacility;
                         _detail.Medicines = new List<ProcedureTypeSummary>();
                     }
                     else
                     {


                         LoadDoctorPrescriptionForEditResponse response = service.LoadDoctorPrescriptionForEdit(
                             new LoadDoctorPrescriptionForEditRequest(_prescriptionRef));
                         _detail = response.DoctorPrescription;
                         _selectedMedicines.Items.AddRange(_detail.Medicines);
                     }
                     LoadDoctorPrescriptionEditorFormDataResponse r= service.LoadDoctorPrescriptionEditorFormData(new LoadDoctorPrescriptionEditorFormDataRequest());
                     _availableMedicines.Items.AddRange(r.Medicines);
                 });
            base.Start();
        }

    }
}
