using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin;
using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Client.Billing
{
    public class TotalInDate
    {
        public DateTime? Entered;
        public decimal Total;
        public string CollectCurrency;
    }
    public class ServiceTypesComponent
    {
        public ServiceTypesComponent()
        {

        }
        
        


        public List<ProcedureTypeSummary> ListProcedureType(EntityRef clinicRef)
        {
            
            List<ProcedureTypeSummary> ListData = new List<ProcedureTypeSummary>();
            Platform.GetService<IBillingService>(delegate(IBillingService service)
            {
                ListData = service.ListProcedureType(clinicRef);
            });            
            //List<ProcedureTypeReport> resultData = null;
            //foreach(ProcedureTypeSummary proType in ListData)
            //{
            //    ProcedureTypeReport cell = new ProcedureTypeReport();
            //    cell.procedureTypeSummary = proType;
            //    cell.Count = 0;
            //}
            
            return ListData;
        }

        public List<int> CountProcedureType(DateTime startTime, DateTime endTime, EntityRef ClinicRef)
        {
            List<ProcedureTypeSummary> list = ListProcedureType( ClinicRef);
            List<int> resultData = new List<int>(list.Count);
            for (int index = 0; index < list.Count; index++)
                resultData.Add(0);
            List<OrderDetail> ListOrder = new List<OrderDetail>();
            Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            {
                //resultData = service.CountProcedureType(startTime,endTime);
                ListOrder = service.LoadOrder(new ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry.LoadOrderRequest(startTime, endTime)).orderDetailList.ToList();
            });

            foreach(OrderDetail order in ListOrder)
            {
                for (int index = 0; index < list.Count; index++)
                {
                    foreach (ProcedureDetail prodetail in order.Procedures)
                    {
                        if (prodetail.Type.ProcedureTypeRef == list[index].ProcedureTypeRef)
                            resultData[index] += 1;
                        
                    }
                }
            }  
            
            return resultData;
        }

        public List<TotalInDate> ListOrderDateTimeEntered(DateTime startTime, DateTime endTime)
        {

            //List<ProcedureTypeSummary> list = ListProcedureType();
            List<TotalInDate> resultData = new List<TotalInDate>();
           
                
            List<OrderDetail> ListOrder = new List<OrderDetail>();
            Platform.GetService<IOrderEntryService>(delegate(IOrderEntryService service)
            {
                //resultData = service.CountProcedureType(startTime,endTime);
                ListOrder = service.LoadOrder(new ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry.LoadOrderRequest(startTime, endTime)).orderDetailList.ToList();
            });

            foreach (OrderDetail order in ListOrder)
            {   
                    bool intime = false;
                    for (int index = 0; index < resultData.Count; index++)
                    {
                        if (order.EnteredTime.Value.Year == resultData[index].Entered.Value.Year &&
                            order.EnteredTime.Value.Month == resultData[index].Entered.Value.Month &&
                            order.EnteredTime.Value.Day == resultData[index].Entered.Value.Day)
                        {
                            intime = true;
                            break;
                        }

                            
                    }
                    if (!intime) 
                    {
                        TotalInDate item = new TotalInDate();
                        item.Entered = order.EnteredTime;
                        item.Total = 0;
                        //if(order.Invoices!=null && order.Invoices[0]!=null)
                        //{
                           
                        //}
                        
                        foreach (OrderDetail ordertime in ListOrder)
                        {
                            if (ordertime.EnteredTime.Value.Year == item.Entered.Value.Year &&
                            ordertime.EnteredTime.Value.Month == item.Entered.Value.Month &&
                            ordertime.EnteredTime.Value.Day == item.Entered.Value.Day)
                            {
                                foreach (ProcedureDetail prodetail in order.Procedures)
                                {
                                    item.Total+=prodetail.Type.BasePrice;                                    
                                }
                            }
                        }
                        resultData.Add(item);
                    }
                }

            

            return resultData;
        }
    }
}
