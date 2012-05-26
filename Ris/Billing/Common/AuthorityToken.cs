using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Common.Authorization;

namespace ClearCanvas.Ris.Billing.Common
{
    public static class AuthorityTokens
    {

        public class Billing
        {
            public static class Admin
            {
                [AuthorityToken(Description = "Allow administration Manage Price Discount.")]
                public const string BillingManageInsurancePrice = "RIS/Billing/Admin/Manage Price Insurance";

                [AuthorityToken(Description = "Allow administration Manage Price Discount.")]
                public const string BillingManageDiscountPrice = "RIS/Billing/Admin/Manage Price Discount";

                [AuthorityToken(Description = "Allow administration Manage Currency.")]
                public const string BillingManageCurrency = "RIS/Billing/Admin/Currency";

                //[AuthorityToken(Description = "Allow administration Discount Types.")]
                //public const string BillingManageDiscountType = "RIS/Billing/Admin/Manage Discount Type";

                //[AuthorityToken(Description = "Allow administration Insurance Types.")]
                //public const string BillingManageInsuranceType = "RIS/Billing/Admin/Manage Insurance Type";
            }

            public static class Reports
            {
                [AuthorityToken(Description = "Allow View Reports.")]
                public const string BillingReportsServiceType = "RIS/Billing/Reports/Service Types";

                [AuthorityToken(Description = "Allow View Reports")]
                public const string BillingReportsDoctor = "RIS/Billing/Reports/Doctor";

                [AuthorityToken(Description = "Allow View Reports")]
                public const string BillingReportsFacility = "RIS/Billing/Reports/Facility";

                [AuthorityToken(Description = "Allow View Reports")]
                public const string BillingReportsRevenue = "RIS/Billing/Reports/Revenue";

                [AuthorityToken(Description = "Allow View Reports")]
                public const string BillingReportsModality = "RIS/Billing/Reports/Modality";
            }

            public static class Screen
            {
                [AuthorityToken(Description = "Allow Access Collect Screen Form.")]
                public const string BillingCollectScreen = "RIS/Billing/Collect Screen";
            }
        }
    }
}
