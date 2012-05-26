using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileEmailAddressManager : IManagerBase<PatientProfileEmailAddress, System.Guid>
    {
		// Get Methods
		IList<PatientProfileEmailAddress> GetByPatientProfileOID_(System.Guid patientProfile);
    }

    partial class PatientProfileEmailAddressManager : ManagerBase<PatientProfileEmailAddress, System.Guid>, IPatientProfileEmailAddressManager
    {
		#region Constructors
		
		public PatientProfileEmailAddressManager() : base()
        {
        }
        public PatientProfileEmailAddressManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientProfileEmailAddress> GetByPatientProfileOID_(System.Guid patientProfile)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileEmailAddress));
			
			
			ICriteria patientProfileCriteria = criteria.CreateCriteria("PatientProfile");
            patientProfileCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientProfile));
			
			return criteria.List<PatientProfileEmailAddress>();
        }
		
		#endregion
    }
}