// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Material.Healthcare.Brokers;

namespace ClearCanvas.Material.Healthcare.Hibernate.Brokers
{
    /// <summary>
    /// NHibernate implementation of <see cref="IStockTransactionBroker"/>.
    /// </summary>
    [ClearCanvas.Common.ExtensionOf(typeof(BrokerExtensionPoint))]
	public partial class StockTransactionBroker : EntityBroker<StockTransaction, StockTransactionSearchCriteria>, IStockTransactionBroker
	{
	}
}