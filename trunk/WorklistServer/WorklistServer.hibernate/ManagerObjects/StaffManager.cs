using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffManager : IManagerBase<Staff, System.Guid>
    {
	}
	
	partial class StaffManager : ManagerBase<Staff, System.Guid>, IStaffManager
    {
	}
}