using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IConfigurationSettingsGroupManager : IManagerBase<ConfigurationSettingsGroup, System.Guid>
    {
	}
	
	partial class ConfigurationSettingsGroupManager : ManagerBase<ConfigurationSettingsGroup, System.Guid>, IConfigurationSettingsGroupManager
    {
	}
}