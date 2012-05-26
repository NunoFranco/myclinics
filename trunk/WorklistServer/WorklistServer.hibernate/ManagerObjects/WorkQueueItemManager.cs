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
	}
	
	partial class WorkQueueItemManager : ManagerBase<WorkQueueItem, System.Guid>, IWorkQueueItemManager
    {
	}
}