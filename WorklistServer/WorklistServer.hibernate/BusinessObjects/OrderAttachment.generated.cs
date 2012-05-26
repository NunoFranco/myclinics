using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class OrderAttachment : BusinessBase<System.Guid>
    {
        #region Declarations

		private System.DateTime _attachedTime = new DateTime();
		
		private Staff _staff = null;
		private AttachedDocument _attachedDocument = null;
		private OrderAttachmentCategoryEnum _orderAttachmentCategoryEnum = null;
		private Order _order = null;
		
		
		#endregion

        #region Constructors

        public OrderAttachment() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_attachedTime);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual System.DateTime AttachedTime
        {
            get { return _attachedTime; }
			set
			{
				OnAttachedTimeChanging();
				_attachedTime = value;
				OnAttachedTimeChanged();
			}
        }
		partial void OnAttachedTimeChanging();
		partial void OnAttachedTimeChanged();
		
		public virtual Staff Staff
        {
            get { return _staff; }
			set
			{
				OnStaffChanging();
				_staff = value;
				OnStaffChanged();
			}
        }
		partial void OnStaffChanging();
		partial void OnStaffChanged();
		
		public virtual AttachedDocument AttachedDocument
        {
            get { return _attachedDocument; }
			set
			{
				OnAttachedDocumentChanging();
				_attachedDocument = value;
				OnAttachedDocumentChanged();
			}
        }
		partial void OnAttachedDocumentChanging();
		partial void OnAttachedDocumentChanged();
		
		public virtual OrderAttachmentCategoryEnum OrderAttachmentCategoryEnum
        {
            get { return _orderAttachmentCategoryEnum; }
			set
			{
				OnOrderAttachmentCategoryEnumChanging();
				_orderAttachmentCategoryEnum = value;
				OnOrderAttachmentCategoryEnumChanged();
			}
        }
		partial void OnOrderAttachmentCategoryEnumChanging();
		partial void OnOrderAttachmentCategoryEnumChanged();
		
		public virtual Order Order
        {
            get { return _order; }
			set
			{
				OnOrderChanging();
				_order = value;
				OnOrderChanged();
			}
        }
		partial void OnOrderChanging();
		partial void OnOrderChanged();
		
        #endregion
    }
}
