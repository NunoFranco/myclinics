#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Imex;
using ClearCanvas.Healthcare.Brokers;

namespace ClearCanvas.Healthcare.Imex
{
    [ExtensionOf(typeof(XmlDataImexExtensionPoint))]
    [ImexDataClass("Currency")]
    public class CurrencyImex : XmlEntityImex<Currency, CurrencyImex.CurrencyData>
    {
        [DataContract]
        public class CurrencyData : ReferenceEntityDataBase
        {
            [DataMember]
            public string CurrencyCode;

            [DataMember]
            public string CurrencyName;

            [DataMember]
            public decimal RateToPrimaryExRate;

            [DataMember]
            public string DisplayLocale;

            [DataMember]
            public string CustomDisplayFormat;

            [DataMember]
            public bool IsPrimaryCurrency;

            [DataMember]
            public bool IsPrimaryExRateCurrency;

            [DataMember]
            public string CreatedUser;

            [DataMember]
            public ClinicData Clinic;

        }


        #region Overrides

        protected override IList<Currency> GetItemsForExport(IReadContext context, int firstRow, int maxRows)
        {
            CurrencySearchCriteria where = new CurrencySearchCriteria();
            where.CurrencyCode.SortAsc(0);

            return context.GetBroker<ICurrencyBroker>().Find(where, new SearchResultPage(firstRow, maxRows));
        }

        protected override CurrencyData Export(Currency entity, IReadContext context)
        {
            CurrencyData data = new CurrencyData();
            data.Deactivated = entity.Deactivated;
            data.CurrencyCode = entity.CurrencyCode;
            data.CurrencyName = entity.CurrencyName;
            data.CustomDisplayFormat = entity.CustomDisplayFormat;
            data.DisplayLocale = entity.DisplayLocale;
            data.IsPrimaryCurrency = entity.IsPrimaryCurrency;
            data.IsPrimaryExRateCurrency = entity.IsPrimaryExRateCurrency;
            data.RateToPrimaryExRate = entity.RateToPrimaryExRate;
            data.CreatedUser = entity.CreatedUser;
            data.Clinic = new ClinicData(entity.Clinic);
            return data;
        }

        protected override void Import(CurrencyData data, string ClinicCode, IUpdateContext context)
        {
            Currency Currency = GetCurrency(data.CurrencyCode, data, Common.GetClinic(ClinicCode,context), context);
            Currency.Deactivated = data.Deactivated;
            Currency.CurrencyCode = data.CurrencyCode;
            Currency.CurrencyName = data.CurrencyName;
            Currency.CustomDisplayFormat = data.CustomDisplayFormat;
            Currency.DisplayLocale = data.DisplayLocale;
            Currency.IsPrimaryCurrency = true;

            Currency.IsPrimaryExRateCurrency = true;

            Currency.RateToPrimaryExRate = data.RateToPrimaryExRate;
            Currency.CreatedOn = System.DateTime.Now;
            Currency.LastUpdated = System.DateTime.Now;
        }

        #endregion


        private Currency GetCurrency(string currencyCode, CurrencyData data, Facility  Clinic, IPersistenceContext context)
        {
            Currency Currency = null;

            try
            {
                CurrencySearchCriteria criteria = new CurrencySearchCriteria();
                criteria.CurrencyCode.EqualTo(currencyCode);
                criteria.Clinic.EqualTo(Clinic);

                ICurrencyBroker broker = context.GetBroker<ICurrencyBroker>();
                Currency = broker.FindOne(criteria);
            }
            catch (EntityNotFoundException)
            {
                Currency = new Currency();
                Currency.Deactivated = data.Deactivated;
                Currency.CurrencyCode = data.CurrencyCode;
                Currency.CurrencyName = data.CurrencyName;
                Currency.CustomDisplayFormat = data.CustomDisplayFormat;
                Currency.DisplayLocale = data.DisplayLocale;
                Currency.IsPrimaryCurrency = true;
                Currency.IsPrimaryExRateCurrency = true;
                Currency.RateToPrimaryExRate = data.RateToPrimaryExRate;
                Currency.CreatedOn = System.DateTime.Now;
                Currency.LastUpdated = System.DateTime.Now;
                Currency.Clinic = Clinic;
                context.Lock(Currency, DirtyState.New);
            }
            return Currency;
        }
    }
}
