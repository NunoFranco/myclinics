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
	}
	
	partial class ReportManager : ManagerBase<Report, System.Guid>, IReportManager
    {
	}
}