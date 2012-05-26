using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffTelephoneNumberManager : IManagerBase<StaffTelephoneNumber, System.Guid>
    {
	}
	
	partial class StaffTelephoneNumberManager : ManagerBase<StaffTelephoneNumber, System.Guid>, IStaffTelephoneNumberManager
    {
	}
}