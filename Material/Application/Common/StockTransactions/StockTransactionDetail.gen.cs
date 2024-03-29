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
using ClearCanvas.Material.Application.Common.Warehouses;
using ClearCanvas.Material.Application.Common.Contacts;
using ClearCanvas.Material.Application.Common.MaterialLots;
using ClearCanvas.Enterprise.Common.Admin.UserAdmin;
using ClearCanvas.Material.Application.Common.StockTransactionLines;


namespace ClearCanvas.Material.Application.Common.StockTransactions
{
    [DataContract]
    public partial class StockTransactionDetail : DataContractBase
    {
        public StockTransactionDetail()
        {
            Code = "";
            TransactionDate = DateTime.Now;
            Description = "";
            Details = new List<StockTransactionLineSummary>();
            CustomConstructor();
        }

        public StockTransactionDetail(EntityRef entityRef,
            string _code,
            string _description,
            DateTime _transactiondate,
            bool _deactivated,
            ContactSummary _supplier,
            WarehouseSummary _inwarehouse,
            WarehouseSummary _outwarehouse,
            MaterialLotSummary _equipmentlot,
            OrderSummary _order,
            UserSummary _user,
            EnumValueInfo _transactiontype,
            FacilitySummary _clinic,
            List<StockTransactionLineSummary> _details)
        {
            StockTransactionRef = entityRef;
            Code = _code;
            Description = _description;
            TransactionDate = _transactiondate;
            Deactivated = _deactivated;
            Supplier = _supplier;
            InWarehouse = _inwarehouse;
            OutWarehouse = _outwarehouse;
            EquipmentLot = _equipmentlot;
            Order = _order;
            User = _user;
            TransactionType = _transactiontype;
            Clinic = _clinic;
            Details = _details;


            CustomConstructor();
        }
        [DataMember]
        public EntityRef StockTransactionRef;
        [DataMember]
        public string Code;
        [DataMember]
        public string Description;
        [DataMember]
        public DateTime? TransactionDate;
        [DataMember]
        public bool Deactivated;
        [DataMember]
        public ContactSummary Supplier;
        [DataMember]
        public WarehouseSummary InWarehouse;
        [DataMember]
        public WarehouseSummary OutWarehouse;
        [DataMember]
        public MaterialLotSummary EquipmentLot;
        [DataMember]
        public OrderSummary Order;
        [DataMember]
        public UserSummary User;
        [DataMember]
        public EnumValueInfo TransactionType;
        [DataMember]
        public FacilitySummary Clinic;
        [DataMember]
        public List<StockTransactionLineSummary> Details;


        public StockTransactionSummary GetSummary()
        {
            return new StockTransactionSummary(this.StockTransactionRef, Code,
                Description,
                TransactionDate,
                Deactivated,
                Supplier,
                InWarehouse,
                OutWarehouse,
                EquipmentLot,
                Order,
                User,
                TransactionType,
                Clinic);
        }
    }
}
