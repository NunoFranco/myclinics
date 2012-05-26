using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientAttachmentManager : IManagerBase<PatientAttachment, System.Guid>
    {
		// Get Methods
		IList<PatientAttachment> GetByAttachedByStaffOID_(System.Guid staff);
		IList<PatientAttachment> GetByAttachedDocumentOID_(System.Guid attachedDocument);
		IList<PatientAttachment> GetByCategory_(System.String patientAttachmentCategoryEnum);
		IList<PatientAttachment> GetByPatientOID_(System.Guid patient);
    }

    partial class PatientAttachmentManager : ManagerBase<PatientAttachment, System.Guid>, IPatientAttachmentManager
    {
		#region Constructors
		
		public PatientAttachmentManager() : base()
        {
        }
        public PatientAttachmentManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientAttachment> GetByAttachedByStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientAttachment));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<PatientAttachment>();
        }
		
		public IList<PatientAttachment> GetByAttachedDocumentOID_(System.Guid attachedDocument)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientAttachment));
			
			
			ICriteria attachedDocumentCriteria = criteria.CreateCriteria("AttachedDocument");
            attachedDocumentCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", attachedDocument));
			
			return criteria.List<PatientAttachment>();
        }
		
		public IList<PatientAttachment> GetByCategory_(System.String patientAttachmentCategoryEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientAttachment));
			
			
			ICriteria patientAttachmentCategoryEnumCriteria = criteria.CreateCriteria("PatientAttachmentCategoryEnum");
            patientAttachmentCategoryEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientAttachmentCategoryEnum));
			
			return criteria.List<PatientAttachment>();
        }
		
		public IList<PatientAttachment> GetByPatientOID_(System.Guid patient)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientAttachment));
			
			
			ICriteria patientCriteria = criteria.CreateCriteria("Patient");
            patientCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patient));
			
			return criteria.List<PatientAttachment>();
        }
		
		#endregion
    }
}