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
		// Get Methods
		IList<OrderAttachment> GetByAttachedByStaffOID_(System.Guid staff);
		IList<OrderAttachment> GetByAttachedDocumentOID_(System.Guid attachedDocument);
		IList<OrderAttachment> GetByCategory_(System.String orderAttachmentCategoryEnum);
		IList<OrderAttachment> GetByOrderOID_(System.Guid order);
    }

    partial class OrderAttachmentManager : ManagerBase<OrderAttachment, System.Guid>, IOrderAttachmentManager
    {
		#region Constructors
		
		public OrderAttachmentManager() : base()
        {
        }
        public OrderAttachmentManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<OrderAttachment> GetByAttachedByStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderAttachment));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<OrderAttachment>();
        }
		
		public IList<OrderAttachment> GetByAttachedDocumentOID_(System.Guid attachedDocument)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderAttachment));
			
			
			ICriteria attachedDocumentCriteria = criteria.CreateCriteria("AttachedDocument");
            attachedDocumentCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", attachedDocument));
			
			return criteria.List<OrderAttachment>();
        }
		
		public IList<OrderAttachment> GetByCategory_(System.String orderAttachmentCategoryEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderAttachment));
			
			
			ICriteria orderAttachmentCategoryEnumCriteria = criteria.CreateCriteria("OrderAttachmentCategoryEnum");
            orderAttachmentCategoryEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", orderAttachmentCategoryEnum));
			
			return criteria.List<OrderAttachment>();
        }
		
		public IList<OrderAttachment> GetByOrderOID_(System.Guid order)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderAttachment));
			
			
			ICriteria orderCriteria = criteria.CreateCriteria("Order");
            orderCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", order));
			
			return criteria.List<OrderAttachment>();
        }
		
		#endregion
    }
}