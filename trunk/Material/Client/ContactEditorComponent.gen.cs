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
using ClearCanvas.Material.Application.Common.Contacts;


namespace ClearCanvas.Material.Client
{
    /// <summary>
    /// Extension point for views onto <see cref="ContactEditorComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class ContactEditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// ContactEditorComponent class.
    /// </summary>
    [AssociateView(typeof(ContactEditorComponentViewExtensionPoint))]
    public partial class ContactEditorComponent : ApplicationComponent
    {
        public event EventHandler ItemAdded;
        public event EventHandler ItemUpdated;
        public bool IsCloseWhenSaved { get; set; }
        private EntityRef _ref;
        private ContactDetail _detail;
        private  bool _isNew;

        private ContactSummary _summary;
        private List<ContactSummary> _baseTypeChoices;

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
            _detail = new ContactDetail();
            ReBindData ();
        }
        public EntityRef ContactRef
        {
            get { return _ref; }
            set
            {
                _ref = value;
                _isNew = false;
                Platform.GetService<IContactService>(
                                 delegate(IContactService service)
                                 {
                                     LoadContactForEditResponse response = service.LoadContactForEdit(new LoadContactForEditRequest(_ref));
                                     _detail = response.objDetail;
                                     //ItemsTable.Items.Clear();
                                     //ItemsTable.Items.AddRange(_detail.Medicines);
                                 });
                ReBindData();
            }
        }
        public void ReBindData()
        {
            NotifyPropertyChanged("ContactCode");
            NotifyPropertyChanged("ContactName");
            NotifyPropertyChanged("Address");
            NotifyPropertyChanged("ContactDetailInformation");
            _isNew = true;
            this.Modified = false;
            NotifyAllPropertiesChanged();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public ContactEditorComponent()
        {
            _isNew = true;
			CustomConstructor();
        }

        public ContactEditorComponent(EntityRef _objRef)
        {
            _isNew = false;
            _ref = _objRef;
			CustomConstructor();
        }

        /// <summary>
        /// After editing is complete, gets the summary of the created/edited procedure type.
        /// </summary>
        public ContactSummary summary
        {
            get { return _summary; }
        }

        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            Platform.GetService<IContactService>(
                delegate(IContactService service)
                {
                    //LoadContactEditorFormDataResponse Loaddataresponse = service.LoadContactEditorFormData(new LoadContactEditorFormDataRequest());
                    
                    if (_isNew)
                    {
                        
                    }
                    else
                    {
                        LoadContactForEditResponse response = service.LoadContactForEdit(new LoadContactForEditRequest(_ref));
                        _detail = response.objDetail;
                        
                    }
                });


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
		[ValidateNotNull ]
        public string ContactCode
        {
            get
            {
              return  _detail.Code;
            }
            set
            {
                _detail.Code = value;
                this.Modified = true;
                NotifyPropertyChanged("ContactCode");
            }
        }
        [ValidateNotNull]
        public string ContactName
        {
            get
            {
              return  _detail.Name;
            }
            set
            {
                _detail.Name = value;
                this.Modified = true;
                NotifyPropertyChanged("ContactName");
            }
        }
        public string Address
        {
            get
            {
              return  _detail.Address;
            }
            set
            {
                _detail.Address = value;
                this.Modified = true;
                NotifyPropertyChanged("Address");
            }
        }
        public string ContactDetailInformation
        {
            get
            {
              return  _detail.ContactDetailInformation;
            }
            set
            {
                _detail.ContactDetailInformation = value;
                this.Modified = true;
                NotifyPropertyChanged("ContactDetailInformation");
            }
        }
        public bool Deactivated
        {
            get
            {
              return  _detail.Deactivated;
            }
            set
            {
                _detail.Deactivated = value;
                this.Modified = true;

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
                    if(IsCloseWhenSaved)
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
            Platform.GetService<IContactService>(
                delegate(IContactService service)
                {
                    if (_isNew)
                    {
                        AddContactResponse response = service.AddContact(new AddContactRequest(_detail));
                        _summary = response.Summarys ;
                        ItemAdded(this, System.EventArgs.Empty);
                    }
                    else
                    {
                        UpdateContactResponse response = service.UpdateContact(new UpdateContactRequest(_detail));
                        _summary = response.objSummary ;
                        ItemUpdated(this, System.EventArgs.Empty);
                    }
                });
            ResetNew();
        }


    }
}
