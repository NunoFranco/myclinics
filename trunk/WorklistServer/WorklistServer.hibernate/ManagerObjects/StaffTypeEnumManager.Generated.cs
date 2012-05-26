using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffTypeEnumManager : IManagerBase<StaffTypeEnum, string>
    {
		// Get Methods
    }

    partial class StaffTypeEnumManager : ManagerBase<StaffTypeEnum, string>, IStaffTypeEnumManager
    {
		#region Constructors
		
		public StaffTypeEnumManager() : base()
        {
        }
        public StaffTypeEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}