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
	}
	
	partial class WorkQueueStatusEnumManager : ManagerBase<WorkQueueStatusEnum, string>, IWorkQueueStatusEnumManager
    {
	}
}