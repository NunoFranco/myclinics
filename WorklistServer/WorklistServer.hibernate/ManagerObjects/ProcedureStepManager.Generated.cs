using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureStepManager : IManagerBase<ProcedureStep, System.Guid>
    {
		// Get Methods
		IList<ProcedureStep> GetByLinkStepOID_(System.Guid procedureStepMember);
		IList<ProcedureStep> GetByModalityOID_(System.Guid modality);
		IList<ProcedureStep> GetByPerformerStaffOID_(System.Guid staff1);
		IList<ProcedureStep> GetByProcedureOID_(System.Guid procedure);
		IList<ProcedureStep> GetByProtocolOID_(System.Guid protocol);
		IList<ProcedureStep> GetByReportPartOID_(System.Guid reportPart);
		IList<ProcedureStep> GetByScheduledPerformerStaffOID_(System.Guid staff2);
		IList<ProcedureStep> GetByState_(System.String activityStatusEnum);
		IList<ProcedureStep> GetByCreationTime_(System.DateTime creationTime);
		IList<ProcedureStep> GetByEndTime_(System.DateTime endTime);
		IList<ProcedureStep> GetByScheduledEndTime_(System.DateTime scheduledEndTime);
		IList<ProcedureStep> GetByScheduledStartTime_(System.DateTime scheduledStartTime);
		IList<ProcedureStep> GetByStartTime_(System.DateTime startTime);
    }

    partial class ProcedureStepManager : ManagerBase<ProcedureStep, System.Guid>, IProcedureStepManager
    {
		#region Constructors
		
		public ProcedureStepManager() : base()
        {
        }
        public ProcedureStepManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ProcedureStep> GetByLinkStepOID_(System.Guid procedureStepMember)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria procedureStepMemberCriteria = criteria.CreateCriteria("ProcedureStepMember");
            procedureStepMemberCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", procedureStepMember));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByModalityOID_(System.Guid modality)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria modalityCriteria = criteria.CreateCriteria("Modality");
            modalityCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", modality));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByPerformerStaffOID_(System.Guid staff1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria staff1Criteria = criteria.CreateCriteria("Staff1");
            staff1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff1));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByProcedureOID_(System.Guid procedure)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria procedureCriteria = criteria.CreateCriteria("Procedure");
            procedureCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", procedure));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByProtocolOID_(System.Guid protocol)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria protocolCriteria = criteria.CreateCriteria("Protocol");
            protocolCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", protocol));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByReportPartOID_(System.Guid reportPart)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria reportPartCriteria = criteria.CreateCriteria("ReportPart");
            reportPartCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", reportPart));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByScheduledPerformerStaffOID_(System.Guid staff2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria staff2Criteria = criteria.CreateCriteria("Staff2");
            staff2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff2));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByState_(System.String activityStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			ICriteria activityStatusEnumCriteria = criteria.CreateCriteria("ActivityStatusEnum");
            activityStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", activityStatusEnum));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByCreationTime_(System.DateTime creationTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("CreationTime", creationTime));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByEndTime_(System.DateTime endTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("EndTime", endTime));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByScheduledEndTime_(System.DateTime scheduledEndTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ScheduledEndTime", scheduledEndTime));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByScheduledStartTime_(System.DateTime scheduledStartTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ScheduledStartTime", scheduledStartTime));
			
			return criteria.List<ProcedureStep>();
        }
		
		public IList<ProcedureStep> GetByStartTime_(System.DateTime startTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureStep));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("StartTime", startTime));
			
			return criteria.List<ProcedureStep>();
        }
		
		#endregion
    }
}