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
using ClearCanvas.Ris.Billing.Common;
using ClearCanvas.Ris.Extend.Common;
using ClearCanvas.Ris.Extend.Common.Billing;

namespace ClearCanvas.Ris.Billing
{
    /// <summary>
    /// Extension point for views onto <see cref="BillingCurrencyEditComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingCurrencyEditComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingCurrencyEditComponent class.
    /// </summary>
    [AssociateView(typeof(BillingCurrencyEditComponentViewExtensionPoint))]
    public class BillingCurrencyEditComponent : ApplicationComponent
    {
        public readonly bool _isNew;
        public CurrencySummary objectSummary { get; set; }
        Enterprise.Common.EntityRef currencyRef { get; set; }
        private CurrencyDetail _editedItemDetail;
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingCurrencyEditComponent()
        {
            _isNew = true;
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingCurrencyEditComponent(Enterprise.Common.EntityRef entityRef)
        {
            currencyRef = entityRef;
            _isNew = false;
        }
        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            Platform.GetService<ICurrencyService>(
                delegate(ICurrencyService service)
                {

                    if (_isNew)
                    {
                        _editedItemDetail = new CurrencyDetail();
                    }
                    else
                    {
                        LoadCurrencyEditResponse response =
                            service.LoadCurrencyForedit(
                                new LoadCurrencyEditRequest(currencyRef));

                        _editedItemDetail = response.CurrencyDetail;
                    }
                });
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
                    if (string.IsNullOrEmpty(_editedItemDetail.CurrencyCode)
                        || string.IsNullOrEmpty(_editedItemDetail.CurrencyName)
                        || _editedItemDetail.RateToPrimaryCurrency<=0
                        )
                    {
                        Platform.ShowMessageBox(SR.CurrencyValidateRequireFieldError);
                        return;
                    }

                    Platform.GetService<ICurrencyService>(
                        delegate(ICurrencyService service)
                        {
                            if (_isNew)
                            {
                                
                                AddCurrencyResponse response =
                                    service.AddCurrency(new AddCurrencyRequest(_editedItemDetail));
                                currencyRef = response.Summary.CurrencyRef;
                                objectSummary = response.Summary;
                            }
                            else
                            {
                                
                                UpdateCurrencyResponse response =
                                    service.UpdateCurrency(new UpdateCurrencyRequest(_editedItemDetail));
                                currencyRef = response.ObjectSummary.CurrencyRef;
                                objectSummary = response.ObjectSummary;
                            }
                        });

                    this.Exit(ApplicationComponentExitCode.Accepted);
                }
                catch (Exception e)
                {
                    ExceptionHandler.Report(e, SR.ExceptionSaveCurrencyError, this.Host.DesktopWindow,
                        delegate()
                        {
                            this.ExitCode = ApplicationComponentExitCode.Error;
                            this.Host.Exit();
                        });
                }
            }
        }

        public void Cancel()
        {
            this.ExitCode = ApplicationComponentExitCode.None;
            Host.Exit();
        }


        #region presentation Model
        public DateTime CreatedOn{
            get{
                return _editedItemDetail.CreatedOn;
            }
            set{
                _editedItemDetail.CreatedOn=value;
            }
        }
       
        public string CreatedUser{
            get{
                return _editedItemDetail.CreatedUser;
            }
            set{
                _editedItemDetail.CreatedUser=value;
            }
        }
       
        public string CurrencyCode{
            get{
                return _editedItemDetail.CurrencyCode;
            }
            set{
                _editedItemDetail.CurrencyCode=value;
            }
        }
       
        public string CurrencyName{
            get{
                return _editedItemDetail.CurrencyName;
            }
            set{_editedItemDetail.CurrencyName=value;
            }
        }
       
        
       
        public string CustomDisplayFormat{
            get{
                return _editedItemDetail.CustomDisplayFormat;
            }
            set{_editedItemDetail.CustomDisplayFormat=value;
            }
        }
       
        public bool Deactivated{
            get{
                return _editedItemDetail.Deactivated;
            }
            set{_editedItemDetail.Deactivated=value;
            }
        }
       
        public string DisplayLocale{
            get{
                return _editedItemDetail.DisplayLocale;
            }
            set{_editedItemDetail.DisplayLocale=value;
            }
        }
       
        public bool IsPrimaryCurrency{
            get{
                return _editedItemDetail.IsPrimaryCurrency;
            }
            set{_editedItemDetail.IsPrimaryCurrency=value;
            }
        }
       
        public bool IsPrimaryExRateCurrency{
            get{
                return _editedItemDetail.IsPrimaryExRateCurrency;
            }
            set{_editedItemDetail.IsPrimaryExRateCurrency=value;
            }
        }
       
        public DateTime LastUpdated{
            get{
                return _editedItemDetail.LastUpdated;
            }
            set{_editedItemDetail.LastUpdated=value;
            }
        }
       
        public decimal RateToPrimaryCurrency{
            get{
                return _editedItemDetail.RateToPrimaryCurrency;
            }
            set{_editedItemDetail.RateToPrimaryCurrency=value;
            }
        }
        #endregion
    }
}
