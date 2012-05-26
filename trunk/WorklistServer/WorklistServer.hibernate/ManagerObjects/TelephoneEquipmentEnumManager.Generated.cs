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
		// Get Methods
    }

    partial class TelephoneEquipmentEnumManager : ManagerBase<TelephoneEquipmentEnum, string>, ITelephoneEquipmentEnumManager
    {
		#region Constructors
		
		public TelephoneEquipmentEnumManager() : base()
        {
        }
        public TelephoneEquipmentEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}