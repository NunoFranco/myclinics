using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileManager : IManagerBase<PatientProfile, System.Guid>
    {
		// Get Methods
		IList<PatientProfile> GetByHealthcardAssigningAuthority_(System.String insuranceAuthorityEnum);
		IList<PatientProfile> GetByMrnAssigningAuthority_(System.String informationAuthorityEnum);
		IList<PatientProfile> GetByPatientOID_(System.Guid patient);
		IList<PatientProfile> GetByPrimaryLanguage_(System.String spokenLanguageEnum);
		IList<PatientProfile> GetByReligion_(System.String religionEnum);
		IList<PatientProfile> GetBySex_(System.String sexEnum);
		IList<PatientProfile> GetByDateOfBirth_(System.DateTime dateOfBirth);
		IList<PatientProfile> GetByFamilyName_(System.String familyName);
		IList<PatientProfile> GetByGivenName_(System.String givenName);
		IList<PatientProfile> GetByHealthcardId_(System.String healthcardId);
		IList<PatientProfile> GetByMrnId_(System.String mrnId);
		IList<PatientProfile> GetByMrnId_MrnAssigningAuthority_(System.String mrnId, System.String informationAuthorityEnum);
    }

    partial class PatientProfileManager : ManagerBase<PatientProfile, System.Guid>, IPatientProfileManager
    {
		#region Constructors
		
		public PatientProfileManager() : base()
        {
        }
        public PatientProfileManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientProfile> GetByHealthcardAssigningAuthority_(System.String insuranceAuthorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			ICriteria insuranceAuthorityEnumCriteria = criteria.CreateCriteria("InsuranceAuthorityEnum");
            insuranceAuthorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", insuranceAuthorityEnum));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByMrnAssigningAuthority_(System.String informationAuthorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			ICriteria informationAuthorityEnumCriteria = criteria.CreateCriteria("InformationAuthorityEnum");
            informationAuthorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", informationAuthorityEnum));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByPatientOID_(System.Guid patient)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			ICriteria patientCriteria = criteria.CreateCriteria("Patient");
            patientCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patient));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByPrimaryLanguage_(System.String spokenLanguageEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			ICriteria spokenLanguageEnumCriteria = criteria.CreateCriteria("SpokenLanguageEnum");
            spokenLanguageEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", spokenLanguageEnum));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByReligion_(System.String religionEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			ICriteria religionEnumCriteria = criteria.CreateCriteria("ReligionEnum");
            religionEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", religionEnum));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetBySex_(System.String sexEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			ICriteria sexEnumCriteria = criteria.CreateCriteria("SexEnum");
            sexEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", sexEnum));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByDateOfBirth_(System.DateTime dateOfBirth)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("DateOfBirth", dateOfBirth));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByFamilyName_(System.String familyName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("FamilyName", familyName));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByGivenName_(System.String givenName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("GivenName", givenName));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByHealthcardId_(System.String healthcardId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("HealthcardId", healthcardId));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByMrnId_(System.String mrnId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("MrnId", mrnId));
			
			return criteria.List<PatientProfile>();
        }
		
		public IList<PatientProfile> GetByMrnId_MrnAssigningAuthority_(System.String mrnId, System.String informationAuthorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientProfile));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("MrnId", mrnId));
			
			ICriteria informationAuthorityEnumCriteria = criteria.CreateCriteria("InformationAuthorityEnum");
            informationAuthorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", informationAuthorityEnum));
			
			return criteria.List<PatientProfile>();
        }
		
		#endregion
    }
}