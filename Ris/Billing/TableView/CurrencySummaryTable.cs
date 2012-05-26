using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Ris.Billing.Common;
using ClearCanvas.Common;
using ClearCanvas.Ris.Extend.Common;
using ClearCanvas.Ris.Billing.Common;
namespace ClearCanvas.Ris.Billing.TableView
{
    public class CurrencySummaryTable : Table<CurrencySummary>
    {

        private readonly int columnSortIndex = 0;

        public CurrencySummaryTable()
        {
            string primaryExCurrency = "";
            Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
        {
            ClearCanvas.Ris.Extend.Common.Billing.ListCurrencyRequest request = new ClearCanvas.Ris.Extend.Common.Billing.ListCurrencyRequest();
            request.IsListDetail = true;
            request.IsPrimaryExRateCurrency = true;
            List<ClearCanvas.Ris.Billing.Common.CurrencyDetail> lst = service.ListAllCurrency(request).Details;
            ClearCanvas.Ris.Billing.Common.CurrencyDetail detail = null;
            if (lst != null && lst.Count > 0)
                detail = lst[0];
            if (detail != null)
                primaryExCurrency = detail.CurrencyCode;
            else
                Platform.Log(LogLevel.Error, "Primary Currency not found");
        });
            this.Columns.Add(new TableColumn<CurrencySummary, string>(SR.ColumnCurrencyCode,
                delegate(CurrencySummary rpt) { return rpt.CurrencyCode; },
                0.5f));

            this.Columns.Add(new TableColumn<CurrencySummary, string>(SR.ColumnCurrencyName,
                delegate(CurrencySummary rpt) { return rpt.CurrencyName; },
                0.5f));
            this.Columns.Add(new TableColumn<CurrencySummary, string>(string.Format(SR.ColumnRateToPrimaryCurrency, primaryExCurrency),
                            delegate(CurrencySummary rpt) { return rpt.RateToPrimaryCurrency.ToString(); },
                            0.5f));
            this.Columns.Add(new TableColumn<CurrencySummary, bool>(SR.ColumnIsPrimaryCurrency,
                delegate(CurrencySummary rpt) { return rpt.IsPrimaryCurrency; },
                0.5f));
            this.Columns.Add(new TableColumn<CurrencySummary, bool>(SR.ColumnIsPrimaryExRateCurrency,
               delegate(CurrencySummary rpt) { return rpt.IsPrimaryExRateCurrency; },
               0.5f));
            this.Columns.Add(new TableColumn<CurrencySummary, string>(SR.ColumnCurrencyDisplaylocale,
                delegate(CurrencySummary rpt) { return rpt.DisplayLocale; },
                0.5f));
            this.Columns.Add(new TableColumn<CurrencySummary, string>(SR.ColumnCurrencyCustomFormat,
                delegate(CurrencySummary rpt) { return rpt.CustomDisplayFormat; },
                0.5f));

            this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
        }

    }
}
