using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerManager : IManagerBase<ExternalPractitioner, System.Guid>
    {
	}
	
	partial class ExternalPractitionerManager : ManagerBase<ExternalPractitioner, System.Guid>, IExternalPractitionerManager
    {
	}
}