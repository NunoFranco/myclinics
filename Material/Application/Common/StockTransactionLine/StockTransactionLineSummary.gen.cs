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
using System.Runtime.Serialization;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Material.Application.Common.StockTransactions;


namespace ClearCanvas.Material.Application.Common.StockTransactionLines
{
    [DataContract]
    public partial class StockTransactionLineSummary : DataContractBase, IEquatable<StockTransactionLineSummary>
    {
        public StockTransactionLineSummary(EntityRef entityRef, double _amount,
double _inputprice,
double _saleprice,
double _insuranceprice,
double _soldamount,
DateTime? _expiredate,
double _tax,
bool _deactivated,
ProcedureTypeSummary _material,
EnumValueInfo _uom,
StockTransactionSummary _transaction,
FacilitySummary _clinic)
        {
            this.objRef = entityRef;
            Amount = _amount;
            InputPrice = _inputprice;
            SalePrice = _saleprice;
            InsurancePrice = _insuranceprice;
            SoldAmount = _soldamount;
            ExpireDate = _expiredate;
            Tax = _tax;
            Deactivated = _deactivated;
            Material = _material;
            UOM = _uom;
            Transaction = _transaction;
            Clinic = _clinic;


            CustomConstructor();
        }

        public StockTransactionLineSummary()
        {
            CustomConstructor();
        }

        [DataMember]
        public EntityRef objRef;

        [DataMember]
        public double Amount;
        [DataMember]
        public double InputPrice;
        [DataMember]
        public double SalePrice;
        [DataMember]
        public double InsurancePrice;
        [DataMember]
        public double SoldAmount;
        [DataMember]
        public DateTime? ExpireDate;
        [DataMember]
        public double Tax;
        [DataMember]
        public bool Deactivated;
        [DataMember]
        public ProcedureTypeSummary Material;
        [DataMember]
        public EnumValueInfo UOM;
        [DataMember]
        public StockTransactionSummary Transaction;
        [DataMember]
        public FacilitySummary Clinic;


        public bool Equals(StockTransactionLineSummary that)
        {
            if (that == null) return false;
            return Equals(this.objRef, that.objRef);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as StockTransactionLineSummary);
        }

        public override int GetHashCode()
        {
            if (objRef != null)
                return objRef.GetHashCode();
            return -1;
        }
    }
}