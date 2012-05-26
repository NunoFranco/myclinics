using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerExtendedPropertyManager : IManagerBase<ExternalPractitionerExtendedProperty, string>
    {
	}
	
	partial class ExternalPractitionerExtendedPropertyManager : ManagerBase<ExternalPractitionerExtendedProperty, string>, IExternalPractitionerExtendedPropertyManager
    {
	}
}