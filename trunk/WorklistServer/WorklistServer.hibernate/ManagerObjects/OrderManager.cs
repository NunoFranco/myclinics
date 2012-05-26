using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderManager : IManagerBase<Order, System.Guid>
    {
	}
	
	partial class OrderManager : ManagerBase<Order, System.Guid>, IOrderManager
    {
	}
}