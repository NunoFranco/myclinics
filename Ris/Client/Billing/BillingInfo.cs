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
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Desktop;

namespace ClearCanvas.Ris.Client.Billing
{
    /// <summary>
    /// Extension point for views onto <see cref="BillingInfo"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingInfoViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingInfo class.
    /// </summary>
    [AssociateView(typeof(BillingInfoViewExtensionPoint))]
    public class BillingInfo : ApplicationComponent
    {
        public PatientProfileDetail PatientDetail { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingInfo()
        {
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingInfo(PatientProfileDetail patientDetail)
        {
            PatientDetail = patientDetail;
        }
        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
          

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
        private ChildComponentHost _billingcomponenthost;
        public ApplicationComponentHost BillingComponentHost
        {
            get { return _billingcomponenthost; }
        }
    }
}
