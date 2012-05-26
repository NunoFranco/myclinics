using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileTelephoneNumberManager : IManagerBase<PatientProfileTelephoneNumber, System.Guid>
    {
		// Get Methods
		IList<PatientProfileTelephoneNumber> GetByEquipment_(System.String telephoneEquipmentEnum);
		IList<PatientProfileTelephoneNumber> GetByPatientProfileOID_(System.Guid patientProfile);
		IList<PatientProfileTelephoneNumber> GetByUse_(System.String telephoneUseEnum);
    }

    partial class PatientProfileTelephoneNumberManager : ManagerBase<PatientProfileTelephoneNumber, System.Guid>, IPatientProfileTelephoneNumberManager
    {
		#region Constructors
		
		public PatientProfileTelephoneNumberManager() : base()
        {
        }
        public PatientProfileTelephoneNumberManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientProfileTelephoneNumber> GetByEquipment_(System.String telephoneEquipmentEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileTelephoneNumber));
			
			
			ICriteria telephoneEquipmentEnumCriteria = criteria.CreateCriteria("TelephoneEquipmentEnum");
            telephoneEquipmentEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", telephoneEquipmentEnum));
			
			return criteria.List<PatientProfileTelephoneNumber>();
        }
		
		public IList<PatientProfileTelephoneNumber> GetByPatientProfileOID_(System.Guid patientProfile)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileTelephoneNumber));
			
			
			ICriteria patientProfileCriteria = criteria.CreateCriteria("PatientProfile");
            patientProfileCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientProfile));
			
			return criteria.List<PatientProfileTelephoneNumber>();
        }
		
		public IList<PatientProfileTelephoneNumber> GetByUse_(System.String telephoneUseEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileTelephoneNumber));
			
			
			ICriteria telephoneUseEnumCriteria = criteria.CreateCriteria("TelephoneUseEnum");
            telephoneUseEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", telephoneUseEnum));
			
			return criteria.List<PatientProfileTelephoneNumber>();
        }
		
		#endregion
    }
}