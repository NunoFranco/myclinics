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


using ClearCanvas.Ris.Client.Formatting;
using ClearCanvas.Material.Client;
using ClearCanvas.Ris.Client;
using ClearCanvas.Material.Application.Common.Warehouses;

namespace ClearCanvas.Material.Client
{
    /// <summary>
    /// Provides utilities for WareHouse name resolution.
    /// </summary>
    public class WareHouseLookupHandler : LookupHandler<TextQueryRequest, WarehouseSummary>
    {
        private readonly DesktopWindow _desktopWindow;
        private readonly string[] _WareHouseTypesFilter;

        private string[] _WareHouseGroupFilter;

        public bool FilterDoctorINworkingPlan { get; set; }

        //public string[] WareHousegroupFilter { get { return _WareHouseGroupFilter; } set { _WareHouseGroupFilter = value; } }
        public WareHouseLookupHandler(DesktopWindow desktopWindow)
        {
            _desktopWindow = desktopWindow;
        }

        //public WareHouseLookupHandler(DesktopWindow desktopWindow, string[] WareHouseTypesFilter, string[] groupfilter)
        //{
        //    _desktopWindow = desktopWindow;
        //    _WareHouseTypesFilter = WareHouseTypesFilter;
        //    _WareHouseGroupFilter = groupfilter;
        //}

        protected override TextQueryResponse<WarehouseSummary> DoQuery(TextQueryRequest request)
        {
            //if (_WareHouseTypesFilter != null && _WareHouseTypesFilter.Length > 0)
            //{
            //    request.WareHouseTypesFilter = _WareHouseTypesFilter;
            //}
            //if (_WareHouseGroupFilter != null && _WareHouseGroupFilter.Length > 0)
            //{
            //    request.WareHouseTypesFilter = _WareHouseGroupFilter;
            //}


            TextQueryResponse<WarehouseSummary> response = null;
            Platform.GetService<IWarehouseService>(
                service => response = service.TextQuery(request));
            return response;
        }

        /// <summary>
        /// Shows a dialog to allow user to resolve the specified query to a single WareHouse.
        /// The query may consist of part of the surname,
        /// optionally followed by a comma and then part of the given name (e.g. "sm, b" for smith, bill).
        /// The method returns true if the name is successfully resolved, or false otherwise.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool ResolveNameInteractive(string query, out WarehouseSummary result)
        {
            result = null;

            var WareHouseComponent = new WarehouseSummaryComponent(true);

            //if (!string.IsNullOrEmpty(query))
            //{
            //    var names = query.Split(',');
            //    if (names.Length > 0)
            //        WareHouseComponent.LastName = names[0].Trim();
            //    if (names.Length > 1)
            //        WareHouseComponent.FirstName = names[1].Trim();
            //}

            var exitCode = ApplicationComponent.LaunchAsDialog(
                _desktopWindow, WareHouseComponent, SR.TitleWarehouseSummary);

            if (exitCode == ApplicationComponentExitCode.Accepted)
            {
                result = (WarehouseSummary)WareHouseComponent.SummarySelection.Item;
            }

            return (result != null);
        }


        public override string FormatItem(WarehouseSummary item)
        {
            return string.Format("{0} - {1} {2}", item.Code ,item.Name ,item.PICName  );
        }
    }
}
