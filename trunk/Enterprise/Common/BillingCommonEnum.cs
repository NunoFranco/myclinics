using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Enterprise.Common
{
    public enum OrderBillingStatusEnum
    {
        WAITING,
        PENDING,
        COLLECTEDINSURANCE,
        FINISHED,
    }
    public enum DisCountInsuranceAmountType
    {
        PERCENTAGE,
        REDUCEAMOUNT,
        FIXEDPRICE,
    }

    public enum WaitingInsuranceStatus
    {
        NOWAITING,
        WAITINGFORCONFIRM,
        CONFIRMED,
        REJECTED,
    }
    public static class CommonEnumList
    {
        //static List<string> GetEnumList<T>(T type)
        //{
        //    List<string> lst = new List<string>();
        //    foreach (var item in Enum.GetNames(typeof(type)))
        //    {
        //        lst.Add(item);
        //    }
        //    return lst;
        //}
        public static List<string> ListDisCountInsuranceAmountType {
            get {
                List<string> lst = new List<string>();
                foreach (var item in Enum.GetNames(typeof(DisCountInsuranceAmountType)))
                {
                    lst.Add(item);
                }
                return lst;
            }
        }

        public static List<string> ListOrderBillingStatusEnum
        {
            get
            {
                List<string> lst = new List<string>();
                foreach (var item in Enum.GetNames(typeof(OrderBillingStatusEnum)))
                {
                    lst.Add(item);
                }
                return lst;
            }
        }
    }

    public static class CommonEnumUtil
    {
        public static object GetEnumValue<T>(string enumValue)
        {
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                if (item.ToString() == enumValue.ToString())
                    return item;
            }
            return null;
        }
    }
}
