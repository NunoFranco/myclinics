using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface INotePostingManager : IManagerBase<NotePosting, System.Guid>
    {
		// Get Methods
		IList<NotePosting> GetByAcknowledgedByStaffOID_(System.Guid staff1);
		IList<NotePosting> GetByNoteOID_(System.Guid note);
		IList<NotePosting> GetByRecipientGroupOID_(System.Guid staffGroup);
		IList<NotePosting> GetByRecipientStaffOID_(System.Guid staff2);
    }

    partial class NotePostingManager : ManagerBase<NotePosting, System.Guid>, INotePostingManager
    {
		#region Constructors
		
		public NotePostingManager() : base()
        {
        }
        public NotePostingManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<NotePosting> GetByAcknowledgedByStaffOID_(System.Guid staff1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(NotePosting));
			
			
			ICriteria staff1Criteria = criteria.CreateCriteria("Staff1");
            staff1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff1));
			
			return criteria.List<NotePosting>();
        }
		
		public IList<NotePosting> GetByNoteOID_(System.Guid note)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(NotePosting));
			
			
			ICriteria noteCriteria = criteria.CreateCriteria("Note");
            noteCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", note));
			
			return criteria.List<NotePosting>();
        }
		
		public IList<NotePosting> GetByRecipientGroupOID_(System.Guid staffGroup)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(NotePosting));
			
			
			ICriteria staffGroupCriteria = criteria.CreateCriteria("StaffGroup");
            staffGroupCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffGroup));
			
			return criteria.List<NotePosting>();
        }
		
		public IList<NotePosting> GetByRecipientStaffOID_(System.Guid staff2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(NotePosting));
			
			
			ICriteria staff2Criteria = criteria.CreateCriteria("Staff2");
            staff2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff2));
			
			return criteria.List<NotePosting>();
        }
		
		#endregion
    }
}