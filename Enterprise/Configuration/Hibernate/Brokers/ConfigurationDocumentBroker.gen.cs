// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Enterprise.Configuration.Brokers;

namespace ClearCanvas.Enterprise.Configuration.Hibernate.Brokers
{
    /// <summary>
    /// NHibernate implementation of <see cref="IConfigurationDocumentBroker"/>.
    /// </summary>
    [ClearCanvas.Common.ExtensionOf(typeof(BrokerExtensionPoint))]
	public partial class ConfigurationDocumentBroker : EntityBroker<ConfigurationDocument, ConfigurationDocumentSearchCriteria>, IConfigurationDocumentBroker
	{
	}
}