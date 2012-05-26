using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class VisitLocation : BusinessBase<System.Guid>
    {
        #region Declarations

		private System.DateTime? _startTime = null;
		private System.DateTime? _endTime = null;
		
		private Location _location = null;
		private VisitLocationRoleEnum _visitLocationRoleEnum = null;
		private Visit _visit = null;
		
		
		#endregion

        #region Constructors

        public VisitLocation() { }

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
		
		public virtual Location Location
        {
            get { return _location; }
			set
			{
				OnLocationChanging();
				_location = value;
				OnLocationChanged();
			}
        }
		partial void OnLocationChanging();
		partial void OnLocationChanged();
		
		public virtual VisitLocationRoleEnum VisitLocationRoleEnum
        {
            get { return _visitLocationRoleEnum; }
			set
			{
				OnVisitLocationRoleEnumChanging();
				_visitLocationRoleEnum = value;
				OnVisitLocationRoleEnumChanged();
			}
        }
		partial void OnVisitLocationRoleEnumChanging();
		partial void OnVisitLocationRoleEnumChanged();
		
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
