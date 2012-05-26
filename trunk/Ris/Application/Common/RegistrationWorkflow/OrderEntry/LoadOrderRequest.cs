using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;
namespace ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry
{
    [DataContract]
    public class LoadOrderRequest:DataContractBase
    {
        public LoadOrderRequest(EntityRef orderSearchCriteria, string ordernumber)
        {
            _orderSearchCriteria = orderSearchCriteria;
            OrderNumber = "";
        }
        public LoadOrderRequest(string ordernumber)
        {
            _orderSearchCriteria = null;
            OrderNumber = ordernumber;
        }
        public LoadOrderRequest(DateTime startTimeEnteredOrder, DateTime endTimeEnteredOrder)
        {
            StartTimeEnteredOrder = startTimeEnteredOrder;
            EndTimeEnteredOrder = endTimeEnteredOrder;
        }
        [DataMember]
        EntityRef _orderSearchCriteria;

        [DataMember]
        public string OrderNumber;

        [DataMember]
        public DateTime? StartTimeEnteredOrder;

        [DataMember]
        public DateTime? EndTimeEnteredOrder;
    }
}
