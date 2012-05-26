using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Ris.Application.Common.Billing
{
    [DataContract]
    public class OrderInvoicesDetail : DataContractBase
    {
        public OrderInvoicesDetail(EntityRef invoiceRef
            , EntityRef orderRef
            , string invoicenumber
            , decimal totalcollect
            , decimal totaldiscount
            , decimal totalinsurance
            , decimal totalwaitingamount
, decimal totalrecevied
            , decimal totalchanged
            , string listProcedures
            , bool deactivated,DateTime createddate)
        {
            OrderInvoiceRef = invoiceRef;
            OrderRef = orderRef;
            InvoiceNumber = invoicenumber;
            TotalCollect = totalcollect;
            TotalDiscount = totaldiscount;
            TotalInsurance = totalinsurance;
            TotalWaitingAmount = totalwaitingamount;
            Deactivated = deactivated;
            TotalChanges = totalchanged;
            TotalReceived = totalrecevied;
            ListProcedures = listProcedures;
            CreatedDate = createddate;
        }
        public OrderInvoicesDetail()
        {

        }
        [DataMember]
        public EntityRef OrderInvoiceRef;

        [DataMember]
        public EntityRef OrderRef { get; set; }

        [DataMember]
        public string InvoiceNumber { get; set; }

        [DataMember]
        public bool Deactivated { get; set; }

        [DataMember]
        public decimal TotalCollect { get; set; }

        [DataMember]
        public decimal TotalInsurance { get; set; }

        [DataMember]
        public decimal TotalWaitingAmount { get; set; }

        [DataMember]
        public decimal TotalDiscount { get; set; }

        [DataMember]
        public bool IsFinished { get; set; }

        [DataMember]
        public decimal TotalReceived { get; set; }

        [DataMember]
        public decimal TotalChanges { get; set; }
    
        [DataMember]
        public string ListProcedures { get; set; }
 [DataMember]
        public DateTime CreatedDate { get; set; }

    }
}
