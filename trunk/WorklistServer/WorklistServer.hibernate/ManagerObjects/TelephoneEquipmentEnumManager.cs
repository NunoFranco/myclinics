using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ITelephoneEquipmentEnumManager : IManagerBase<TelephoneEquipmentEnum, string>
    {
	}
	
	partial class TelephoneEquipmentEnumManager : ManagerBase<TelephoneEquipmentEnum, string>, ITelephoneEquipmentEnumManager
    {
	}
}