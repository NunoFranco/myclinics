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
using ClearCanvas.Material.Application.Common.MaterialLots;

using ClearCanvas.Ris.Client.Formatting;
using ClearCanvas.Material.Client;
using ClearCanvas.Ris.Client;

namespace ClearCanvas.Material.Client
{
    /// <summary>
    /// Provides utilities for MaterialLot name resolution.
    /// </summary>
    public class MaterialLotLookupHandler : LookupHandler<TextQueryRequest, MaterialLotSummary>
    {
        private readonly DesktopWindow _desktopWindow;
        private readonly string[] _MaterialLotTypesFilter;

        private string[] _MaterialLotGroupFilter;

        public bool FilterDoctorINworkingPlan { get; set; }

        //public string[] MaterialLotgroupFilter { get { return _MaterialLotGroupFilter; } set { _MaterialLotGroupFilter = value; } }
        public MaterialLotLookupHandler(DesktopWindow desktopWindow)
        {
            _desktopWindow = desktopWindow;
        }

        //public MaterialLotLookupHandler(DesktopWindow desktopWindow, string[] MaterialLotTypesFilter, string[] groupfilter)
        //{
        //    _desktopWindow = desktopWindow;
        //    _MaterialLotTypesFilter = MaterialLotTypesFilter;
        //    _MaterialLotGroupFilter = groupfilter;
        //}

        protected override TextQueryResponse<MaterialLotSummary> DoQuery(TextQueryRequest request)
        {
            //if (_MaterialLotTypesFilter != null && _MaterialLotTypesFilter.Length > 0)
            //{
            //    request.MaterialLotTypesFilter = _MaterialLotTypesFilter;
            //}
            //if (_MaterialLotGroupFilter != null && _MaterialLotGroupFilter.Length > 0)
            //{
            //    request.MaterialLotTypesFilter = _MaterialLotGroupFilter;
            //}


            TextQueryResponse<MaterialLotSummary> response = null;
            Platform.GetService<IMaterialLotService>(
                service => response = service.TextQuery(request));
            return response;
        }

        /// <summary>
        /// Shows a dialog to allow user to resolve the specified query to a single MaterialLot.
        /// The query may consist of part of the surname,
        /// optionally followed by a comma and then part of the given name (e.g. "sm, b" for smith, bill).
        /// The method returns true if the name is successfully resolved, or false otherwise.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool ResolveNameInteractive(string query, out MaterialLotSummary result)
        {
            result = null;

            var MaterialLotComponent = new MaterialLotSummaryComponent(true);

            //if (!string.IsNullOrEmpty(query))
            //{
            //    var names = query.Split(',');
            //    if (names.Length > 0)
            //        MaterialLotComponent.LastName = names[0].Trim();
            //    if (names.Length > 1)
            //        MaterialLotComponent.FirstName = names[1].Trim();
            //}

            var exitCode = ApplicationComponent.LaunchAsDialog(
                _desktopWindow, MaterialLotComponent, SR.TitleMaterialLotSummary);

            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                result = (MaterialLotSummary)MaterialLotComponent.SummarySelection.Item;
            }

            return (result != null);
        }


        public override string FormatItem(MaterialLotSummary item)
        {
            return string.Format("{0} - {1}", item.Id,item.Supplier.Name );
        }
    }
}
