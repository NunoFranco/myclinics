using System;
using System.Collections;
using System.Collections.Generic;

using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.BusinessObjects
{
    public partial class PatientProfileExpiredMrn : BusinessBase<System.Guid>
    {
        #region Declarations

		private string _mrnId = String.Empty;
		
		private InformationAuthorityEnum _informationAuthorityEnum = null;
		private PatientProfile _patientProfile = null;
		
		
		#endregion

        #region Constructors

        public PatientProfileExpiredMrn() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_mrnId);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string MrnId
        {
            get { return _mrnId; }
			set
			{
				OnMrnIdChanging();
				_mrnId = value;
				OnMrnIdChanged();
			}
        }
		partial void OnMrnIdChanging();
		partial void OnMrnIdChanged();
		
		public virtual InformationAuthorityEnum InformationAuthorityEnum
        {
            get { return _informationAuthorityEnum; }
			set
			{
				OnInformationAuthorityEnumChanging();
				_informationAuthorityEnum = value;
				OnInformationAuthorityEnumChanged();
			}
        }
		partial void OnInformationAuthorityEnumChanging();
		partial void OnInformationAuthorityEnumChanged();
		
		public virtual PatientProfile PatientProfile
        {
            get { return _patientProfile; }
			set
			{
				OnPatientProfileChanging();
				_patientProfile = value;
				OnPatientProfileChanged();
			}
        }
		partial void OnPatientProfileChanging();
		partial void OnPatientProfileChanged();
		
        #endregion
    }
}
