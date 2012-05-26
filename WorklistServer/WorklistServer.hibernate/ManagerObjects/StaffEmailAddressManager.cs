using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffEmailAddressManager : IManagerBase<StaffEmailAddress, System.Guid>
    {
	}
	
	partial class StaffEmailAddressManager : ManagerBase<StaffEmailAddress, System.Guid>, IStaffEmailAddressManager
    {
	}
}