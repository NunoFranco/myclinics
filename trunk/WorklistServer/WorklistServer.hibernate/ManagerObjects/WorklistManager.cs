using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IWorklistManager : IManagerBase<Worklist, System.Guid>
    {
	}
	
	partial class WorklistManager : ManagerBase<Worklist, System.Guid>, IWorklistManager
    {
	}
}