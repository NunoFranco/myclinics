using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureManager : IManagerBase<Procedure, System.Guid>
    {
		// Get Methods
		IList<Procedure> GetByImageAvailability_(System.String imageAvailabilityEnum);
		IList<Procedure> GetByLaterality_(System.String lateralityEnum);
		IList<Procedure> GetByOrderOID_(System.Guid order);
		IList<Procedure> GetByPerformingFacilityOID_(System.Guid facility);
		IList<Procedure> GetByProcedureCheckInOID_(System.Guid procedureCheckIn);
		IList<Procedure> GetByProcedureTypeOID_(System.Guid procedureType);
		IList<Procedure> GetByStatus_(System.String procedureStatusEnum);
		IList<Procedure> GetByEndTime_(System.DateTime endTime);
		IList<Procedure> GetByPortable_(System.Boolean portable);
		IList<Procedure> GetByScheduledStartTime_(System.DateTime scheduledStartTime);
		IList<Procedure> GetByStartTime_(System.DateTime startTime);
    }

    partial class ProcedureManager : ManagerBase<Procedure, System.Guid>, IProcedureManager
    {
		#region Constructors
		
		public ProcedureManager() : base()
        {
        }
        public ProcedureManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Procedure> GetByImageAvailability_(System.String imageAvailabilityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			ICriteria imageAvailabilityEnumCriteria = criteria.CreateCriteria("ImageAvailabilityEnum");
            imageAvailabilityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", imageAvailabilityEnum));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByLaterality_(System.String lateralityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			ICriteria lateralityEnumCriteria = criteria.CreateCriteria("LateralityEnum");
            lateralityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", lateralityEnum));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByOrderOID_(System.Guid order)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			ICriteria orderCriteria = criteria.CreateCriteria("Order");
            orderCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", order));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByPerformingFacilityOID_(System.Guid facility)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			ICriteria facilityCriteria = criteria.CreateCriteria("Facility");
            facilityCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", facility));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByProcedureCheckInOID_(System.Guid procedureCheckIn)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			ICriteria procedureCheckInCriteria = criteria.CreateCriteria("ProcedureCheckIn");
            procedureCheckInCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", procedureCheckIn));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByProcedureTypeOID_(System.Guid procedureType)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			ICriteria procedureTypeCriteria = criteria.CreateCriteria("ProcedureType");
            procedureTypeCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", procedureType));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByStatus_(System.String procedureStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			ICriteria procedureStatusEnumCriteria = criteria.CreateCriteria("ProcedureStatusEnum");
            procedureStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", procedureStatusEnum));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByEndTime_(System.DateTime endTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("EndTime", endTime));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByPortable_(System.Boolean portable)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Portable", portable));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByScheduledStartTime_(System.DateTime scheduledStartTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ScheduledStartTime", scheduledStartTime));
			
			return criteria.List<Procedure>();
        }
		
		public IList<Procedure> GetByStartTime_(System.DateTime startTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Procedure));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("StartTime", startTime));
			
			return criteria.List<Procedure>();
        }
		
		#endregion
    }
}