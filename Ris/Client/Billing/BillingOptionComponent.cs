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
using System.Threading;
using System.Globalization;
using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Common.Utilities;
namespace ClearCanvas.Ris.Client.Billing
{
    /// <summary>
    /// Extension point for views onto <see cref="BillingOptionComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingOptionComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingOptionComponent class.
    /// </summary>
    [AssociateView(typeof(BillingOptionComponentViewExtensionPoint))]
    public class BillingOptionComponent : ApplicationComponent
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingOptionComponent()
        {
        }
        Enterprise.Common.Billing.BillingOptions _option = new ClearCanvas.Enterprise.Common.Billing.BillingOptions();
        public Enterprise.Common.Billing.BillingOptions options { get { return _option; } }

        public List<CurrencySummary> _availableCurrency;
        public IEnumerable<string> AvailableCurrency
        {
            get
            {
                if (_availableCurrency == null)
                {
                    Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
                    {
                        _availableCurrency = service.ListAllCurrency(new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest()).Currency;

                    });
                }
                List<string> list = new List<string>();
                foreach (var item in _availableCurrency)
                {
                    list.Add(item.CurrencyCode);
                }
                return list;
            }
        }

        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
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
        public void Accept()
        {
            options.Save();
            //var curr = _availableCurrency.Find(x => x.CurrencyCode == PrimaryCurrency);
            //if (curr != null)
            //{
            //    if (!string.IsNullOrEmpty(curr.CustomDisplayFormat))
            //    {
            //        NumberUtils.numberFormat = curr.CustomDisplayFormat;
            //    }
            //    else
            //    {
            //        try
            //        {
            //            Thread.CurrentThread.CurrentCulture = new CultureInfo(curr.DisplayLocale);
            //        }
            //        catch (Exception ex)
            //        {
            //            Platform.Log(LogLevel.Error,ex.Message);
            //        }

            //    }
            //}
            this.Exit(ApplicationComponentExitCode.Accepted);
        }
        public void Cancel()
        {
            this.ExitCode = ApplicationComponentExitCode.None;
            this.Host.Exit();
        }
        public string PrimaryCurrency
        {
            get
            {
                return options.PrimaryCurrency;
            }
            set
            {
                options.PrimaryCurrency = value;

            }
        }
        public string SystemLanggue
        {
            get
            {
                return options.SystemLanguague;
            }
            set
            {
                options.SystemLanguague = value;
            }
        }
    }
}
