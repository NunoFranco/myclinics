using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IConfigurationSettingsPropertyManager : IManagerBase<ConfigurationSettingsProperty, System.Guid>
    {
	}
	
	partial class ConfigurationSettingsPropertyManager : ManagerBase<ConfigurationSettingsProperty, System.Guid>, IConfigurationSettingsPropertyManager
    {
	}
}