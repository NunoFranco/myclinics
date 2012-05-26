using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class NotePosting : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _discriminator = String.Empty;
		private int _version = default(Int32);
		private bool _isAcknowledged = default(Boolean);
		private System.DateTime? _acknowledgedByTime = null;
		
		private Staff _staff1 = null;
		private Note _note = null;
		private StaffGroup _staffGroup = null;
		private Staff _staff2 = null;
		
		
		#endregion

        #region Constructors

        public NotePosting() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_discriminator);
			sb.Append(_version);
			sb.Append(_isAcknowledged);
			sb.Append(_acknowledgedByTime);

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
		
		public virtual bool IsAcknowledged
        {
            get { return _isAcknowledged; }
			set
			{
				OnIsAcknowledgedChanging();
				_isAcknowledged = value;
				OnIsAcknowledgedChanged();
			}
        }
		partial void OnIsAcknowledgedChanging();
		partial void OnIsAcknowledgedChanged();
		
		public virtual System.DateTime? AcknowledgedByTime
        {
            get { return _acknowledgedByTime; }
			set
			{
				OnAcknowledgedByTimeChanging();
				_acknowledgedByTime = value;
				OnAcknowledgedByTimeChanged();
			}
        }
		partial void OnAcknowledgedByTimeChanging();
		partial void OnAcknowledgedByTimeChanged();
		
		public virtual Staff Staff1
        {
            get { return _staff1; }
			set
			{
				OnStaff1Changing();
				_staff1 = value;
				OnStaff1Changed();
			}
        }
		partial void OnStaff1Changing();
		partial void OnStaff1Changed();
		
		public virtual Note Note
        {
            get { return _note; }
			set
			{
				OnNoteChanging();
				_note = value;
				OnNoteChanged();
			}
        }
		partial void OnNoteChanging();
		partial void OnNoteChanged();
		
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
		
		public virtual Staff Staff2
        {
            get { return _staff2; }
			set
			{
				OnStaff2Changing();
				_staff2 = value;
				OnStaff2Changed();
			}
        }
		partial void OnStaff2Changing();
		partial void OnStaff2Changed();
		
        #endregion
    }
}
