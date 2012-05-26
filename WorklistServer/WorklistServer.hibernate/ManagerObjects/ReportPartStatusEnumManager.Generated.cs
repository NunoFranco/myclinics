using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IReportPartStatusEnumManager : IManagerBase<ReportPartStatusEnum, string>
    {
		// Get Methods
    }

    partial class ReportPartStatusEnumManager : ManagerBase<ReportPartStatusEnum, string>, IReportPartStatusEnumManager
    {
		#region Constructors
		
		public ReportPartStatusEnumManager() : base()
        {
        }
        public ReportPartStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}