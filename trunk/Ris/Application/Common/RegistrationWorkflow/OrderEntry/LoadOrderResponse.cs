using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry
{
    [DataContract]
    public class LoadOrderResponse
    {
        public LoadOrderResponse(IList<EntityRef> orders, IList<OrderDetail> details)
        {
            orderList = orders;
            orderDetailList = details;
        }

        [DataMember]
        public IList<EntityRef> orderList;

        [DataMember]
        public IList<OrderDetail> orderDetailList;

    }
}
