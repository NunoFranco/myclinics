using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class AccessionSequence : BusinessBase<long>
    {
        #region Declarations

		
		
		
		#endregion

        #region Constructors

        public AccessionSequence() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

        #endregion
    }
}
