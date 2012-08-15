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
using System.Collections;
using System.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Client;
using ClearCanvas.Material.Application.Common;
using ClearCanvas.Material.Application.Common.MaterialLots;
using ClearCanvas.Material.Application.Common.Contacts;


namespace ClearCanvas.Material.Client
{
    /// <summary>
    /// Extension point for views onto <see cref="MaterialLotEditorComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class MaterialLotEditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// MaterialLotEditorComponent class.
    /// </summary>
    [AssociateView(typeof(MaterialLotEditorComponentViewExtensionPoint))]
    public partial class MaterialLotEditorComponent : ApplicationComponent
    {
        public event EventHandler ItemAdded;
        public event EventHandler ItemUpdated;
        public bool IsCloseWhenSaved { get; set; }
        private EntityRef _ref;
        private MaterialLotDetail _detail;
        public ILookupHandler SupplierLookup;
        private bool _isNew;

        private MaterialLotSummary _summary;
        private List<MaterialLotSummary> _baseTypeChoices;

        public bool IsNew
        {
            get { return _isNew; }
            set
            {
                _isNew = value;
                ResetNew();
            }
        }
        void ResetNew()
        {
            _detail = new MaterialLotDetail();
            ReBindData();
        }
        public EntityRef MaterialLotRef
        {
            get { return _ref; }
            set
            {
                _ref = value;
                _isNew = false;
                Platform.GetService<IMaterialLotService>(
                                 delegate(IMaterialLotService service)
                                 {
                                     LoadMaterialLotForEditResponse response = service.LoadMaterialLotForEdit(
                                         new LoadMaterialLotForEditRequest(_ref));
                                     _detail = response.objDetail;
                                     //ItemsTable.Items.Clear();
                                     //ItemsTable.Items.AddRange(_detail.Medicines);
                                 });
                ReBindData();
            }
        }
        public void ReBindData()
        {
            NotifyPropertyChanged("Id");
            NotifyPropertyChanged("Description");
            NotifyPropertyChanged("InputDate");
            NotifyPropertyChanged("Deactivated");
            _isNew = true;
            this.Modified = false;
            NotifyAllPropertiesChanged();
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public MaterialLotEditorComponent()
        {
            _isNew = true;
            CustomConstructor();
        }

        public MaterialLotEditorComponent(EntityRef _objRef)
        {
            _isNew = false;
            _ref = _objRef;
            CustomConstructor();
        }

        /// <summary>
        /// After editing is complete, gets the summary of the created/edited procedure type.
        /// </summary>
        public MaterialLotSummary summary
        {
            get { return _summary; }
        }

        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            Platform.GetService<IMaterialLotService>(
                delegate(IMaterialLotService service)
                {
                    //LoadMaterialLotEditorFormDataResponse Loaddataresponse = service.LoadMaterialLotEditorFormData(new LoadMaterialLotEditorFormDataRequest());

                    if (_isNew)
                    {
                        _detail = new MaterialLotDetail();
                    }
                    else
                    {
                        LoadMaterialLotForEditResponse response = service.LoadMaterialLotForEdit(new LoadMaterialLotForEditRequest(_ref));
                        _detail = response.objDetail;
                    }
                });

            SupplierLookup = new ContactLookupHandler (this.Host.DesktopWindow);

            base.Start();
        }

        /// <summary>
        /// Called by the host when the application component is being terminated.
        /// </summary>
        public override void Stop()
        {


            base.Stop();
        }

        #region Presentation Model
        ContactSummary _selectedsupplier;
        public ContactSummary SelectedSupplier
        {
            get
            {
                return _detail.Supplier ;
            }
            set
            {
                if (_detail.Supplier  == value)
                    return;

                _detail.Supplier  = value;
                NotifyPropertyChanged("SelectedSupplier");
            }
        }

        [ValidateNotNull ]
        public string Id
        {
            get
            {
                return _detail.Id;
            }
            set
            {
                if (_detail.Id == value)
                    return;

                _detail.Id = value;
                NotifyPropertyChanged("Id");
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
            }
        }
        [ValidateNotNull ]
        public DateTime InputDate
        {
            get
            {
                return _detail.InputDate;
            }
            set
            {
                if (_detail.InputDate == value)
                    return;

                _detail.InputDate = value;
                NotifyPropertyChanged("InputDate");
            }
        }

        public bool Deactivated
        {
            get
            {
                return _detail.Deactivated;
            }
            set
            {
                if (_detail.Deactivated == value)
                    return;

                _detail.Deactivated = value;
                NotifyPropertyChanged("Deactivated");
            }
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

        public void Accept()
        {

            if (this.HasValidationErrors)
            {
                this.ShowValidation(true);
                return;
            }
            else
            {
                try
                {
                    SaveChanges();
                    if (IsCloseWhenSaved)
                        this.Exit(ApplicationComponentExitCode.Accepted);
                }
                catch (Exception e)
                {
                    ExceptionHandler.Report(e, SR.ExceptionSave, this.Host.DesktopWindow,
                        delegate
                        {
                            this.Exit(ApplicationComponentExitCode.Error);
                        });
                }
            }
        }



        public void Cancel()
        {
            this.Exit(ApplicationComponentExitCode.None);
        }


        #endregion

        private void SaveChanges()
        {
            _detail.Clinic = LoginSession.Current.WorkingFacility;
            Platform.GetService<IMaterialLotService>(
                delegate(IMaterialLotService service)
                {
                    if (_isNew)
                    {
                        AddMaterialLotResponse response = service.AddMaterialLot(new AddMaterialLotRequest(_detail));
                        _summary = response.Summarys;
                        ItemAdded(this, System.EventArgs.Empty);
                    }
                    else
                    {
                        UpdateMaterialLotResponse response = service.UpdateMaterialLot(new UpdateMaterialLotRequest(_detail));
                        _summary = response.objSummary;
                        ItemUpdated(this, System.EventArgs.Empty);
                    }
                });
            ResetNew();
        }


    }
}
