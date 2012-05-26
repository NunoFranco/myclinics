using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileExpiredMrnManager : IManagerBase<PatientProfileExpiredMrn, System.Guid>
    {
		// Get Methods
		IList<PatientProfileExpiredMrn> GetByMrnAssigningAuthority_(System.String informationAuthorityEnum);
		IList<PatientProfileExpiredMrn> GetByPatientProfileOID_(System.Guid patientProfile);
    }

    partial class PatientProfileExpiredMrnManager : ManagerBase<PatientProfileExpiredMrn, System.Guid>, IPatientProfileExpiredMrnManager
    {
		#region Constructors
		
		public PatientProfileExpiredMrnManager() : base()
        {
        }
        public PatientProfileExpiredMrnManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientProfileExpiredMrn> GetByMrnAssigningAuthority_(System.String informationAuthorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileExpiredMrn));
			
			
			ICriteria informationAuthorityEnumCriteria = criteria.CreateCriteria("InformationAuthorityEnum");
            informationAuthorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", informationAuthorityEnum));
			
			return criteria.List<PatientProfileExpiredMrn>();
        }
		
		public IList<PatientProfileExpiredMrn> GetByPatientProfileOID_(System.Guid patientProfile)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileExpiredMrn));
			
			
			ICriteria patientProfileCriteria = criteria.CreateCriteria("PatientProfile");
            patientProfileCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientProfile));
			
			return criteria.List<PatientProfileExpiredMrn>();
        }
		
		#endregion
    }
}