using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitPractitionerManager : IManagerBase<VisitPractitioner, System.Guid>
    {
	}
	
	partial class VisitPractitionerManager : ManagerBase<VisitPractitioner, System.Guid>, IVisitPractitionerManager
    {
	}
}