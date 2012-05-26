using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ILateralityEnumManager : IManagerBase<LateralityEnum, string>
    {
		// Get Methods
    }

    partial class LateralityEnumManager : ManagerBase<LateralityEnum, string>, ILateralityEnumManager
    {
		#region Constructors
		
		public LateralityEnumManager() : base()
        {
        }
        public LateralityEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}