using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderManager : IManagerBase<Order, System.Guid>
    {
		// Get Methods
		IList<Order> GetByCancelledByOID_(System.Guid staff1);
		IList<Order> GetByCancelReason_(System.String orderCancelReasonEnum);
		IList<Order> GetByDiagnosticServiceOID_(System.Guid diagnosticService);
		IList<Order> GetByEnteredByOID_(System.Guid staff2);
		IList<Order> GetByOrderingFacilityOID_(System.Guid facility);
		IList<Order> GetByOrderingPractitionerOID_(System.Guid externalPractitioner);
		IList<Order> GetByPatientOID_(System.Guid patient);
		IList<Order> GetByPriority_(System.String orderPriorityEnum);
		IList<Order> GetByReplacementOrderOID_(System.Guid orderMember);
		IList<Order> GetByStatus_(System.String orderStatusEnum);
		IList<Order> GetByVisitOID_(System.Guid visit);
		Order GetByAccessionNumber_(System.String accessionNumber);
		IList<Order> GetByEndTime_(System.DateTime endTime);
		IList<Order> GetByScheduledStartTime_(System.DateTime scheduledStartTime);
		IList<Order> GetBySchedulingRequestTime_(System.DateTime schedulingRequestTime);
		IList<Order> GetByStartTime_(System.DateTime startTime);
    }

    partial class OrderManager : ManagerBase<Order, System.Guid>, IOrderManager
    {
		#region Constructors
		
		public OrderManager() : base()
        {
        }
        public OrderManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Order> GetByCancelledByOID_(System.Guid staff1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria staff1Criteria = criteria.CreateCriteria("Staff1");
            staff1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff1));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByCancelReason_(System.String orderCancelReasonEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria orderCancelReasonEnumCriteria = criteria.CreateCriteria("OrderCancelReasonEnum");
            orderCancelReasonEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", orderCancelReasonEnum));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByDiagnosticServiceOID_(System.Guid diagnosticService)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria diagnosticServiceCriteria = criteria.CreateCriteria("DiagnosticService");
            diagnosticServiceCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", diagnosticService));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByEnteredByOID_(System.Guid staff2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria staff2Criteria = criteria.CreateCriteria("Staff2");
            staff2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff2));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByOrderingFacilityOID_(System.Guid facility)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria facilityCriteria = criteria.CreateCriteria("Facility");
            facilityCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", facility));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByOrderingPractitionerOID_(System.Guid externalPractitioner)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria externalPractitionerCriteria = criteria.CreateCriteria("ExternalPractitioner");
            externalPractitionerCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitioner));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByPatientOID_(System.Guid patient)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria patientCriteria = criteria.CreateCriteria("Patient");
            patientCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patient));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByPriority_(System.String orderPriorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria orderPriorityEnumCriteria = criteria.CreateCriteria("OrderPriorityEnum");
            orderPriorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", orderPriorityEnum));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByReplacementOrderOID_(System.Guid orderMember)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria orderMemberCriteria = criteria.CreateCriteria("OrderMember");
            orderMemberCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", orderMember));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByStatus_(System.String orderStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria orderStatusEnumCriteria = criteria.CreateCriteria("OrderStatusEnum");
            orderStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", orderStatusEnum));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByVisitOID_(System.Guid visit)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			ICriteria visitCriteria = criteria.CreateCriteria("Visit");
            visitCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", visit));
			
			return criteria.List<Order>();
        }
		
		public Order GetByAccessionNumber_(System.String accessionNumber)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("AccessionNumber", accessionNumber));
			
			IList<Order> result = criteria.List<Order>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		public IList<Order> GetByEndTime_(System.DateTime endTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("EndTime", endTime));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByScheduledStartTime_(System.DateTime scheduledStartTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ScheduledStartTime", scheduledStartTime));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetBySchedulingRequestTime_(System.DateTime schedulingRequestTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SchedulingRequestTime", schedulingRequestTime));
			
			return criteria.List<Order>();
        }
		
		public IList<Order> GetByStartTime_(System.DateTime startTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Order));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("StartTime", startTime));
			
			return criteria.List<Order>();
        }
		
		#endregion
    }
}