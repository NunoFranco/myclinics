using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileAddressManager : IManagerBase<PatientProfileAddress, System.Guid>
    {
		// Get Methods
		IList<PatientProfileAddress> GetByPatientProfileOID_(System.Guid patientProfile);
		IList<PatientProfileAddress> GetByType_(System.String addressTypeEnum);
    }

    partial class PatientProfileAddressManager : ManagerBase<PatientProfileAddress, System.Guid>, IPatientProfileAddressManager
    {
		#region Constructors
		
		public PatientProfileAddressManager() : base()
        {
        }
        public PatientProfileAddressManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientProfileAddress> GetByPatientProfileOID_(System.Guid patientProfile)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileAddress));
			
			
			ICriteria patientProfileCriteria = criteria.CreateCriteria("PatientProfile");
            patientProfileCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientProfile));
			
			return criteria.List<PatientProfileAddress>();
        }
		
		public IList<PatientProfileAddress> GetByType_(System.String addressTypeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileAddress));
			
			
			ICriteria addressTypeEnumCriteria = criteria.CreateCriteria("AddressTypeEnum");
            addressTypeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", addressTypeEnum));
			
			return criteria.List<PatientProfileAddress>();
        }
		
		#endregion
    }
}