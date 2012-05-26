using System.IO;
using System.Text;
using System.Collections.Generic;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Healthcare;
using System.Xml;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Ris.Application.Common.Billing;
using System;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common;
using System.Threading;
namespace ClearCanvas.Ris.Application.Services.Billing
{
    public class CurrencyAssembler
    {

        public CurrencySummary CreateSummary(Currency objectSummary)
        {
            return new CurrencySummary(objectSummary.GetRef(),
                objectSummary.CurrencyCode,
                objectSummary.CurrencyName,
                objectSummary.RateToPrimaryExRate,
                objectSummary.DisplayLocale,
                objectSummary.CustomDisplayFormat,
                objectSummary.IsPrimaryCurrency,
                objectSummary.IsPrimaryExRateCurrency,
                objectSummary.Deactivated);
        }
        public CurrencyDetail CreateDetail(Currency objectSummary)
        {
            FacilityAssembler assembler = new FacilityAssembler();
            return new CurrencyDetail(objectSummary.GetRef(),
                objectSummary.CurrencyCode,
                objectSummary.CurrencyName,
                objectSummary.RateToPrimaryExRate,
                objectSummary.DisplayLocale,
                objectSummary.CustomDisplayFormat,
                objectSummary.IsPrimaryCurrency,
                objectSummary.IsPrimaryExRateCurrency,
                objectSummary.Deactivated,
                objectSummary.CreatedOn,
                objectSummary.LastUpdated,
                objectSummary.CreatedUser, assembler.CreateFacilitySummary(objectSummary.Clinic));
        }

        public void UpdateCurrencyClass(Currency objectClass, CurrencyDetail objectdetail, IPersistenceContext context)
        {
            objectClass.CurrencyCode = objectdetail.CurrencyCode;
            objectClass.CurrencyName = objectdetail.CurrencyName;
            objectClass.CustomDisplayFormat = objectdetail.CustomDisplayFormat;
            objectClass.Deactivated = objectdetail.Deactivated;
            objectClass.DisplayLocale = objectdetail.DisplayLocale;
            objectClass.IsPrimaryCurrency = objectdetail.IsPrimaryCurrency;
            objectClass.IsPrimaryExRateCurrency = objectdetail.IsPrimaryExRateCurrency;
            objectClass.RateToPrimaryExRate = objectdetail.RateToPrimaryCurrency;
            objectClass.Clinic = context.Load<Facility>(objectdetail.Clinic.FacilityRef);
            //objectClass.CreatedOn = System.DateTime.Now;
            //objectClass.LastUpdated = System.DateTime.Now;
            //objectClass.CreatedUser = Thread.CurrentPrincipal.Identity.Name;
        }
    }
}
