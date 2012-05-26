using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IWorkQueueExtendedPropertyManager : IManagerBase<WorkQueueExtendedProperty, string>
    {
		// Get Methods
		WorkQueueExtendedProperty GetById(System.Guid workQueueOID, System.String name);
		IList<WorkQueueExtendedProperty> GetByWorkQueueOID_(System.Guid workQueueOID);
    }

    partial class WorkQueueExtendedPropertyManager : ManagerBase<WorkQueueExtendedProperty, string>, IWorkQueueExtendedPropertyManager
    {
		#region Constructors
		
		public WorkQueueExtendedPropertyManager() : base()
        {
        }
        public WorkQueueExtendedPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override WorkQueueExtendedProperty GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for WorkQueueExtendedPropertyManager.GetById");
			
			return GetById(new System.Guid(keys[0]), keys[1]);
		}
		public WorkQueueExtendedProperty GetById(System.Guid workQueueOID, System.String name)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(WorkQueueExtendedProperty));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("WorkQueueOID_", workQueueOID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name_", name));
			
			WorkQueueExtendedProperty result = (WorkQueueExtendedProperty)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<WorkQueueExtendedProperty> GetByWorkQueueOID_(System.Guid workQueueOID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(WorkQueueExtendedProperty));
			
			
			ICriteria workQueueOIDCriteria = criteria.CreateCriteria("WorkQueueOID");
            workQueueOIDCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", workQueueOID));
			
			return criteria.List<WorkQueueExtendedProperty>();
        }
		
		#endregion
    }
}