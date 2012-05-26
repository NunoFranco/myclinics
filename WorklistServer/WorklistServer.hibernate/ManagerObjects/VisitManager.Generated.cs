using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitManager : IManagerBase<Visit, System.Guid>
    {
		// Get Methods
		IList<Visit> GetByAdmissionType_(System.String admissionTypeEnum);
		IList<Visit> GetByCurrentLocationOID_(System.Guid location);
		IList<Visit> GetByFacilityOID_(System.Guid facility);
		IList<Visit> GetByPatientClass_(System.String patientClassEnum);
		IList<Visit> GetByPatientOID_(System.Guid patient);
		IList<Visit> GetByPatientType_(System.String patientTypeEnum);
		IList<Visit> GetByStatus_(System.String visitStatusEnum);
		IList<Visit> GetByVisitNumberAssigningAuthority_(System.String informationAuthorityEnum);
		IList<Visit> GetByVisitNumberId_VisitNumberAssigningAuthority_(System.String visitNumberId, System.String informationAuthorityEnum);
    }

    partial class VisitManager : ManagerBase<Visit, System.Guid>, IVisitManager
    {
		#region Constructors
		
		public VisitManager() : base()
        {
        }
        public VisitManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Visit> GetByAdmissionType_(System.String admissionTypeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria admissionTypeEnumCriteria = criteria.CreateCriteria("AdmissionTypeEnum");
            admissionTypeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", admissionTypeEnum));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByCurrentLocationOID_(System.Guid location)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria locationCriteria = criteria.CreateCriteria("Location");
            locationCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", location));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByFacilityOID_(System.Guid facility)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria facilityCriteria = criteria.CreateCriteria("Facility");
            facilityCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", facility));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByPatientClass_(System.String patientClassEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria patientClassEnumCriteria = criteria.CreateCriteria("PatientClassEnum");
            patientClassEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientClassEnum));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByPatientOID_(System.Guid patient)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria patientCriteria = criteria.CreateCriteria("Patient");
            patientCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patient));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByPatientType_(System.String patientTypeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria patientTypeEnumCriteria = criteria.CreateCriteria("PatientTypeEnum");
            patientTypeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientTypeEnum));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByStatus_(System.String visitStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria visitStatusEnumCriteria = criteria.CreateCriteria("VisitStatusEnum");
            visitStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", visitStatusEnum));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByVisitNumberAssigningAuthority_(System.String informationAuthorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			ICriteria informationAuthorityEnumCriteria = criteria.CreateCriteria("InformationAuthorityEnum");
            informationAuthorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", informationAuthorityEnum));
			
			return criteria.List<Visit>();
        }
		
		public IList<Visit> GetByVisitNumberId_VisitNumberAssigningAuthority_(System.String visitNumberId, System.String informationAuthorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Visit));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("VisitNumberId", visitNumberId));
			
			ICriteria informationAuthorityEnumCriteria = criteria.CreateCriteria("InformationAuthorityEnum");
            informationAuthorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", informationAuthorityEnum));
			
			return criteria.List<Visit>();
        }
		
		#endregion
    }
}