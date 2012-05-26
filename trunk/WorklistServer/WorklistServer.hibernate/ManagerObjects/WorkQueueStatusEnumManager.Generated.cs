using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IWorkQueueStatusEnumManager : IManagerBase<WorkQueueStatusEnum, string>
    {
		// Get Methods
    }

    partial class WorkQueueStatusEnumManager : ManagerBase<WorkQueueStatusEnum, string>, IWorkQueueStatusEnumManager
    {
		#region Constructors
		
		public WorkQueueStatusEnumManager() : base()
        {
        }
        public WorkQueueStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}