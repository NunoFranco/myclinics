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
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Desktop.Actions;

namespace ClearCanvas.Ris.Client.Billing.Tools
{

    [MenuAction("launch", "global-menus/Billing/Insurance Price", "Apply")]

  
    [IconSet("apply", IconScheme.Colour, "Icons.BillingInsurancePriceToolSmall.png", "Icons.BillingInsurancePriceToolMedium.png", "Icons.BillingInsurancePriceToolLarge.png")]

    [ActionPermission("Apply", ClearCanvas.Ris.Application.Common.Billing.AuthorityTokens.Billing.Admin.BillingManageInsurancePrice)]
    [EnabledStateObserver("apply", "Enabled", "EnabledChanged")]

    [ExtensionOf(typeof(ClearCanvas.Desktop.DesktopToolExtensionPoint))]
    public class BillingInsurancePriceTool : Tool<ClearCanvas.Desktop.IDesktopToolContext>
    {
        private bool _enabled;
        private event EventHandler _enabledChanged;
        Workspace seftWorkspace = null;
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <remarks>
        /// A no-args constructor is required by the framework.  Do not remove.
        /// </remarks>
        public BillingInsurancePriceTool()
        {
            _enabled = true;
        }

        /// <summary>
        /// Called by the framework to initialize this tool.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();

            // TODO: add any significant initialization code here rather than in the constructor
        }

        /// <summary>
        /// Gets whether this tool is enabled/disabled in the UI.
        /// </summary>
        public bool Enabled
        {
            get { return _enabled; }
            protected set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    EventsHelper.Fire(_enabledChanged, this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Notifies that the <see cref="Enabled"/> state of this tool has changed.
        /// </summary>
        public event EventHandler EnabledChanged
        {
            add { _enabledChanged += value; }
            remove { _enabledChanged -= value; }
        }

        // Note: you may change the name of the 'Apply' method as desired, but be sure to change the
        // corresponding parameter in the MenuAction and ButtonAction attributes

        /// <summary>
        /// Called by the framework when the user clicks the "apply" menu item or toolbar button.
        /// </summary>
        public void Apply()
        {
            BillingInsuramceComponent component = new BillingInsuramceComponent(ClearCanvas.Enterprise.Common.AuthenticationScope.Current.CurrentClinic);
            component.ActiveWindow = this.Context.DesktopWindow;
            if (seftWorkspace == null || seftWorkspace.State==DesktopObjectState.Closed)
            {
                seftWorkspace = ApplicationComponent.LaunchAsWorkspace(
                             this.Context.DesktopWindow,
                             component,
                             SR.InsurancePrice);
                seftWorkspace.Closed += new EventHandler<ClosedEventArgs>(seftWorkspace_Closed);
            }
            else
            {
                seftWorkspace.Activate();
            }
        }

        void seftWorkspace_Closed(object sender, ClosedEventArgs e)
        {
            seftWorkspace = null;
        }
    }
}
