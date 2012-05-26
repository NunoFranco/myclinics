using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointEmailAddressManager : IManagerBase<ExternalPractitionerContactPointEmailAddress, System.Guid>
    {
	}
	
	partial class ExternalPractitionerContactPointEmailAddressManager : ManagerBase<ExternalPractitionerContactPointEmailAddress, System.Guid>, IExternalPractitionerContactPointEmailAddressManager
    {
	}
}