using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Enterprise.Common.Billing
{
    public class BillingOptions
    {
        public string PrimaryCurrency
        {
            get
            {
                return BillingOptionSetting.Default.PrimaryCurrency;
            }
            set
            {
                BillingOptionSetting.Default.PrimaryCurrency = value;
            }
        }
        public string SystemLanguague
        {
            get
            {
                return BillingOptionSetting.Default.SystemLanguague;
            }
            set
            {
                BillingOptionSetting.Default.SystemLanguague = value;
            }
        }
        public void Save()
        {
            BillingOptionSetting.Default.Save();
        }


    }
}
