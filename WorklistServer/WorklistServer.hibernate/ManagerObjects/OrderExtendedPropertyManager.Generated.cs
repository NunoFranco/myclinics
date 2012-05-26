using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderExtendedPropertyManager : IManagerBase<OrderExtendedProperty, string>
    {
		// Get Methods
		OrderExtendedProperty GetById(System.Guid orderOID, System.String name);
		IList<OrderExtendedProperty> GetByOrderOID_(System.Guid orderOID);
    }

    partial class OrderExtendedPropertyManager : ManagerBase<OrderExtendedProperty, string>, IOrderExtendedPropertyManager
    {
		#region Constructors
		
		public OrderExtendedPropertyManager() : base()
        {
        }
        public OrderExtendedPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override OrderExtendedProperty GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for OrderExtendedPropertyManager.GetById");
			
			return GetById(new System.Guid(keys[0]), keys[1]);
		}
		public OrderExtendedProperty GetById(System.Guid orderOID, System.String name)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderExtendedProperty));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("OrderOID_", orderOID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name_", name));
			
			OrderExtendedProperty result = (OrderExtendedProperty)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<OrderExtendedProperty> GetByOrderOID_(System.Guid orderOID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderExtendedProperty));
			
			
			ICriteria orderOIDCriteria = criteria.CreateCriteria("OrderOID");
            orderOIDCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", orderOID));
			
			return criteria.List<OrderExtendedProperty>();
        }
		
		#endregion
    }
}