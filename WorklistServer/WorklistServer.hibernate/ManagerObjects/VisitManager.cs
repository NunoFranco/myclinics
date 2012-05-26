using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitManager : IManagerBase<Visit, System.Guid>
    {
	}
	
	partial class VisitManager : ManagerBase<Visit, System.Guid>, IVisitManager
    {
	}
}