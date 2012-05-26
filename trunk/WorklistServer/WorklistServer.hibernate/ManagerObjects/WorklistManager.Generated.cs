using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IWorklistManager : IManagerBase<Worklist, System.Guid>
    {
		// Get Methods
		IList<Worklist> GetByOwnerGroupOID_(System.Guid staffGroup);
		IList<Worklist> GetByOwnerStaffOID_(System.Guid staff);
		IList<Worklist> GetByFullClassName_Name_OwnerStaffOID_OwnerGroupOID_(System.String fullClassName, System.String name, System.Guid staff, System.Guid staffGroup);
    }

    partial class WorklistManager : ManagerBase<Worklist, System.Guid>, IWorklistManager
    {
		#region Constructors
		
		public WorklistManager() : base()
        {
        }
        public WorklistManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Worklist> GetByOwnerGroupOID_(System.Guid staffGroup)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Worklist));
			
			
			ICriteria staffGroupCriteria = criteria.CreateCriteria("StaffGroup");
            staffGroupCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffGroup));
			
			return criteria.List<Worklist>();
        }
		
		public IList<Worklist> GetByOwnerStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Worklist));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<Worklist>();
        }
		
		public IList<Worklist> GetByFullClassName_Name_OwnerStaffOID_OwnerGroupOID_(System.String fullClassName, System.String name, System.Guid staff, System.Guid staffGroup)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Worklist));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("FullClassName", fullClassName));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			ICriteria staffGroupCriteria = criteria.CreateCriteria("StaffGroup");
            staffGroupCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffGroup));
			
			return criteria.List<Worklist>();
        }
		
		#endregion
    }
}