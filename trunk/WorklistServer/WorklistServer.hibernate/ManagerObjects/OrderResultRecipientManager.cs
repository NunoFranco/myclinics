using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderResultRecipientManager : IManagerBase<OrderResultRecipient, System.Guid>
    {
	}
	
	partial class OrderResultRecipientManager : ManagerBase<OrderResultRecipient, System.Guid>, IOrderResultRecipientManager
    {
	}
}