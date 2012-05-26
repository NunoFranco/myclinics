using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientNoteManager : IManagerBase<PatientNote, System.Guid>
    {
		// Get Methods
		IList<PatientNote> GetByAuthorOID_(System.Guid staff);
		IList<PatientNote> GetByCategoryOID_(System.Guid patientNoteCategory);
		IList<PatientNote> GetByPatientOID_(System.Guid patient);
    }

    partial class PatientNoteManager : ManagerBase<PatientNote, System.Guid>, IPatientNoteManager
    {
		#region Constructors
		
		public PatientNoteManager() : base()
        {
        }
        public PatientNoteManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientNote> GetByAuthorOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientNote));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<PatientNote>();
        }
		
		public IList<PatientNote> GetByCategoryOID_(System.Guid patientNoteCategory)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientNote));
			
			
			ICriteria patientNoteCategoryCriteria = criteria.CreateCriteria("PatientNoteCategory");
            patientNoteCategoryCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patientNoteCategory));
			
			return criteria.List<PatientNote>();
        }
		
		public IList<PatientNote> GetByPatientOID_(System.Guid patient)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientNote));
			
			
			ICriteria patientCriteria = criteria.CreateCriteria("Patient");
            patientCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", patient));
			
			return criteria.List<PatientNote>();
        }
		
		#endregion
    }
}