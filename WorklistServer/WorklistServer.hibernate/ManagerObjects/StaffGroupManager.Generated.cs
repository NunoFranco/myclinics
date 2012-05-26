using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffGroupManager : IManagerBase<StaffGroup, System.Guid>
    {
		// Get Methods
		StaffGroup GetByName_(System.String name);
    }

    partial class StaffGroupManager : ManagerBase<StaffGroup, System.Guid>, IStaffGroupManager
    {
		#region Constructors
		
		public StaffGroupManager() : base()
        {
        }
        public StaffGroupManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public StaffGroup GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffGroup));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<StaffGroup> result = criteria.List<StaffGroup>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}