using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearCanvas.Ris.Application.Common.Billing
{
    public enum DiscountInsuranceClassType
    { 
        NONE,
        DISCOUNT,
        INSURANCE
    }
    public class Util
    {
      public static TEnum GetEnumFromString<TEnum> (string enumName)
        {
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {
                if (item.ToString() == enumName)
                {
                    return (TEnum)item;
                }
            }
            return (TEnum)Enum.Parse(typeof(TEnum), "Null");
        }

      public static TEnum GetEnumFromString<TEnum>(string enumName, TEnum defaultValue)
      {
          
          foreach (var item in Enum.GetValues(typeof(TEnum)))
          {
              if (item.ToString() == enumName)
              {
                  return (TEnum)item;
              }
          }
          return defaultValue;
      }
    }
}
