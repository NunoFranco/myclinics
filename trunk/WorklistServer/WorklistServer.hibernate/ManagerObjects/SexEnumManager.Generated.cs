using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ISexEnumManager : IManagerBase<SexEnum, string>
    {
		// Get Methods
    }

    partial class SexEnumManager : ManagerBase<SexEnum, string>, ISexEnumManager
    {
		#region Constructors
		
		public SexEnumManager() : base()
        {
        }
        public SexEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}