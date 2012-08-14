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
using {$CommonNS};
using {$CommonNS}{$Suffix};


namespace {$componentNS}
{
    /// <summary>
    /// Extension point for views onto <see cref="{0}EditorComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class {0}EditorComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// {0}EditorComponent class.
    /// </summary>
    [AssociateView(typeof({0}EditorComponentViewExtensionPoint))]
    public partial class {0}EditorComponent : ApplicationComponent
    {
        public event EventHandler ItemAdded;
        public event EventHandler ItemUpdated;
        public bool IsCloseWhenSaved { get; set; }
        private EntityRef _ref;
        private {0}Detail _detail;
        private bool _isNew;

        private {0}Summary _summary;
        private List<{0}Summary> _baseTypeChoices;

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
            _detail = new {0}Detail();
            ReBindData();
        }
        public EntityRef {0}Ref
        {
            get { return _ref; }
            set
            {
                _ref = value;
                _isNew = false;
                Platform.GetService<I{0}Service>(
                                 delegate(I{0}Service service)
                                 {
                                     Load{0}ForEditResponse response = service.Load{0}ForEdit(
                                         new Load{0}ForEditRequest(_ref));
                                     _detail = response.objDetail;
                                     //ItemsTable.Items.Clear();
                                     //ItemsTable.Items.AddRange(_detail.Medicines);
                                 });
                ReBindData();
            }
        }
        public void ReBindData()
        {
            {2}
            _isNew = true;
            this.Modified = false;
            NotifyAllPropertiesChanged();
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public {0}EditorComponent()
        {
            _isNew = true;
			CustomConstructor();
        }

        public {0}EditorComponent(EntityRef _objRef)
        {
            _isNew = false;
            _ref = _objRef;
			CustomConstructor();
        }

        /// <summary>
        /// After editing is complete, gets the summary of the created/edited procedure type.
        /// </summary>
        public {0}Summary summary
        {
            get { return _summary; }
        }

        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            Platform.GetService<I{0}Service>(
                delegate(I{0}Service service)
                {
                    //Load{0}EditorFormDataResponse Loaddataresponse = service.Load{0}EditorFormData(new Load{0}EditorFormDataRequest());
                    
                    if (_isNew)
                    {
                        
                    }
                    else
                    {
                        Load{0}ForEditResponse response = service.Load{0}ForEdit(new Load{0}ForEditRequest(_ref));
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
		{1}
       
		
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
            Platform.GetService<I{0}Service>(
                delegate(I{0}Service service)
                {
                    if (_isNew)
                    {
                        Add{0}Response response = service.Add{0}(new Add{0}Request(_detail));
                        _summary = response.Summarys;
                        ItemAdded(this, System.EventArgs.Empty);
                    }
                    else
                    {
                        Update{0}Response response = service.Update{0}(new Update{0}Request(_detail));
                        _summary = response.objSummary;
                        ItemUpdated(this, System.EventArgs.Empty);
                    }
                });
            ResetNew();
        }


    }
}
