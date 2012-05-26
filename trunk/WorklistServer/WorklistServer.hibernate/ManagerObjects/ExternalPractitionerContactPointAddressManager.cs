using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointAddressManager : IManagerBase<ExternalPractitionerContactPointAddress, System.Guid>
    {
	}
	
	partial class ExternalPractitionerContactPointAddressManager : ManagerBase<ExternalPractitionerContactPointAddress, System.Guid>, IExternalPractitionerContactPointAddressManager
    {
	}
}