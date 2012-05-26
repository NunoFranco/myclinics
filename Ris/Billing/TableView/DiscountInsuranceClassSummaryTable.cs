using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Ris.Billing.Common;
namespace ClearCanvas.Ris.Billing.TableView
{
    public class DiscountClassSummaryTable : Table<DiscountInsuranceSummary>
    {
       
            private readonly int columnSortIndex = 0;

            public DiscountClassSummaryTable()
            {
                this.Columns.Add(new TableColumn<DiscountInsuranceSummary, string>(SR.ColumnDiscountClassCode,
                    delegate(DiscountInsuranceSummary rpt) { return rpt.ClassCode; },
                    0.5f));

                this.Columns.Add(new TableColumn<DiscountInsuranceSummary, string>(SR.ColumnDiscountClassName,
                    delegate(DiscountInsuranceSummary rpt) { return rpt.ClassName; },
                    0.5f));
                this.Columns.Add(new TableColumn<DiscountInsuranceSummary, string>(SR.ColumnInsuranceAmountType,
                                delegate(DiscountInsuranceSummary rpt) { return rpt.AmountType.ToString(); },
                                0.5f));
                this.Columns.Add(new TableColumn<DiscountInsuranceSummary, decimal>(SR.ColumnInsuranceAmount,
                    delegate(DiscountInsuranceSummary rpt) { return rpt.Amount; },
                    0.5f));
                this.Sort(new TableSortParams(this.Columns[columnSortIndex], true));
            }
        
    }
}
