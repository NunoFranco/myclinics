// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Healthcare.Brokers;

namespace ClearCanvas.Healthcare.Hibernate.Brokers
{
    /// <summary>
    /// NHibernate implementation of <see cref="IOrderBroker"/>.
    /// </summary>
    [ClearCanvas.Common.ExtensionOf(typeof(BrokerExtensionPoint))]
	public partial class OrderBroker : EntityBroker<Order, OrderSearchCriteria>, IOrderBroker
	{
	}
}