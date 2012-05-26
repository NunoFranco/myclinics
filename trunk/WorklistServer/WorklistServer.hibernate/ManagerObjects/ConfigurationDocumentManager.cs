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
	}
	
	partial class ConfigurationDocumentManager : ManagerBase<ConfigurationDocument, System.Guid>, IConfigurationDocumentManager
    {
	}
}