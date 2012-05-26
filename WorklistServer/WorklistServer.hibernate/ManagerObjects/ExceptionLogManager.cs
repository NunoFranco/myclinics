using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExceptionLogManager : IManagerBase<ExceptionLog, System.Guid>
    {
	}
	
	partial class ExceptionLogManager : ManagerBase<ExceptionLog, System.Guid>, IExceptionLogManager
    {
	}
}