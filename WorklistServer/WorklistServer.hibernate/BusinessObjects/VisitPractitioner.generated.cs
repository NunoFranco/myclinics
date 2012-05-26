using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class VisitPractitioner : BusinessBase<System.Guid>
    {
        #region Declarations

		private System.DateTime? _startTime = null;
		private System.DateTime? _endTime = null;
		
		private ExternalPractitioner _externalPractitioner = null;
		private VisitPractitionerRoleEnum _visitPractitionerRoleEnum = null;
		private Visit _visit = null;
		
		
		#endregion

        #region Constructors

        public VisitPractitioner() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_startTime);
			sb.Append(_endTime);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual System.DateTime? StartTime
        {
            get { return _startTime; }
			set
			{
				OnStartTimeChanging();
				_startTime = value;
				OnStartTimeChanged();
			}
        }
		partial void OnStartTimeChanging();
		partial void OnStartTimeChanged();
		
		public virtual System.DateTime? EndTime
        {
            get { return _endTime; }
			set
			{
				OnEndTimeChanging();
				_endTime = value;
				OnEndTimeChanged();
			}
        }
		partial void OnEndTimeChanging();
		partial void OnEndTimeChanged();
		
		public virtual ExternalPractitioner ExternalPractitioner
        {
            get { return _externalPractitioner; }
			set
			{
				OnExternalPractitionerChanging();
				_externalPractitioner = value;
				OnExternalPractitionerChanged();
			}
        }
		partial void OnExternalPractitionerChanging();
		partial void OnExternalPractitionerChanged();
		
		public virtual VisitPractitionerRoleEnum VisitPractitionerRoleEnum
        {
            get { return _visitPractitionerRoleEnum; }
			set
			{
				OnVisitPractitionerRoleEnumChanging();
				_visitPractitionerRoleEnum = value;
				OnVisitPractitionerRoleEnumChanged();
			}
        }
		partial void OnVisitPractitionerRoleEnumChanging();
		partial void OnVisitPractitionerRoleEnumChanged();
		
		public virtual Visit Visit
        {
            get { return _visit; }
			set
			{
				OnVisitChanging();
				_visit = value;
				OnVisitChanged();
			}
        }
		partial void OnVisitChanging();
		partial void OnVisitChanged();
		
        #endregion
    }
}
