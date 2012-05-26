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
        public class UpdateOrderInvoicesRequest : DataContractBase
        {
            public UpdateOrderInvoicesRequest(OrderInvoicesDetail objectdetail)
            {
                this.ObjectDetail = objectdetail;
                
            }

            [DataMember]
            public OrderInvoicesDetail ObjectDetail;
            
        }
    
}
