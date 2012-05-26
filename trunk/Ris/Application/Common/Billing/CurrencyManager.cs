using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClearCanvas.Ris.Application.Common.Billing
{
    public class CurrencyManager
    {
        /// <summary>
        /// Converts currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public static decimal ConvertCurrency(decimal amount, CurrencyDetail sourceCurrencyCode,
            CurrencyDetail targetCurrencyCode,CurrencyDetail PrimaryExchangeRateCurrency)
        {
            decimal result = amount;
            if (sourceCurrencyCode.CurrencyCode == targetCurrencyCode.CurrencyCode)
                return result;
            if (result != decimal.Zero && sourceCurrencyCode.CurrencyCode != targetCurrencyCode.CurrencyCode)
            {
                result = ConvertToPrimaryExchangeRateCurrency(result, sourceCurrencyCode.GetSummary(), PrimaryExchangeRateCurrency.GetSummary());
                result = ConvertFromPrimaryExchangeRateCurrency(result, targetCurrencyCode.GetSummary(), PrimaryExchangeRateCurrency.GetSummary());
            }
            result = Math.Round(result, 2);
            return result;
        }

        /// <summary>
        /// Converts to primary exchange rate currency 
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrencyCode">Source currency code</param>
        /// <returns>Converted value</returns>
        public static decimal ConvertToPrimaryExchangeRateCurrency(decimal amount,
            CurrencySummary sourceCurrencyCode, CurrencySummary PrimaryExchangeRateCurrency)
        {
            decimal result = amount;
            if (result != decimal.Zero && sourceCurrencyCode.CurrencyCode != PrimaryExchangeRateCurrency.CurrencyCode)
            {
                decimal exchangeRate = sourceCurrencyCode.RateToPrimaryCurrency;
                if (exchangeRate == decimal.Zero)
                    throw new Exception(string.Format("Exchange rate not found for currency [{0}]", sourceCurrencyCode.CurrencyName));
                result = result / exchangeRate;
            }
            return result;
        }

        /// <summary>
        /// Converts from primary exchange rate currency
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="targetCurrencyCode">Target currency code</param>
        /// <returns>Converted value</returns>
        public static decimal ConvertFromPrimaryExchangeRateCurrency(decimal amount,
            CurrencySummary targetCurrencyCode,CurrencySummary PrimaryExchangeRateCurrency)
        {
            decimal result = amount;
            if (result != decimal.Zero && targetCurrencyCode.CurrencyCode != PrimaryExchangeRateCurrency.CurrencyCode)
            {
                decimal exchangeRate = targetCurrencyCode.RateToPrimaryCurrency;
                if (exchangeRate == decimal.Zero)
                    throw new Exception(string.Format("Exchange rate not found for currency [{0}]", targetCurrencyCode.CurrencyName));
                result = result * exchangeRate;
            }
            return result;
        }
    }
}
