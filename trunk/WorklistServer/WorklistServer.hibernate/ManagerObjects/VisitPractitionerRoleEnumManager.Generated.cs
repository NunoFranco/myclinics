using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitPractitionerRoleEnumManager : IManagerBase<VisitPractitionerRoleEnum, string>
    {
		// Get Methods
    }

    partial class VisitPractitionerRoleEnumManager : ManagerBase<VisitPractitionerRoleEnum, string>, IVisitPractitionerRoleEnumManager
    {
		#region Constructors
		
		public VisitPractitionerRoleEnumManager() : base()
        {
        }
        public VisitPractitionerRoleEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}