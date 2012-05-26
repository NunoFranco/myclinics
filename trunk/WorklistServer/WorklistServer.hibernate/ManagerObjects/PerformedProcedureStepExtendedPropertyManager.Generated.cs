using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPerformedProcedureStepExtendedPropertyManager : IManagerBase<PerformedProcedureStepExtendedProperty, string>
    {
		// Get Methods
		PerformedProcedureStepExtendedProperty GetById(System.Guid performedProcedureStepOID, System.String name);
		IList<PerformedProcedureStepExtendedProperty> GetByPerformedProcedureStepOID_(System.Guid performedProcedureStepOID);
    }

    partial class PerformedProcedureStepExtendedPropertyManager : ManagerBase<PerformedProcedureStepExtendedProperty, string>, IPerformedProcedureStepExtendedPropertyManager
    {
		#region Constructors
		
		public PerformedProcedureStepExtendedPropertyManager() : base()
        {
        }
        public PerformedProcedureStepExtendedPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override PerformedProcedureStepExtendedProperty GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for PerformedProcedureStepExtendedPropertyManager.GetById");
			
			return GetById(new System.Guid(keys[0]), keys[1]);
		}
		public PerformedProcedureStepExtendedProperty GetById(System.Guid performedProcedureStepOID, System.String name)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PerformedProcedureStepExtendedProperty));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("PerformedProcedureStepOID_", performedProcedureStepOID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name_", name));
			
			PerformedProcedureStepExtendedProperty result = (PerformedProcedureStepExtendedProperty)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<PerformedProcedureStepExtendedProperty> GetByPerformedProcedureStepOID_(System.Guid performedProcedureStepOID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PerformedProcedureStepExtendedProperty));
			
			
			ICriteria performedProcedureStepOIDCriteria = criteria.CreateCriteria("PerformedProcedureStepOID");
            performedProcedureStepOIDCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", performedProcedureStepOID));
			
			return criteria.List<PerformedProcedureStepExtendedProperty>();
        }
		
		#endregion
    }
}