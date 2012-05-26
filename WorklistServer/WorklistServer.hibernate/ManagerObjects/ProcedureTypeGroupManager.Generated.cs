using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureTypeGroupManager : IManagerBase<ProcedureTypeGroup, System.Guid>
    {
		// Get Methods
		ProcedureTypeGroup GetByName_(System.String name);
    }

    partial class ProcedureTypeGroupManager : ManagerBase<ProcedureTypeGroup, System.Guid>, IProcedureTypeGroupManager
    {
		#region Constructors
		
		public ProcedureTypeGroupManager() : base()
        {
        }
        public ProcedureTypeGroupManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public ProcedureTypeGroup GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureTypeGroup));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<ProcedureTypeGroup> result = criteria.List<ProcedureTypeGroup>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}