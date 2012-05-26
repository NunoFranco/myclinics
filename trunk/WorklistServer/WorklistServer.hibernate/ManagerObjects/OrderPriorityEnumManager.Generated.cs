using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderPriorityEnumManager : IManagerBase<OrderPriorityEnum, string>
    {
		// Get Methods
    }

    partial class OrderPriorityEnumManager : ManagerBase<OrderPriorityEnum, string>, IOrderPriorityEnumManager
    {
		#region Constructors
		
		public OrderPriorityEnumManager() : base()
        {
        }
        public OrderPriorityEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}