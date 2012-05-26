using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class StaffGroup : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private string _name = String.Empty;
		private string _description = null;
		private bool _elective = default(Boolean);
		private bool _deactivated = default(Boolean);
		
		
		private IList<Note> _notes = new List<Note>();
		private IList<Worklist> _worklists = new List<Worklist>();
		private IList<NotePosting> _notePostings = new List<NotePosting>();
		private IList<CannedText> _cannedTexts = new List<CannedText>();
		
		#endregion

        #region Constructors

        public StaffGroup() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_name);
			sb.Append(_description);
			sb.Append(_elective);
			sb.Append(_deactivated);

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
		
		public virtual string Description
        {
            get { return _description; }
			set
			{
				OnDescriptionChanging();
				_description = value;
				OnDescriptionChanged();
			}
        }
		partial void OnDescriptionChanging();
		partial void OnDescriptionChanged();
		
		public virtual bool Elective
        {
            get { return _elective; }
			set
			{
				OnElectiveChanging();
				_elective = value;
				OnElectiveChanged();
			}
        }
		partial void OnElectiveChanging();
		partial void OnElectiveChanged();
		
		public virtual bool Deactivated
        {
            get { return _deactivated; }
			set
			{
				OnDeactivatedChanging();
				_deactivated = value;
				OnDeactivatedChanged();
			}
        }
		partial void OnDeactivatedChanging();
		partial void OnDeactivatedChanged();
		
		public virtual IList<Note> Notes
        {
            get { return _notes; }
            set
			{
				OnNotesChanging();
				_notes = value;
				OnNotesChanged();
			}
        }
		partial void OnNotesChanging();
		partial void OnNotesChanged();
		
		public virtual IList<Worklist> Worklists
        {
            get { return _worklists; }
            set
			{
				OnWorklistsChanging();
				_worklists = value;
				OnWorklistsChanged();
			}
        }
		partial void OnWorklistsChanging();
		partial void OnWorklistsChanged();
		
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
		
		public virtual IList<CannedText> CannedTexts
        {
            get { return _cannedTexts; }
            set
			{
				OnCannedTextsChanging();
				_cannedTexts = value;
				OnCannedTextsChanged();
			}
        }
		partial void OnCannedTextsChanging();
		partial void OnCannedTextsChanged();
		
        #endregion
    }
}
