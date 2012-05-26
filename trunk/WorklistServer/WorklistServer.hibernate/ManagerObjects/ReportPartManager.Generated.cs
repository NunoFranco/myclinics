using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IReportPartManager : IManagerBase<ReportPart, System.Guid>
    {
		// Get Methods
		IList<ReportPart> GetByInterpreterOID_(System.Guid staff1);
		IList<ReportPart> GetByReportOID_(System.Guid report);
		IList<ReportPart> GetByStatus_(System.String reportPartStatusEnum);
		IList<ReportPart> GetBySupervisorOID_(System.Guid staff2);
		IList<ReportPart> GetByTranscriberOID_(System.Guid staff3);
		IList<ReportPart> GetByTranscriptionRejectReason_(System.String transcriptionRejectReasonEnum);
		IList<ReportPart> GetByTranscriptionSupervisorOID_(System.Guid staff4);
		IList<ReportPart> GetByVerifierOID_(System.Guid staff5);
    }

    partial class ReportPartManager : ManagerBase<ReportPart, System.Guid>, IReportPartManager
    {
		#region Constructors
		
		public ReportPartManager() : base()
        {
        }
        public ReportPartManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ReportPart> GetByInterpreterOID_(System.Guid staff1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria staff1Criteria = criteria.CreateCriteria("Staff1");
            staff1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff1));
			
			return criteria.List<ReportPart>();
        }
		
		public IList<ReportPart> GetByReportOID_(System.Guid report)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria reportCriteria = criteria.CreateCriteria("Report");
            reportCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", report));
			
			return criteria.List<ReportPart>();
        }
		
		public IList<ReportPart> GetByStatus_(System.String reportPartStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria reportPartStatusEnumCriteria = criteria.CreateCriteria("ReportPartStatusEnum");
            reportPartStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", reportPartStatusEnum));
			
			return criteria.List<ReportPart>();
        }
		
		public IList<ReportPart> GetBySupervisorOID_(System.Guid staff2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria staff2Criteria = criteria.CreateCriteria("Staff2");
            staff2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff2));
			
			return criteria.List<ReportPart>();
        }
		
		public IList<ReportPart> GetByTranscriberOID_(System.Guid staff3)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria staff3Criteria = criteria.CreateCriteria("Staff3");
            staff3Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff3));
			
			return criteria.List<ReportPart>();
        }
		
		public IList<ReportPart> GetByTranscriptionRejectReason_(System.String transcriptionRejectReasonEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria transcriptionRejectReasonEnumCriteria = criteria.CreateCriteria("TranscriptionRejectReasonEnum");
            transcriptionRejectReasonEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", transcriptionRejectReasonEnum));
			
			return criteria.List<ReportPart>();
        }
		
		public IList<ReportPart> GetByTranscriptionSupervisorOID_(System.Guid staff4)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria staff4Criteria = criteria.CreateCriteria("Staff4");
            staff4Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff4));
			
			return criteria.List<ReportPart>();
        }
		
		public IList<ReportPart> GetByVerifierOID_(System.Guid staff5)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPart));
			
			
			ICriteria staff5Criteria = criteria.CreateCriteria("Staff5");
            staff5Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff5));
			
			return criteria.List<ReportPart>();
        }
		
		#endregion
    }
}