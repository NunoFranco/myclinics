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
using System.Text;
using System.Runtime.Serialization;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Enterprise.Common;
using System.Xml;
using ClearCanvas.Material.Application.Common.StockTransactionLines;


namespace ClearCanvas.Material.Application.Common.ProcedureLines
{
    [DataContract]
    public partial class ProcedureLineDetail : DataContractBase
    {
        public ProcedureLineDetail()
        {
            CustomConstructor();
        }

        public ProcedureLineDetail(EntityRef entityRef, double _amount,
double _saleprice,
DateTime _createddate,
double _tax,
bool _isinsurancesale,
bool _deactivated,
ProcedureSummary _parentprocedure,
StockTransactionLineSummary _stocktransactionsdetails,
EnumValueInfo _uom)
        {
            ProcedureLineRef = entityRef;
            Amount = _amount;
            SalePrice = _saleprice;
            CreatedDate = _createddate;
            Tax = _tax;
            IsInsuranceSale = _isinsurancesale;
            Deactivated = _deactivated;
            ParentProcedure = _parentprocedure;
            StockTransactionsDetails = _stocktransactionsdetails;
            UOM = _uom;


            CustomConstructor();
        }
        [DataMember]
        public EntityRef ProcedureLineRef;
        [DataMember]
        public double Amount;
        [DataMember]
        public double SalePrice;
        [DataMember]
        public DateTime CreatedDate;
        [DataMember]
        public double Tax;
        [DataMember]
        public bool IsInsuranceSale;
        [DataMember]
        public bool Deactivated;
        [DataMember]
        public ProcedureSummary ParentProcedure;
        [DataMember]
        public StockTransactionLineSummary StockTransactionsDetails;
        [DataMember]
        public EnumValueInfo UOM;


        public ProcedureLineSummary GetSummary()
        {
            return new ProcedureLineSummary(this.ProcedureLineRef, Amount,
SalePrice,
CreatedDate,
Tax,
IsInsuranceSale,
Deactivated,
ParentProcedure,
StockTransactionsDetails,
UOM);
        }
    }
}
