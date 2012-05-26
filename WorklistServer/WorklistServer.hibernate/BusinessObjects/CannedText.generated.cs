using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class CannedText : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _name = String.Empty;
		private string _category = String.Empty;
		private string _text = String.Empty;
		
		private StaffGroup _staffGroup = null;
		private Staff _staff = null;
		
		
		#endregion

        #region Constructors

        public CannedText() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_name);
			sb.Append(_category);
			sb.Append(_text);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

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
		
		public virtual string Name
        {
            get { return _name; }
			set
			{
				OnNameChanging();
				_name = value;
				OnNameChanged();
			}
        }
		partial void OnNameChanging();
		partial void OnNameChanged();
		
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
		
		public virtual string Text
        {
            get { return _text; }
			set
			{
				OnTextChanging();
				_text = value;
				OnTextChanged();
			}
        }
		partial void OnTextChanging();
		partial void OnTextChanged();
		
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
		
        #endregion
    }
}
