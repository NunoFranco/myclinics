using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ICannedTextManager : IManagerBase<CannedText, System.Guid>
    {
		// Get Methods
		IList<CannedText> GetByStaffGroupOID_(System.Guid staffGroup);
		IList<CannedText> GetByStaffOID_(System.Guid staff);
		IList<CannedText> GetByName_Category_StaffOID_StaffGroupOID_(System.String name, System.String category, System.Guid staff, System.Guid staffGroup);
    }

    partial class CannedTextManager : ManagerBase<CannedText, System.Guid>, ICannedTextManager
    {
		#region Constructors
		
		public CannedTextManager() : base()
        {
        }
        public CannedTextManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<CannedText> GetByStaffGroupOID_(System.Guid staffGroup)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(CannedText));
			
			
			ICriteria staffGroupCriteria = criteria.CreateCriteria("StaffGroup");
            staffGroupCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffGroup));
			
			return criteria.List<CannedText>();
        }
		
		public IList<CannedText> GetByStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(CannedText));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<CannedText>();
        }
		
		public IList<CannedText> GetByName_Category_StaffOID_StaffGroupOID_(System.String name, System.String category, System.Guid staff, System.Guid staffGroup)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(CannedText));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Category", category));
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			ICriteria staffGroupCriteria = criteria.CreateCriteria("StaffGroup");
            staffGroupCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffGroup));
			
			return criteria.List<CannedText>();
        }
		
		#endregion
    }
}