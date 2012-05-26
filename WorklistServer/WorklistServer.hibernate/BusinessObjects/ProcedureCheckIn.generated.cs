using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class ProcedureCheckIn : BusinessBase<System.Guid>
    {
        #region Declarations

		private int _version = default(Int32);
		private System.DateTime? _checkInTime = null;
		private System.DateTime? _checkOutTime = null;
		
		
		private IList<Procedure> _procedures = new List<Procedure>();
		
		#endregion

        #region Constructors

        public ProcedureCheckIn() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_version);
			sb.Append(_checkInTime);
			sb.Append(_checkOutTime);

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
		
		public virtual System.DateTime? CheckInTime
        {
            get { return _checkInTime; }
			set
			{
				OnCheckInTimeChanging();
				_checkInTime = value;
				OnCheckInTimeChanged();
			}
        }
		partial void OnCheckInTimeChanging();
		partial void OnCheckInTimeChanged();
		
		public virtual System.DateTime? CheckOutTime
        {
            get { return _checkOutTime; }
			set
			{
				OnCheckOutTimeChanging();
				_checkOutTime = value;
				OnCheckOutTimeChanged();
			}
        }
		partial void OnCheckOutTimeChanging();
		partial void OnCheckOutTimeChanged();
		
		public virtual IList<Procedure> Procedures
        {
            get { return _procedures; }
            set
			{
				OnProceduresChanging();
				_procedures = value;
				OnProceduresChanged();
			}
        }
		partial void OnProceduresChanging();
		partial void OnProceduresChanged();
		
        #endregion
    }
}
