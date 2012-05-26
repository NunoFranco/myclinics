using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common.Billing;
namespace ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO
{
    [DataContract]
    public class ListOrderInvoicesRequest : ListRequestBase
    {
        public ListOrderInvoicesRequest()
        {

        }
        public ListOrderInvoicesRequest(string invoicenumber, EntityRef FacilityRef)
        {
            InvoiceNumber = invoicenumber;
            ClinicRef = FacilityRef;
        }
        public ListOrderInvoicesRequest(string invoicenumber, EntityRef orderref, EntityRef FacilityRef)
        {
            InvoiceNumber = invoicenumber;
            OrderRef = orderref;
            ClinicRef = FacilityRef;
        }
        public ListOrderInvoicesRequest(SearchResultPage page, EntityRef FacilityRef)
            : base(page, FacilityRef)
        {

        }

        [DataMember]
        public string InvoiceNumber;
        [DataMember]
        public DateTime? fromdate;
        [DataMember]
        public DateTime? todate;
        [DataMember]
        public EntityRef OrderRef;

        [DataMember]
        public string OrderNumber;

        [DataMember]
        public EntityRef ClinicRef;
    }
}
