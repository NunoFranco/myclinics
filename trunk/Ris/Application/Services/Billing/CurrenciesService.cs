using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.Healthcare;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Enterprise.Core;

using ClearCanvas.Ris.Application.Common.Billing;
using ClearCanvas.Ris.Application.Services;
using ClearCanvas.Ris.Application.Common.Admin.PatientAdmin;
using ClearCanvas.Ris.Application.Common;
using System.Threading;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces.BillingDTO;
using ClearCanvas.Ris.Application.Common.Billing.ServiecInterfaces;
namespace ClearCanvas.Ris.Application.Services.Billing
{
    [ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
    [ServiceImplementsContract(typeof(ICurrencyService))]
    public class CurrencyService : ApplicationServiceBase, ICurrencyService
    {
        [ReadOperation]
        public ListPrimaryCurrencyResponse GetPrimaryCurrency(ListPrimaryCurrencyRequest request)
        {
            CurrencySearchCriteria where = new CurrencySearchCriteria();
            where.CurrencyCode.SortAsc(0);
            where.IsPrimaryCurrency.EqualTo(true);
            where.Deactivated.EqualTo(false);
            ICurrencyBroker broker = PersistenceContext.GetBroker<ICurrencyBroker>();
            IList<Currency> items = broker.Find(where);
            CurrencyAssembler assembler = new CurrencyAssembler();
            Currency item = new Currency();
            if (items.Count == 0)
            {
                item.CurrencyCode = "VNĐ";
                item.CurrencyName = "Việt Nam Đồng";
                item.CustomDisplayFormat = "";
                item.Deactivated = false;
                item.DisplayLocale = "vi-VN";
                item.IsPrimaryCurrency = true;
                item.IsPrimaryExRateCurrency = true;
                item.RateToPrimaryExRate = 1;
                item.CreatedOn = System.DateTime.Now;
                item.LastUpdated = System.DateTime.Now;
                item.CreatedUser = Thread.CurrentPrincipal.Identity.Name;
                PersistenceContext.Lock(item, DirtyState.New);
                PersistenceContext.SynchState();
            }
            ListPrimaryCurrencyResponse response = new ListPrimaryCurrencyResponse(assembler.CreateDetail(item));


            return response;
        }


        [ReadOperation]
        public ListCurrencyResponse ListAllCurrency(ListCurrencyRequest request)
        {
            Platform.CheckForNullReference(request, "request");

            CurrencySearchCriteria where = new CurrencySearchCriteria();
            where.CurrencyCode.SortAsc(0);
            if (request.IsPrimaryCurrency)
                where.IsPrimaryCurrency.EqualTo(request.IsPrimaryCurrency);
            if (request.IsPrimaryExRateCurrency)
                where.IsPrimaryExRateCurrency.EqualTo(request.IsPrimaryExRateCurrency);
            if (!request.Deactivated)
                where.Deactivated.EqualTo(false);
            if (!string.IsNullOrEmpty(request.Code))
            {
                where.CurrencyCode.Like(string.Format("%{0}%", request.Code));
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                where.CurrencyName.Like(string.Format("%{0}%", request.Name));
            }

            ICurrencyBroker broker = PersistenceContext.GetBroker<ICurrencyBroker>();
            IList<Currency> items = broker.Find(where, request.Page);

            CurrencyAssembler assembler = new CurrencyAssembler();
            ListCurrencyResponse response = new ListCurrencyResponse();
            if (request.IsListDetail)
            {
                response = new ListCurrencyResponse(
                    CollectionUtils.Map<Currency, CurrencyDetail>(items,
                        delegate(Currency item)
                        {
                            return assembler.CreateDetail(item);
                        })
                    );
            }
            else
            {
                response = new ListCurrencyResponse(
                    CollectionUtils.Map<Currency, CurrencySummary>(items,
                        delegate(Currency item)
                        {
                            return assembler.CreateSummary(item);
                        })
                    );
            }
            return response;

        }

        [ReadOperation]
        public ListCurrencyDetailResponse ListCurrencyDetail(ListCurrencyDetailRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.CurrencyRef, "request.CurrencyRef");

            Currency item = PersistenceContext.Load<Currency>(request.CurrencyRef);

            CurrencyAssembler assembler = new CurrencyAssembler();
            return new ListCurrencyDetailResponse(assembler.CreateDetail(item));
        }

        [UpdateOperation]
        public DeleteCurrencyResponse DeleteCurrencyDetail(DeleteCurrencyRequest request)
        {
            try
            {

                ICurrencyBroker broker = PersistenceContext.GetBroker<ICurrencyBroker>();
                Currency item = broker.Load(request.CurrencyRef, EntityLoadFlags.Proxy);

                //check valid delete
                OrderInvoicesSearchCriteria criteria = new OrderInvoicesSearchCriteria();
                IOrderInvoicesBroker invoicebroker = PersistenceContext.GetBroker<IOrderInvoicesBroker>();
                criteria.ListProcedures.Like(string.Format("%{0}%", item.CurrencyCode));
                IList<OrderInvoices> invoices = invoicebroker.Find(criteria);
                if (invoices.Count > 0)
                {
                    //throw new Exception(SR.InvalidDeleteCurrency);
                    throw new RequestValidationException(SR.InvalidDeleteCurrency);
                }

                broker.Delete(item);
                PersistenceContext.SynchState();
                return new DeleteCurrencyResponse();
            }
            catch (PersistenceException)
            {
                throw new RequestValidationException(string.Format("ExceptionFailedToDelete", TerminologyTranslator.Translate(typeof(Currency))));
            }
        }

        [ReadOperation]
        public LoadCurrencyEditResponse LoadCurrencyForedit(LoadCurrencyEditRequest request)
        {

            CurrencyAssembler assemble = new CurrencyAssembler();
            ICurrencyBroker broker = PersistenceContext.GetBroker<ICurrencyBroker>();
            Currency item = broker.Load(request.CurrencyRef, EntityLoadFlags.Proxy);

            return new LoadCurrencyEditResponse(assemble.CreateDetail(item));
        }

        [UpdateOperation]
        public UpdateCurrencyResponse UpdateCurrency(UpdateCurrencyRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.ObjectDetail, "request.ObjectDetail");

            //validate data valid

            Currency item = PersistenceContext.Load<Currency>(request.ObjectDetail.CurrencyRef);

            CurrencyAssembler assembler = new CurrencyAssembler();
            assembler.UpdateCurrencyClass(item, request.ObjectDetail, PersistenceContext);

            item.LastUpdated = System.DateTime.Now;
            item.CreatedUser = Thread.CurrentPrincipal.Identity.Name;

            PersistenceContext.SynchState();

            return new UpdateCurrencyResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        public AddCurrencyResponse AddCurrency(AddCurrencyRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckMemberIsSet(request.Detail, "request.Detail");

            //validate data valid

            Currency item = new Currency();

            CurrencyAssembler assembler = new CurrencyAssembler();
            assembler.UpdateCurrencyClass(item, request.Detail, PersistenceContext);

            item.CreatedOn = System.DateTime.Now;
            item.LastUpdated = System.DateTime.Now;
            item.CreatedUser = Thread.CurrentPrincipal.Identity.Name;

            PersistenceContext.Lock(item, DirtyState.New);
            PersistenceContext.SynchState();


            return new AddCurrencyResponse(assembler.CreateSummary(item));
        }

        [UpdateOperation]
        public ChangePrimaryCurrencyResponse ChangePrimaryAndExRateCurrency(ChangePrimaryCurrencyRequest request)
        {
            Platform.CheckForNullReference(request, "request");
            Platform.CheckForNullReference(request.ChangeItems, "request.ChangeItems");
            //validate data valid


            //Update price for ProcedureType
            IList<ProcedureType> Proceudyretypes = PersistenceContext.GetBroker<IProcedureTypeBroker>().Find(new ProcedureTypeSearchCriteria());
            foreach (var item in Proceudyretypes)
            {
                item.BasePrice = CurrencyManager.ConvertCurrency(item.BasePrice, request.OldPrimaryCurrency, request.NewPrimaryCurrency, request.OldPrimaryExRateCurrency);
                PersistenceContext.Lock(item, DirtyState.Dirty);
            }
            //Update Imaging Service Package Price
            IList<DiagnosticService> imagingServices = PersistenceContext.GetBroker<IDiagnosticServiceBroker>().Find(new DiagnosticServiceSearchCriteria());
            foreach (var item in imagingServices)
            {
                if (item.IsPackageProcedure)
                {
                    item.PackagePrice = CurrencyManager.ConvertCurrency(item.PackagePrice, request.OldPrimaryCurrency, request.NewPrimaryCurrency, request.OldPrimaryExRateCurrency);
                    PersistenceContext.Lock(item, DirtyState.Dirty);
                }
            }
            //Update Pending Order Procedures price

            var criteria = new OrderSearchCriteria();
            criteria.BillingStatus.NotEqualTo(ClearCanvas.Enterprise.Common.OrderBillingStatusEnum.FINISHED.ToString());
            IList<Order> orderresults = this.PersistenceContext.GetBroker<IOrderBroker>().Find(criteria);

            foreach (var order in orderresults)
            {
                foreach (var procedure in order.Procedures)
                {
                    procedure.CollectedAmount = CurrencyManager.ConvertCurrency(procedure.CollectedAmount, request.OldPrimaryCurrency, request.NewPrimaryCurrency, request.OldPrimaryExRateCurrency);
                    procedure.WaitingInsuranceAmount = CurrencyManager.ConvertCurrency(procedure.WaitingInsuranceAmount, request.OldPrimaryCurrency, request.NewPrimaryCurrency, request.OldPrimaryExRateCurrency);
                }
            }
            //Update Currency Rating
            List<Currency> list = new List<Currency>();
            foreach (var item in request.ChangeItems)
            {
                Currency cur = new Currency();
                cur = PersistenceContext.Load<Currency>(item.CurrencyRef);
                CurrencyAssembler assembler = new CurrencyAssembler();
                assembler.UpdateCurrencyClass(cur, item, PersistenceContext);
                cur.RateToPrimaryExRate = cur.RateToPrimaryExRate / request.NewPrimaryExRateCurrency.RateToPrimaryCurrency;
                PersistenceContext.Lock(cur, DirtyState.Dirty);
            }

            PersistenceContext.SynchState();
            return new ChangePrimaryCurrencyResponse();
        }
    }
}
