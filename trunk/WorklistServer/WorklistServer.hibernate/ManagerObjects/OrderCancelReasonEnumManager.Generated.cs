using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderCancelReasonEnumManager : IManagerBase<OrderCancelReasonEnum, string>
    {
		// Get Methods
    }

    partial class OrderCancelReasonEnumManager : ManagerBase<OrderCancelReasonEnum, string>, IOrderCancelReasonEnumManager
    {
		#region Constructors
		
		public OrderCancelReasonEnumManager() : base()
        {
        }
        public OrderCancelReasonEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}