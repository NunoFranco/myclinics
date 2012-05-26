using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Note : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _discriminator = String.Empty;
		private int _version = default(Int32);
		private string _category = null;
		private string _body = null;
		private bool _urgent = default(Boolean);
		private System.DateTime _creationTime = new DateTime();
		private System.DateTime? _postTime = null;
		private bool _isFullyAcknowledged = default(Boolean);
		
		private Staff _staff = null;
		private StaffGroup _staffGroup = null;
		private Order _order = null;
		
		private IList<NotePosting> _notePostings = new List<NotePosting>();
		
		#endregion

        #region Constructors

        public Note() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_discriminator);
			sb.Append(_version);
			sb.Append(_category);
			sb.Append(_body);
			sb.Append(_urgent);
			sb.Append(_creationTime);
			sb.Append(_postTime);
			sb.Append(_isFullyAcknowledged);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string Discriminator
        {
            get { return _discriminator; }
			set
			{
				OnDiscriminatorChanging();
				_discriminator = value;
				OnDiscriminatorChanged();
			}
        }
		partial void OnDiscriminatorChanging();
		partial void OnDiscriminatorChanged();
		
		public virtual int Version
        {
            get { return _version; }
			set
			{
				OnVersionChanging();
				_version = value;
				OnVersionChanged();
			}
        }
		partial void OnVersionChanging();
		partial void OnVersionChanged();
		
		public virtual string Category
        {
            get { return _category; }
			set
			{
				OnCategoryChanging();
				_category = value;
				OnCategoryChanged();
			}
        }
		partial void OnCategoryChanging();
		partial void OnCategoryChanged();
		
		public virtual string Body
        {
            get { return _body; }
			set
			{
				OnBodyChanging();
				_body = value;
				OnBodyChanged();
			}
        }
		partial void OnBodyChanging();
		partial void OnBodyChanged();
		
		public virtual bool Urgent
        {
            get { return _urgent; }
			set
			{
				OnUrgentChanging();
				_urgent = value;
				OnUrgentChanged();
			}
        }
		partial void OnUrgentChanging();
		partial void OnUrgentChanged();
		
		public virtual System.DateTime CreationTime
        {
            get { return _creationTime; }
			set
			{
				OnCreationTimeChanging();
				_creationTime = value;
				OnCreationTimeChanged();
			}
        }
		partial void OnCreationTimeChanging();
		partial void OnCreationTimeChanged();
		
		public virtual System.DateTime? PostTime
        {
            get { return _postTime; }
			set
			{
				OnPostTimeChanging();
				_postTime = value;
				OnPostTimeChanged();
			}
        }
		partial void OnPostTimeChanging();
		partial void OnPostTimeChanged();
		
		public virtual bool IsFullyAcknowledged
        {
            get { return _isFullyAcknowledged; }
			set
			{
				OnIsFullyAcknowledgedChanging();
				_isFullyAcknowledged = value;
				OnIsFullyAcknowledgedChanged();
			}
        }
		partial void OnIsFullyAcknowledgedChanging();
		partial void OnIsFullyAcknowledgedChanged();
		
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
		
		public virtual StaffGroup StaffGroup
        {
            get { return _staffGroup; }
			set
			{
				OnStaffGroupChanging();
				_staffGroup = value;
				OnStaffGroupChanged();
			}
        }
		partial void OnStaffGroupChanging();
		partial void OnStaffGroupChanged();
		
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
		
		public virtual IList<NotePosting> NotePostings
        {
            get { return _notePostings; }
            set
			{
				OnNotePostingsChanging();
				_notePostings = value;
				OnNotePostingsChanged();
			}
        }
		partial void OnNotePostingsChanging();
		partial void OnNotePostingsChanged();
		
        #endregion
    }
}
