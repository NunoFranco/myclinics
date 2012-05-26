using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class OrderResultRecipient : BusinessBase<System.Guid>
    {
        #region Declarations

		
		private Order _order = null;
		private ExternalPractitionerContactPoint _externalPractitionerContactPoint = null;
		private ResultCommunicationModeEnum _resultCommunicationModeEnum = null;
		
		
		#endregion

        #region Constructors

        public OrderResultRecipient() { }

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
		
		public virtual ExternalPractitionerContactPoint ExternalPractitionerContactPoint
        {
            get { return _externalPractitionerContactPoint; }
			set
			{
				OnExternalPractitionerContactPointChanging();
				_externalPractitionerContactPoint = value;
				OnExternalPractitionerContactPointChanged();
			}
        }
		partial void OnExternalPractitionerContactPointChanging();
		partial void OnExternalPractitionerContactPointChanged();
		
		public virtual ResultCommunicationModeEnum ResultCommunicationModeEnum
        {
            get { return _resultCommunicationModeEnum; }
			set
			{
				OnResultCommunicationModeEnumChanging();
				_resultCommunicationModeEnum = value;
				OnResultCommunicationModeEnumChanged();
			}
        }
		partial void OnResultCommunicationModeEnumChanging();
		partial void OnResultCommunicationModeEnumChanged();
		
        #endregion
    }
}
