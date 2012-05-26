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
	}
	
	partial class OrderExtendedPropertyManager : ManagerBase<OrderExtendedProperty, string>, IOrderExtendedPropertyManager
    {
	}
}