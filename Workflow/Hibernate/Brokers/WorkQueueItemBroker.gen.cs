// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Workflow.Brokers;

namespace ClearCanvas.Workflow.Hibernate.Brokers
{
    /// <summary>
    /// NHibernate implementation of <see cref="IWorkQueueItemBroker"/>.
    /// </summary>
    [ClearCanvas.Common.ExtensionOf(typeof(BrokerExtensionPoint))]
	public partial class WorkQueueItemBroker : EntityBroker<WorkQueueItem, WorkQueueItemSearchCriteria>, IWorkQueueItemBroker
	{
	}
}