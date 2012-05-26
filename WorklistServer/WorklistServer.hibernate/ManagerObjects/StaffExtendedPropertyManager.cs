using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffExtendedPropertyManager : IManagerBase<StaffExtendedProperty, string>
    {
	}
	
	partial class StaffExtendedPropertyManager : ManagerBase<StaffExtendedProperty, string>, IStaffExtendedPropertyManager
    {
	}
}