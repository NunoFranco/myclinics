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
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Ris.Application.Common.Billing ;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common;
namespace ClearCanvas.Ris.Client
{
	public class ProcedureTypeSummaryTable : Table<ProcedureTypeSummary>
	{
		private readonly int columnSortIndex = 0;
        public static string PrimaryCurrencyCode = "";
        public static string PrimaryLocale = "";
        public static string Customeformat = "";
        void InitTableViewFormat()
        {
            ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail detail = null;
            Common.Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
            {
                ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO.ListCurrencyRequest();
                request.IsListDetail = true;
                request.IsPrimaryCurrency = true;
                List<ClearCanvas.Ris.Application.Common.Billing.CurrencyDetail > lst = service.ListAllCurrency(request).Details;
                if (lst != null && lst.Count > 0)
                    detail = lst[0];
            });
            if (detail != null)
            {
                PrimaryLocale = detail.DisplayLocale;
                Customeformat = detail.CustomDisplayFormat;
                PrimaryCurrencyCode = detail.CurrencyCode;
            }
        }
		public ProcedureTypeSummaryTable()
		{
            InitTableViewFormat();
			this.Columns.Add(new TableColumn<ProcedureTypeSummary, string>("ID",
				delegate(ProcedureTypeSummary rpt) { return rpt.Id; },
				0.5f));

			this.Columns.Add(new TableColumn<ProcedureTypeSummary, string>("Name",
				delegate(ProcedureTypeSummary rpt) { return rpt.Name; },
				0.5f));
            this.Columns.Add(new TableColumn<ProcedureTypeSummary, string>(string.Format(SR.ProcedureTypeColumnBasePrice,PrimaryCurrencyCode),
                            delegate(ProcedureTypeSummary rpt) { return NumberUtils.GetCurrencyDisplayFormat(PrimaryLocale,Customeformat, rpt.BasePrice); },
                            0.5f));
            this.Columns.Add(new TableColumn<ProcedureTypeSummary, string>(SR.ProcedureTypeColumnTax,
                delegate(ProcedureTypeSummary rpt) { return rpt.Tax.ToString(); },
                0.5f));
			this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
		}
	}

}
