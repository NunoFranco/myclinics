using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderStatusEnumManager : IManagerBase<OrderStatusEnum, string>
    {
		// Get Methods
    }

    partial class OrderStatusEnumManager : ManagerBase<OrderStatusEnum, string>, IOrderStatusEnumManager
    {
		#region Constructors
		
		public OrderStatusEnumManager() : base()
        {
        }
        public OrderStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}