using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderAttachmentManager : IManagerBase<OrderAttachment, System.Guid>
    {
	}
	
	partial class OrderAttachmentManager : ManagerBase<OrderAttachment, System.Guid>, IOrderAttachmentManager
    {
	}
}