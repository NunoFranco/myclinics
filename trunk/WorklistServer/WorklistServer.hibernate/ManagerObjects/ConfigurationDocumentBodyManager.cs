using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IConfigurationDocumentBodyManager : IManagerBase<ConfigurationDocumentBody, System.Guid>
    {
	}
	
	partial class ConfigurationDocumentBodyManager : ManagerBase<ConfigurationDocumentBody, System.Guid>, IConfigurationDocumentBodyManager
    {
	}
}