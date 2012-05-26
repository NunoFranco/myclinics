using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureStatusEnumManager : IManagerBase<ProcedureStatusEnum, string>
    {
		// Get Methods
    }

    partial class ProcedureStatusEnumManager : ManagerBase<ProcedureStatusEnum, string>, IProcedureStatusEnumManager
    {
		#region Constructors
		
		public ProcedureStatusEnumManager() : base()
        {
        }
        public ProcedureStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}