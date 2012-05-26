using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPerformedProcedureStepManager : IManagerBase<PerformedProcedureStep, System.Guid>
    {
		// Get Methods
		IList<PerformedProcedureStep> GetByPerformingStaffOID_(System.Guid staff);
		IList<PerformedProcedureStep> GetByState_(System.String performedStepStatusEnum);
    }

    partial class PerformedProcedureStepManager : ManagerBase<PerformedProcedureStep, System.Guid>, IPerformedProcedureStepManager
    {
		#region Constructors
		
		public PerformedProcedureStepManager() : base()
        {
        }
        public PerformedProcedureStepManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PerformedProcedureStep> GetByPerformingStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PerformedProcedureStep));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<PerformedProcedureStep>();
        }
		
		public IList<PerformedProcedureStep> GetByState_(System.String performedStepStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PerformedProcedureStep));
			
			
			ICriteria performedStepStatusEnumCriteria = criteria.CreateCriteria("PerformedStepStatusEnum");
            performedStepStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", performedStepStatusEnum));
			
			return criteria.List<PerformedProcedureStep>();
        }
		
		#endregion
    }
}