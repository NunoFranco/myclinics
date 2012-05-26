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
		// Get Methods
    }

    partial class AuditLogManager : ManagerBase<AuditLog, System.Guid>, IAuditLogManager
    {
		#region Constructors
		
		public AuditLogManager() : base()
        {
        }
        public AuditLogManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}