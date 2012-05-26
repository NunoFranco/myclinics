using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IReportStatusEnumManager : IManagerBase<ReportStatusEnum, string>
    {
		// Get Methods
    }

    partial class ReportStatusEnumManager : ManagerBase<ReportStatusEnum, string>, IReportStatusEnumManager
    {
		#region Constructors
		
		public ReportStatusEnumManager() : base()
        {
        }
        public ReportStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}