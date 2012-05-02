using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading;
namespace ClearCanvas.Common.Utilities
{
    public class NumberUtils
    {
        public static string numberFormat = "";
        public static NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol | NumberStyles.AllowParentheses | NumberStyles.AllowDecimalPoint;
        public static string CurrentLocale
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture.Name;
            }
            set
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(value);
            }
        }
        //public static string GetDisplayFormat(object number, string customformat)
        //{
        //    if (number == null)
        //        return "";
        //    decimal tmp = 0;
        //    if (!ParseNumber(number.ToString(), out tmp))
        //        return number.ToString();
        //    return tmp.ToString("c");
        //}
        //public static string GetCurrencyDisplayFormat(object number, string customformat)
        //{
        //    if (number == null)
        //        return "";
        //    double tmp = 0;
        //    if (!double.TryParse(number.ToString(), style, Thread.CurrentThread.CurrentCulture, out tmp))
        //        return number.ToString();
        //    if (!string.IsNullOrEmpty(customformat))
        //        return tmp.ToString(customformat);
        //    return tmp.ToString("c");
        //}
        //public static string GetCurrencyDisplayFormat(object number)
        //{
        //    return GetCurrencyDisplayFormat(number, "");
        //}
        public static string GetCurrencyDisplayFormat(string displaylocale, string customformat, object number)
        {
            try
            {
                if (number == null)
                    return "";
                
                CultureInfo c = new CultureInfo(displaylocale);
                double result = 0;

                // return result.ToString("c", c);
                if (!double.TryParse(number.ToString(), out result))
                    return number.ToString();
                if (!string.IsNullOrEmpty(customformat))
                    return result.ToString(customformat);
                return result.ToString("c",c);
            }
            catch (Exception ex)
            {
                Platform.Log(LogLevel.Error, ex, ex.Message);
                return number.ToString();
            }
            return number.ToString();
        }
        public static bool ParseNumber(object number, string locale, out decimal result)
        {
            result = 0;
            if (number == null)
            {

                return false;
            }
            double tmp = 0;
            if (!double.TryParse(number.ToString(), style, new CultureInfo(locale), out tmp))
                return false;
            result =(decimal) tmp;
            return true;
        }
    }
}
;