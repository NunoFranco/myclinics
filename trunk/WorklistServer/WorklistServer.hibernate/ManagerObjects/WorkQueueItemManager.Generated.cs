using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IWorkQueueItemManager : IManagerBase<WorkQueueItem, System.Guid>
    {
		// Get Methods
		IList<WorkQueueItem> GetByStatus_(System.String workQueueStatusEnum);
    }

    partial class WorkQueueItemManager : ManagerBase<WorkQueueItem, System.Guid>, IWorkQueueItemManager
    {
		#region Constructors
		
		public WorkQueueItemManager() : base()
        {
        }
        public WorkQueueItemManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<WorkQueueItem> GetByStatus_(System.String workQueueStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(WorkQueueItem));
			
			
			ICriteria workQueueStatusEnumCriteria = criteria.CreateCriteria("WorkQueueStatusEnum");
            workQueueStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", workQueueStatusEnum));
			
			return criteria.List<WorkQueueItem>();
        }
		
		#endregion
    }
}