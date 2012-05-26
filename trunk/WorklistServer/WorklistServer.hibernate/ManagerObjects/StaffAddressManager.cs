using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffAddressManager : IManagerBase<StaffAddress, System.Guid>
    {
	}
	
	partial class StaffAddressManager : ManagerBase<StaffAddress, System.Guid>, IStaffAddressManager
    {
	}
}