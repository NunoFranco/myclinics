using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitLocationRoleEnumManager : IManagerBase<VisitLocationRoleEnum, string>
    {
		// Get Methods
    }

    partial class VisitLocationRoleEnumManager : ManagerBase<VisitLocationRoleEnum, string>, IVisitLocationRoleEnumManager
    {
		#region Constructors
		
		public VisitLocationRoleEnumManager() : base()
        {
        }
        public VisitLocationRoleEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}