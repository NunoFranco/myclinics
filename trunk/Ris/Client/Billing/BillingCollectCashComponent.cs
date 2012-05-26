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

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Ris.Application.Common;
namespace ClearCanvas.Ris.Client.Billing
{
    /// <summary>
    /// Extension point for views onto <see cref="BillingCollectCashComponent"/>.
    /// </summary>
    [ExtensionPoint]
    public sealed class BillingCollectCashComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    /// <summary>
    /// BillingCollectCashComponent class.
    /// </summary>
    [AssociateView(typeof(BillingCollectCashComponentViewExtensionPoint))]
    public class BillingCollectCashComponent : ApplicationComponent
    {
        private readonly bool _isNew;
        private EntityRef _editedItemEntityRef;
        private OrderInvoicesDetail _editedItemDetail;
        private OrderInvoicesSummary _editedItemSummary;

        /// <summary>
        /// Constructor.
        /// </summary>
        public BillingCollectCashComponent()
        {
            _isNew = true;
        }

        public BillingCollectCashComponent(EntityRef entityRef)
        {
            _editedItemEntityRef = entityRef;
            _isNew = false;
        }
        /// <summary>
        /// Called by the host to initialize the application component.
        /// </summary>
        public override void Start()
        {
            Platform.GetService<IOrderInvoicesService>(
               delegate(IOrderInvoicesService service)
               {
                   if (_isNew)
                   {
                       _editedItemDetail = new OrderInvoicesDetail();
                   }
                   else
                   {
                       LoadOrderInvoicesEditResponse response =
                           service.LoadOrderInvoicesForedit(
                               new LoadOrderInvoicesEditRequest(_editedItemEntityRef));

                       _editedItemEntityRef = response.EntityRef;
                       _editedItemDetail = response.ObjectDetail;
                       //_selectedProcedureTypes.Items.AddRange(_editedItemDetail.ProcedureTypes);
                   }
               });
            base.Start();
        }

        /// <summary>
        /// Called by the host when the application component is being terminated.
        /// </summary>
        public override void Stop()
        {
            // TODO prepare the component to exit the live phase
            // This is a good place to do any clean up
            base.Stop();
        }
        public string OrderNumber
        {
            get;
            set;
            //get{
            //    if (_editedItemDetail.OrderRef == null)
            //        return "";
            //    return Platform.GetService<IOrderEntryService>()
            //        .GetOrderRequisitionForEdit(new GetOrderRequisitionForEditRequest(_editedItemDetail.OrderRef)
            //            ).Requisition.OrderNumber;
            //}   
            //set {
            //   IList<OrderDetail> orders= Platform.GetService<IOrderEntryService>()
            //        .LoadOrder(new LoadOrderRequest(value)).orderDetailList;
            //   if (orders.Count == 0)
            //       return;
            //   _editedItemDetail.OrderRef = orders[0].OrderRef;
            //}
        }
        public string InvoiceNumber
        {
            get
            {
                return _editedItemDetail.InvoiceNumber;
            }
            set
            {
                _editedItemDetail.InvoiceNumber = value;
            }
        }
        public decimal Totalcollect
        {
            get
            {
                return _editedItemDetail.TotalCollect;
            }
            set
            {

                _editedItemDetail.TotalCollect = value;
            }
        }
        public decimal TotalInsurance
        {
            get
            {
                return _editedItemDetail.TotalInsurance;
            }
            set
            {

                _editedItemDetail.TotalInsurance = value;
            }
        }
        public decimal TotalDiscount
        {
            get
            {
                return _editedItemDetail.TotalDiscount;
            }
            set
            {

                _editedItemDetail.TotalDiscount = value;
            }
        }
        public decimal TotalReceived
        {
            get
            {
                return _editedItemDetail.TotalReceived;
            }
            set
            {

                _editedItemDetail.TotalReceived = value;
            }
        }
        public decimal TotalChanges
        {
            get
            {
                return _editedItemDetail.TotalChanges;
            }
            set
            {

                _editedItemDetail.TotalChanges = value;
            }
        }

        public decimal TotalWaitingAmount
        {
            get
            {
                return _editedItemDetail.TotalWaitingAmount;
            }
            set
            {

                _editedItemDetail.TotalWaitingAmount = value;
            }
        }
        public string ListOrderInvoiceProcedure//procedure in history
        {
            get
            {
                return _editedItemDetail.ListProcedures;
            }
            set
            {

                _editedItemDetail.ListProcedures = value;
            }
        }
        public OrderInvoicesDetail Details
        {
            get
            {
                return _editedItemDetail;
            }
            set
            {
                _editedItemDetail = value;
            }
        }
        public bool SaveChanges(bool isNew)
        {
            IList<OrderDetail> orderlist = Platform.GetService<IOrderEntryService>().LoadOrder(new LoadOrderRequest(OrderNumber)).orderDetailList;
            if (orderlist == null)
            {
                //show alert messages
                Platform.Log(LogLevel.Error, "Order list is Empty");
                return false;

            }
            bool result = true;
            OrderDetail currentSelectedOrder = orderlist[0];
            _editedItemDetail.OrderRef = currentSelectedOrder.OrderRef;

            Platform.GetService<IOrderInvoicesService>(
                        delegate(IOrderInvoicesService service)
                        {
                            if (isNew)
                            {
                                AddOrderInvoicesResponse response =
                                    service.AddOrderInvoices(new AddOrderInvoicesRequest(_editedItemDetail));
                                if (response == null)
                                {
                                    result = false;
                                }
                                else
                                {
                                    _editedItemEntityRef = response.ObjectSummary.OrderInvoiceRef;
                                    _editedItemSummary = response.ObjectSummary;
                                }
                            }
                            else
                            {

                                UpdateOrderInvoicesResponse response =
                                    service.UpdateOrderInvoices(new UpdateOrderInvoicesRequest(_editedItemDetail));
                                if (response == null)
                                    result = false;
                                else
                                {
                                    _editedItemEntityRef = response.ObjectSummary.OrderInvoiceRef;
                                    _editedItemSummary = response.ObjectSummary;
                                }
                            }
                        });
            return result;
        }
    }
}
