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
		// Get Methods
		IList<ConfigurationSettingsGroup> GetByName_VersionString_(System.String name, System.String versionString);
    }

    partial class ConfigurationSettingsGroupManager : ManagerBase<ConfigurationSettingsGroup, System.Guid>, IConfigurationSettingsGroupManager
    {
		#region Constructors
		
		public ConfigurationSettingsGroupManager() : base()
        {
        }
        public ConfigurationSettingsGroupManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ConfigurationSettingsGroup> GetByName_VersionString_(System.String name, System.String versionString)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ConfigurationSettingsGroup));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("VersionString", versionString));
			
			return criteria.List<ConfigurationSettingsGroup>();
        }
		
		#endregion
    }
}