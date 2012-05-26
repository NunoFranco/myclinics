using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IWorkQueueExtendedPropertyManager : IManagerBase<WorkQueueExtendedProperty, string>
    {
	}
	
	partial class WorkQueueExtendedPropertyManager : ManagerBase<WorkQueueExtendedProperty, string>, IWorkQueueExtendedPropertyManager
    {
	}
}