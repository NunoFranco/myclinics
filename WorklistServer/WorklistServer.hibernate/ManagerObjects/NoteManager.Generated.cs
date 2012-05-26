using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface INoteManager : IManagerBase<Note, System.Guid>
    {
		// Get Methods
		IList<Note> GetByAuthorOID_(System.Guid staff);
		IList<Note> GetByOnBehalfOfGroupOID_(System.Guid staffGroup);
		IList<Note> GetByOrderOID_(System.Guid order);
    }

    partial class NoteManager : ManagerBase<Note, System.Guid>, INoteManager
    {
		#region Constructors
		
		public NoteManager() : base()
        {
        }
        public NoteManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Note> GetByAuthorOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Note));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<Note>();
        }
		
		public IList<Note> GetByOnBehalfOfGroupOID_(System.Guid staffGroup)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Note));
			
			
			ICriteria staffGroupCriteria = criteria.CreateCriteria("StaffGroup");
            staffGroupCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffGroup));
			
			return criteria.List<Note>();
        }
		
		public IList<Note> GetByOrderOID_(System.Guid order)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Note));
			
			
			ICriteria orderCriteria = criteria.CreateCriteria("Order");
            orderCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", order));
			
			return criteria.List<Note>();
        }
		
		#endregion
    }
}