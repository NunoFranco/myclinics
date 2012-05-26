using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClearCanvas.Ris.Billing;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
namespace ClearCanvas.Ris.Billing.View.WinForms
{
    public partial class frmSetPrimaryCurrency : Form
    {
        internal class DisplayCurrency
        {
            public string Code { get; set; }
            public string Value { get; set; }
        }
        public bool IsPrimaryCurrencyChanged { get; set; }
        public bool IsPrimaryExRateCurrencyChanged { get; set; }
        public bool isNeedReload { get; set; }
        public frmSetPrimaryCurrency()
        {
            InitializeComponent();
        }
        public CurrencyDetail CurrentPrimaryCurrency { get; set; }
        public CurrencyDetail CurrentPrimaryExRateCurrency { get; set; }
        public CurrencyDetail NewPrimaryCurrency { get; set; }
        public CurrencyDetail NewPrimaryExRateCurrency { get; set; }
        public List<CurrencyDetail> ListCurreices { get; set; }
        DisplayCurrency SelectedPrimary { get; set; }
        DisplayCurrency SelectedPrimaryExrate { get; set; }
        public frmSetPrimaryCurrency(CurrencyDetail currentPrimaryCurrency, CurrencyDetail currentPrimaryExRateCurrency, List<CurrencyDetail> allCurrency)
        {
            try
            {
                InitializeComponent();
                currentPrimaryCurrency = currentPrimaryCurrency == null ? new CurrencyDetail() : currentPrimaryCurrency;
                currentPrimaryExRateCurrency = currentPrimaryExRateCurrency == null ? new CurrencyDetail() : currentPrimaryExRateCurrency;
                CurrentPrimaryCurrency = currentPrimaryCurrency;
                CurrentPrimaryExRateCurrency = currentPrimaryExRateCurrency;

                List<DisplayCurrency> lst1 = new List<DisplayCurrency>();
                List<DisplayCurrency> lst2 = new List<DisplayCurrency>();
                ListCurreices = allCurrency;
                foreach (var item in allCurrency)
                {
                    lst1.Add(new DisplayCurrency { Code = string.Format(SR.CurrencyDisplayFormat, item.CurrencyCode, item.CurrencyName), Value = item.CurrencyCode });
                    lst2.Add(new DisplayCurrency { Code = string.Format(SR.CurrencyDisplayFormat, item.CurrencyCode, item.CurrencyName), Value = item.CurrencyCode });

                }

                NewPrimaryCurrency = ListCurreices.FirstOrDefault(x => x.CurrencyCode == currentPrimaryCurrency.CurrencyCode);
                NewPrimaryExRateCurrency = ListCurreices.FirstOrDefault(x => x.CurrencyCode == currentPrimaryExRateCurrency.CurrencyCode);

                SelectedPrimary = lst1.FirstOrDefault(x => x.Value == NewPrimaryCurrency.CurrencyCode);
                SelectedPrimaryExrate = lst2.FirstOrDefault(x => x.Value == NewPrimaryExRateCurrency.CurrencyCode);

                this.cmbNewPrimary.DisplayMember = "Code";
                this.cmbNewPrimary.DataSource = lst1;
                this.cmbNewPrimaryExRate.DisplayMember = "Code";
                this.cmbNewPrimaryExRate.DataSource = lst2;
            }
            catch (Exception ex)
            {
                Platform.Log(LogLevel.Error, ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            isNeedReload = false;
            if (MessageBox.Show(IsPrimaryCurrencyChanged ? SR.ConfirmPrimaryCurrencyChanged : SR.ConfirmPrimaryExRateCurrencyChanged, "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                isNeedReload = true;
                foreach (var item in ListCurreices)
                {
                    item.IsPrimaryCurrency = false;
                    item.IsPrimaryExRateCurrency = false;

                }
                NewPrimaryCurrency.IsPrimaryCurrency = true;
                NewPrimaryExRateCurrency.IsPrimaryExRateCurrency = true;

                Platform.GetService<ICurrencyService>(delegate(ICurrencyService service)
                {
                    ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.Billing.ChangePrimaryCurrencyRequest request = new ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.Billing.ChangePrimaryCurrencyRequest(
                        ListCurreices,
                        CurrentPrimaryCurrency,
                        NewPrimaryCurrency,
                        CurrentPrimaryExRateCurrency,
                        NewPrimaryExRateCurrency);
                    service.ChangePrimaryAndExRateCurrency(request);

                });
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isNeedReload = false;
            this.Close();
        }

        private void frmSetPrimaryCurrency_Load(object sender, EventArgs e)
        {

            this.txtPrimaryCurrency.Value = string.Format(SR.CurrencyDisplayFormat, CurrentPrimaryCurrency.CurrencyCode, CurrentPrimaryCurrency.CurrencyName);
            this.txtPrimaryCurrnecyRate.Value = CurrentPrimaryCurrency.RateToPrimaryCurrency.ToString();
            this.txtPrimaryExRateCurrency.Value = string.Format(SR.CurrencyDisplayFormat, CurrentPrimaryExRateCurrency.CurrencyCode, CurrentPrimaryExRateCurrency.CurrencyName);
            this.txtRate.Value = CurrentPrimaryExRateCurrency.RateToPrimaryCurrency.ToString();
            this.cmbNewPrimary.Value = SelectedPrimary;
            this.cmbNewPrimaryExRate.Value = SelectedPrimaryExrate;
            cmbNewPrimary.Enabled = IsPrimaryCurrencyChanged;
            txtSelectedRateToPrimaryExrate.Enabled = IsPrimaryCurrencyChanged;
            cmbNewPrimaryExRate.Enabled = IsPrimaryExRateCurrencyChanged;
            txtSelectedPrimaryExrateToExRate.Enabled = IsPrimaryExRateCurrencyChanged;
        }

        private void cmbNewPrimary_ValueChanged(object sender, EventArgs e)
        {
            var cmb = (sender as System.Windows.Forms.ComboBox);
            if (cmb.SelectedValue == null)
                return;
            NewPrimaryCurrency = ListCurreices.FirstOrDefault(x => x.CurrencyCode == (cmb.SelectedValue as DisplayCurrency).Value);
            this.txtSelectedRateToPrimaryExrate.Value = NewPrimaryCurrency.RateToPrimaryCurrency.ToString();
        }

        private void cmbNewPrimaryExRate_ValueChanged(object sender, EventArgs e)
        {
            var cmb = (sender as System.Windows.Forms.ComboBox);
            if (cmb.SelectedValue == null)
                return;
            NewPrimaryExRateCurrency = ListCurreices.FirstOrDefault(x => x.CurrencyCode == (cmb.SelectedValue as DisplayCurrency).Value);
            this.txtSelectedPrimaryExrateToExRate.Value = NewPrimaryExRateCurrency.RateToPrimaryCurrency.ToString();
        }
    }
}
