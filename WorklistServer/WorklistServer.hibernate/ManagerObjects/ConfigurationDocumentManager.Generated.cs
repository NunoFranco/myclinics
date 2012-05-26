using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IConfigurationDocumentManager : IManagerBase<ConfigurationDocument, System.Guid>
    {
		// Get Methods
		IList<ConfigurationDocument> GetByDocumentName_DocumentVersionString_User_InstanceKey_(System.String documentName, System.String documentVersionString, System.String user, System.String instanceKey);
    }

    partial class ConfigurationDocumentManager : ManagerBase<ConfigurationDocument, System.Guid>, IConfigurationDocumentManager
    {
		#region Constructors
		
		public ConfigurationDocumentManager() : base()
        {
        }
        public ConfigurationDocumentManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ConfigurationDocument> GetByDocumentName_DocumentVersionString_User_InstanceKey_(System.String documentName, System.String documentVersionString, System.String user, System.String instanceKey)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ConfigurationDocument));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("DocumentName", documentName));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("DocumentVersionString", documentVersionString));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("User", user));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("InstanceKey", instanceKey));
			
			return criteria.List<ConfigurationDocument>();
        }
		
		#endregion
    }
}