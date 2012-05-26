using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitStatusEnumManager : IManagerBase<VisitStatusEnum, string>
    {
		// Get Methods
    }

    partial class VisitStatusEnumManager : ManagerBase<VisitStatusEnum, string>, IVisitStatusEnumManager
    {
		#region Constructors
		
		public VisitStatusEnumManager() : base()
        {
        }
        public VisitStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}