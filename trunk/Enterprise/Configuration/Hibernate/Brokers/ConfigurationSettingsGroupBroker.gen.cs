// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Enterprise.Configuration.Brokers;

namespace ClearCanvas.Enterprise.Configuration.Hibernate.Brokers
{
    /// <summary>
    /// NHibernate implementation of <see cref="IConfigurationSettingsGroupBroker"/>.
    /// </summary>
    [ClearCanvas.Common.ExtensionOf(typeof(BrokerExtensionPoint))]
	public partial class ConfigurationSettingsGroupBroker : EntityBroker<ConfigurationSettingsGroup, ConfigurationSettingsGroupSearchCriteria>, IConfigurationSettingsGroupBroker
	{
	}
}