using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IActivityStatusEnumManager : IManagerBase<ActivityStatusEnum, string>
    {
		// Get Methods
    }

    partial class ActivityStatusEnumManager : ManagerBase<ActivityStatusEnum, string>, IActivityStatusEnumManager
    {
		#region Constructors
		
		public ActivityStatusEnumManager() : base()
        {
        }
        public ActivityStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}