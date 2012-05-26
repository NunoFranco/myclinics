using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IReportPartExtendedPropertyManager : IManagerBase<ReportPartExtendedProperty, string>
    {
	}
	
	partial class ReportPartExtendedPropertyManager : ManagerBase<ReportPartExtendedProperty, string>, IReportPartExtendedPropertyManager
    {
	}
}