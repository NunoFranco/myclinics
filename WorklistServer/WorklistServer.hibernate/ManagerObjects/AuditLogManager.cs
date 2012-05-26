using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAuditLogManager : IManagerBase<AuditLog, System.Guid>
    {
	}
	
	partial class AuditLogManager : ManagerBase<AuditLog, System.Guid>, IAuditLogManager
    {
	}
}