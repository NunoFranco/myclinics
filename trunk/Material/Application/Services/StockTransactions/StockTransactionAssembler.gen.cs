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

using System.Collections.Generic;
using System.IO;
using System.Text;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Material.Healthcare;
using ClearCanvas.Material.Application.Common.StockTransactions;
using System.Xml;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Material.Application.Services.Warehouses;
using ClearCanvas.Material.Application.Services.Contacts;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Material.Application.Services.MaterialLots;
using ClearCanvas.Enterprise.Authentication;
using ClearCanvas.Healthcare;
using ClearCanvas.Enterprise.Authentication.Admin.UserAdmin;
using ClearCanvas.Material.Application.Common.StockTransactionLines;
using ClearCanvas.Enterprise.Common.Admin.UserAdmin;
using ClearCanvas.Material.Application.Common.StockTransactionLines;
using ClearCanvas.Material.Application.Services.StockTransactionLines;
using System;
namespace ClearCanvas.Material.Application.Services.StockTransactions
{

    public partial class StockTransactionAssembler
    {
        public StockTransactionSummary CreateSummary(StockTransaction obj, IPersistenceContext context)
        {
            WarehouseAssembler wAssembler = new WarehouseAssembler();
            ContactAssembler cAssembler = new ContactAssembler();
            OrderAssembler oAssembler = new OrderAssembler();
            MaterialLotAssembler mtAssembler = new MaterialLotAssembler();
            FacilityAssembler fAssembler = new FacilityAssembler();
            UserAssembler uAssembler = new UserAssembler();
            UserSummary user = uAssembler.GetUserSummary(obj.User);
            //if (obj.User != null)
            //    user = new Enterprise.Common.Admin.UserAdmin.UserSummary(obj.User.UserName,
            //        obj.User.DisplayName, obj.User.CreationTime, obj.User.ValidFrom, obj.User.ValidUntil, obj.User.LastLoginTime, obj.User.Enabled);

            return new StockTransactionSummary(obj.GetRef(), obj.Code,
                    obj.Description,
                    obj.TransactionDate,
                    obj.Deactivated,
                    cAssembler.CreateSummary(obj.EquipmentLot.Supplier),
                    wAssembler.CreateSummary(obj.InWarehouse),
                    obj.OutWarehouse != null ? wAssembler.CreateSummary(obj.OutWarehouse) : null,
                    mtAssembler.CreateSummary(obj.EquipmentLot),
                    obj.Order != null ? oAssembler.CreateOrderSummary(obj.Order, context) : null,
                    user,
                    EnumUtils.GetEnumValueInfo(obj.TransactionType),
                    fAssembler.CreateFacilitySummary(obj.Clinic));

        }

        public StockTransactionDetail CreateDetail(StockTransaction obj, IPersistenceContext context)
        {
            WarehouseAssembler wAssembler = new WarehouseAssembler();
            ContactAssembler cAssembler = new ContactAssembler();
            OrderAssembler oAssembler = new OrderAssembler();
            MaterialLotAssembler mtAssembler = new MaterialLotAssembler();
            FacilityAssembler fAssembler = new FacilityAssembler();
            UserAssembler uAssembler = new UserAssembler();
            UserSummary user = uAssembler.GetUserSummary(obj.User);
            StockTransactionLineAssembler stlAssembler = new StockTransactionLineAssembler();
            //if (obj.User != null)
            //    user = new Enterprise.Common.Admin.UserAdmin.UserSummary(obj.User.UserName,
            //        obj.User.DisplayName, obj.User.CreationTime, obj.User.ValidFrom, obj.User.ValidUntil, obj.User.LastLoginTime, obj.User.Enabled);

            return new StockTransactionDetail(
                obj.GetRef(), obj.Code,
                obj.Description,
                obj.TransactionDate,
                obj.Deactivated,
                cAssembler.CreateSummary(obj.Supplier),
                wAssembler.CreateSummary(obj.InWarehouse),
                wAssembler.CreateSummary(obj.OutWarehouse),
                mtAssembler.CreateSummary(obj.EquipmentLot),
                oAssembler.CreateOrderSummary(obj.Order, context),
                user,
                EnumUtils.GetEnumValueInfo(obj.TransactionType),
                fAssembler.CreateFacilitySummary(obj.Clinic),
                CollectionUtils.Map<StockTransactionLine, StockTransactionLineSummary>(obj.Details,
                        delegate(StockTransactionLine item)
                        {
                            return stlAssembler.CreateSummary(item, context);
                        }
                    )
                );

        }

        public void UpdateStockTransaction(StockTransaction obj, StockTransactionDetail detail, IPersistenceContext context)
        {
            //loop through property and set value
            obj.Code = detail.Code;
            obj.Description = detail.Description;
            obj.TransactionDate = (DateTime)detail.TransactionDate;
            obj.Deactivated = detail.Deactivated;
            obj.Supplier = context.Load<Contact>(detail.EquipmentLot.Supplier.objRef);
            obj.InWarehouse = context.Load<Warehouse>(detail.InWarehouse.objRef);
            if (detail.OutWarehouse != null)
            {
                obj.OutWarehouse = context.Load<Warehouse>(detail.OutWarehouse.objRef);
            }
            obj.EquipmentLot = context.Load<MaterialLot>(detail.EquipmentLot.objRef);
            if (detail.Order != null)
            {
                obj.Order = context.Load<Order>(detail.Order.OrderRef);
            }
            obj.User = new UserAdminService().FindUserByName(ClearCanvas.Enterprise.Common.Common.GetLoginUserName(System.Threading.Thread.CurrentPrincipal.Identity.Name));

            obj.TransactionType = EnumUtils.GetEnumValue<StockTransactionTypeEnum>(detail.TransactionType, context);
            obj.Clinic = context.Load<Facility>(detail.Clinic.FacilityRef);
            obj.Details.Clear();

            CollectionUtils.ForEach(detail.Details,
                delegate(StockTransactionLineSummary summary)
                {
                    StockTransactionLine item = new StockTransactionLine();
                    item.Material = context.Load<ProcedureType>(summary.Material.ProcedureTypeRef);
                    item.Amount = summary.Amount;
                    item.Clinic = context.Load<Facility>(summary.Clinic.FacilityRef);
                    item.Deactivated = summary.Deactivated;
                    item.ExpireDate = summary.ExpireDate;
                    item.InputPrice = summary.InputPrice;
                    item.InsurancePrice = summary.InsurancePrice;
                    item.SalePrice = summary.SalePrice;
                    item.SoldAmount = summary.SoldAmount;
                    item.Tax = summary.Tax;
                    item.Transaction = obj;
                    item.UOM = EnumUtils.GetEnumValue<UOMEnum>(summary.UOM, context);
                    obj.Details.Add(item);
                });
        }
    }
}
