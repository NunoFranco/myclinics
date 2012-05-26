using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointManager : IManagerBase<ExternalPractitionerContactPoint, System.Guid>
    {
	}
	
	partial class ExternalPractitionerContactPointManager : ManagerBase<ExternalPractitionerContactPoint, System.Guid>, IExternalPractitionerContactPointManager
    {
	}
}