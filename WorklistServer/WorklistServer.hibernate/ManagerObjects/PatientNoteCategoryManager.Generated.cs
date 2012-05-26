using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientNoteCategoryManager : IManagerBase<PatientNoteCategory, System.Guid>
    {
		// Get Methods
		IList<PatientNoteCategory> GetBySeverity_(System.String noteSeverityEnum);
		PatientNoteCategory GetByName_(System.String name);
    }

    partial class PatientNoteCategoryManager : ManagerBase<PatientNoteCategory, System.Guid>, IPatientNoteCategoryManager
    {
		#region Constructors
		
		public PatientNoteCategoryManager() : base()
        {
        }
        public PatientNoteCategoryManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<PatientNoteCategory> GetBySeverity_(System.String noteSeverityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientNoteCategory));
			
			
			ICriteria noteSeverityEnumCriteria = criteria.CreateCriteria("NoteSeverityEnum");
            noteSeverityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", noteSeverityEnum));
			
			return criteria.List<PatientNoteCategory>();
        }
		
		public PatientNoteCategory GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(PatientNoteCategory));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<PatientNoteCategory> result = criteria.List<PatientNoteCategory>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}