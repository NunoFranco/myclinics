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
	}
	
	partial class ReportPartStatusEnumManager : ManagerBase<ReportPartStatusEnum, string>, IReportPartStatusEnumManager
    {
	}
}