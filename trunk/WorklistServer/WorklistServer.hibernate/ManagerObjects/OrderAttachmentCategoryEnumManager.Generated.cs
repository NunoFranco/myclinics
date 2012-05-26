using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderAttachmentCategoryEnumManager : IManagerBase<OrderAttachmentCategoryEnum, string>
    {
		// Get Methods
    }

    partial class OrderAttachmentCategoryEnumManager : ManagerBase<OrderAttachmentCategoryEnum, string>, IOrderAttachmentCategoryEnumManager
    {
		#region Constructors
		
		public OrderAttachmentCategoryEnumManager() : base()
        {
        }
        public OrderAttachmentCategoryEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}