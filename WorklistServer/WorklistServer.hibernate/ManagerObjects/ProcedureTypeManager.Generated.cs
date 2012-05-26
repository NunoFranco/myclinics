using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureTypeManager : IManagerBase<ProcedureType, System.Guid>
    {
		// Get Methods
		IList<ProcedureType> GetByBaseTypeOID_(System.Guid procedureTypeMember);
		ProcedureType GetById_(System.String id);
		ProcedureType GetByName_(System.String name);
    }

    partial class ProcedureTypeManager : ManagerBase<ProcedureType, System.Guid>, IProcedureTypeManager
    {
		#region Constructors
		
		public ProcedureTypeManager() : base()
        {
        }
        public ProcedureTypeManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ProcedureType> GetByBaseTypeOID_(System.Guid procedureTypeMember)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureType));
			
			
			ICriteria procedureTypeMemberCriteria = criteria.CreateCriteria("ProcedureTypeMember");
            procedureTypeMemberCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", procedureTypeMember));
			
			return criteria.List<ProcedureType>();
        }
		
		public ProcedureType GetById_(System.String id)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureType));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Id", id));
			
			IList<ProcedureType> result = criteria.List<ProcedureType>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		public ProcedureType GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureType));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<ProcedureType> result = criteria.List<ProcedureType>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}