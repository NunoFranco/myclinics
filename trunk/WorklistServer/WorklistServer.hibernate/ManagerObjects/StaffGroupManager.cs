using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffGroupManager : IManagerBase<StaffGroup, System.Guid>
    {
	}
	
	partial class StaffGroupManager : ManagerBase<StaffGroup, System.Guid>, IStaffGroupManager
    {
	}
}