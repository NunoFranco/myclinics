using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IReportManager : IManagerBase<Report, System.Guid>
    {
		// Get Methods
		IList<Report> GetByStatus_(System.String reportStatusEnum);
    }

    partial class ReportManager : ManagerBase<Report, System.Guid>, IReportManager
    {
		#region Constructors
		
		public ReportManager() : base()
        {
        }
        public ReportManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Report> GetByStatus_(System.String reportStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Report));
			
			
			ICriteria reportStatusEnumCriteria = criteria.CreateCriteria("ReportStatusEnum");
            reportStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", reportStatusEnum));
			
			return criteria.List<Report>();
        }
		
		#endregion
    }
}