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
		// Get Methods
		IList<ConfigurationSettingsProperty> GetByConfigurationSettingsGroupOID_(System.Guid configurationSettingsGroup);
    }

    partial class ConfigurationSettingsPropertyManager : ManagerBase<ConfigurationSettingsProperty, System.Guid>, IConfigurationSettingsPropertyManager
    {
		#region Constructors
		
		public ConfigurationSettingsPropertyManager() : base()
        {
        }
        public ConfigurationSettingsPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ConfigurationSettingsProperty> GetByConfigurationSettingsGroupOID_(System.Guid configurationSettingsGroup)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ConfigurationSettingsProperty));
			
			
			ICriteria configurationSettingsGroupCriteria = criteria.CreateCriteria("ConfigurationSettingsGroup");
            configurationSettingsGroupCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", configurationSettingsGroup));
			
			return criteria.List<ConfigurationSettingsProperty>();
        }
		
		#endregion
    }
}