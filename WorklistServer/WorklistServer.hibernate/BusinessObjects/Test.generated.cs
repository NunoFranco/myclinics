using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class Test : BusinessBase<System.Guid>
    {
        #region Declarations

		private System.DateTime? _testDate = null;
		
		
		
		#endregion

        #region Constructors

        public Test() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_testDate);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual System.DateTime? TestDate
        {
            get { return _testDate; }
			set
			{
				OnTestDateChanging();
				_testDate = value;
				OnTestDateChanged();
			}
        }
		partial void OnTestDateChanging();
		partial void OnTestDateChanged();
		
        #endregion
    }
}
