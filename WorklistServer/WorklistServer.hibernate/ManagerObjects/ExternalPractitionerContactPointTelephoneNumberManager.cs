using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointTelephoneNumberManager : IManagerBase<ExternalPractitionerContactPointTelephoneNumber, System.Guid>
    {
	}
	
	partial class ExternalPractitionerContactPointTelephoneNumberManager : ManagerBase<ExternalPractitionerContactPointTelephoneNumber, System.Guid>, IExternalPractitionerContactPointTelephoneNumberManager
    {
	}
}