using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileContactPersonManager : IManagerBase<PatientProfileContactPerson, System.Guid>
    {
		// Get Methods
		IList<PatientProfileContactPerson> GetByPatientProfileOID_(System.Guid patientProfile);
		IList<PatientProfileContactPerson> GetByRelationship_(System.String contactPersonRelationshipEnum);
		IList<PatientProfileContactPerson> GetByType_(System.String contactPersonTypeEnum);
    }

    partial class PatientProfileContactPersonManager : ManagerBase<PatientProfileContactPerson, System.Guid>, IPatientProfileContactPersonManager
    {
		#region Constructors
		
		public PatientProfileContactPersonManager() : base()
        {
        }
        public PatientProfileContactPersonManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientProfileContactPerson> GetByPatientProfileOID_(System.Guid patientProfile)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileContactPerson));
			
			
			ICriteria patientProfileCriteria = criteria.CreateCriteria("PatientProfile");
            patientProfileCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientProfile));
			
			return criteria.List<PatientProfileContactPerson>();
        }
		
		public IList<PatientProfileContactPerson> GetByRelationship_(System.String contactPersonRelationshipEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileContactPerson));
			
			
			ICriteria contactPersonRelationshipEnumCriteria = criteria.CreateCriteria("ContactPersonRelationshipEnum");
            contactPersonRelationshipEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", contactPersonRelationshipEnum));
			
			return criteria.List<PatientProfileContactPerson>();
        }
		
		public IList<PatientProfileContactPerson> GetByType_(System.String contactPersonTypeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfileContactPerson));
			
			
			ICriteria contactPersonTypeEnumCriteria = criteria.CreateCriteria("ContactPersonTypeEnum");
            contactPersonTypeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", contactPersonTypeEnum));
			
			return criteria.List<PatientProfileContactPerson>();
        }
		
		#endregion
    }
}