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

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Material.Application.Common.Contacts ;

using ClearCanvas.Ris.Client.Formatting;
using ClearCanvas.Material.Client;
using ClearCanvas.Ris.Client;

namespace ClearCanvas.Material.Client
{
    /// <summary>
    /// Provides utilities for Contact name resolution.
    /// </summary>
    public class ContactLookupHandler : LookupHandler<TextQueryRequest, ContactSummary>
    {
        private readonly DesktopWindow _desktopWindow;
        private readonly string[] _ContactTypesFilter;

        private string[] _ContactGroupFilter;

        public bool FilterDoctorINworkingPlan { get; set; }

        public string[] ContactgroupFilter { get { return _ContactGroupFilter; } set { _ContactGroupFilter = value; } }
        public ContactLookupHandler(DesktopWindow desktopWindow)
            : this(desktopWindow, new string[] { }, new string[] { })
        {
        }

        public ContactLookupHandler(DesktopWindow desktopWindow, string[] ContactTypesFilter, string[] groupfilter)
        {
            _desktopWindow = desktopWindow;
            _ContactTypesFilter = ContactTypesFilter;
            _ContactGroupFilter = groupfilter;
        }

        protected override TextQueryResponse<ContactSummary> DoQuery(TextQueryRequest request)
        {
            //if (_ContactTypesFilter != null && _ContactTypesFilter.Length > 0)
            //{
            //    request.ContactTypesFilter = _ContactTypesFilter;
            //}
            //if (_ContactGroupFilter != null && _ContactGroupFilter.Length > 0)
            //{
            //    request.ContactTypesFilter = _ContactGroupFilter;
            //}


            TextQueryResponse<ContactSummary> response = null;
            Platform.GetService<IContactService>(
                service => response = service.TextQuery(request));
            return response;
        }

        /// <summary>
        /// Shows a dialog to allow user to resolve the specified query to a single Contact.
        /// The query may consist of part of the surname,
        /// optionally followed by a comma and then part of the given name (e.g. "sm, b" for smith, bill).
        /// The method returns true if the name is successfully resolved, or false otherwise.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool ResolveNameInteractive(string query, out ContactSummary result)
        {
            result = null;

            var ContactComponent = new ContactSummaryComponent(true );

            //if (!string.IsNullOrEmpty(query))
            //{
            //    var names = query.Split(',');
            //    if (names.Length > 0)
            //        ContactComponent.LastName = names[0].Trim();
            //    if (names.Length > 1)
            //        ContactComponent.FirstName = names[1].Trim();
            //}

            var exitCode = ApplicationComponent.LaunchAsDialog(
                _desktopWindow, ContactComponent, SR.TitleContactSummary);

            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                result = (ContactSummary)ContactComponent.SummarySelection.Item;
            }

            return (result != null);
        }


        public override string FormatItem(ContactSummary item)
        {
            return string.Format("{0} - ({1})", item.Code , item.Name );
        }
    }
}
