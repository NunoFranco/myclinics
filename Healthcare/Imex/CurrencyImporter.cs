﻿#region License

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
using System.Text;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core.Imex;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Healthcare.Imex
{
    [ExtensionOf(typeof(CsvDataImporterExtensionPoint), Name = "Currency Importer")]
    [ExtensionOf(typeof(ApplicationRootExtensionPoint))]
    class CurrencyImporter : CsvDataImporterBase
    {
        private const int _numFields = 9;

        private IPersistenceContext _context;

        #region CsvDataImporterBase overrides

        /// <summary>
        /// Import Currency from CSV format.
        /// </summary>
        /// <param name="rows">
        /// Each string in the list must contain 25 CSV fields, as follows:
        ///     0 - UserName
        ///     1 - CurrencyType
        ///     2 - Id
        ///     3 - FamilyName
        ///     4 - GivenName
        ///     5 - MiddleName
        ///     6 - Prefix
        ///     7 - Suffix
        ///     8 - Degree
        /// </param>
        /// <param name="context"></param>
        public override void Import(List<string> rows, IUpdateContext context)
        {
            _context = context;

            List<Currency> importedCurrency = new List<Currency>();

            foreach (string row in rows)
            {
                string[] fields = ParseCsv(row, _numFields);

                string CurrencyCode = fields[0];
                string CurrencyName = fields[1];
                string RateToPrimaryExRate = fields[2];
                string DisplayLocale = fields[3];
                string CustomDisplayFormat = fields[4];
                string IsPrimaryCurrency = fields[5];
                string IsPrimaryExRateCurrency = fields[6];
                string Deactivated = fields[7];
                string CreatedUser = fields[8];

                Currency Currency = GetCurrency(CurrencyCode, importedCurrency);

                if (Currency == null)
                {
                    Currency = new Currency();

                    Currency.CurrencyCode = CurrencyCode;
                    Currency.CurrencyName = CurrencyName;
                    Currency.CustomDisplayFormat = CustomDisplayFormat;
                    Currency.DisplayLocale = DisplayLocale;
                    Currency.IsPrimaryCurrency =bool.Parse( IsPrimaryCurrency);
                    Currency.IsPrimaryExRateCurrency = bool.Parse(IsPrimaryExRateCurrency);
                    Currency.RateToPrimaryExRate = decimal.Parse(RateToPrimaryExRate);
                    Currency.CreatedUser = CreatedUser;
                    Currency.Deactivated = bool.Parse(Deactivated);
                    Currency.CreatedOn = System.DateTime.Now;
                    Currency.LastUpdated = System.DateTime.Now;
                    _context.Lock(Currency, DirtyState.New);

                    importedCurrency.Add(Currency);
                }

            }
        }

        #endregion

        #region Private Methods

        private Currency GetCurrency(string CurrencyCode, IList<Currency> importedCurrency)
        {
            Currency Currency = null;

            Currency = CollectionUtils.SelectFirst<Currency>(importedCurrency,
                delegate(Currency s) { return s.CurrencyCode == CurrencyCode; });

            if (Currency == null)
            {
                CurrencySearchCriteria criteria = new CurrencySearchCriteria();
                criteria.CurrencyCode.EqualTo(CurrencyCode);

                ICurrencyBroker broker = _context.GetBroker<ICurrencyBroker>();
                Currency = CollectionUtils.FirstElement(broker.Find(criteria));
            }

            return Currency;
        }

        #endregion

    }
}