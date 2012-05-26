using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffEmailAddressManager : IManagerBase<StaffEmailAddress, System.Guid>
    {
		// Get Methods
		IList<StaffEmailAddress> GetByStaffOID_(System.Guid staff);
    }

    partial class StaffEmailAddressManager : ManagerBase<StaffEmailAddress, System.Guid>, IStaffEmailAddressManager
    {
		#region Constructors
		
		public StaffEmailAddressManager() : base()
        {
        }
        public StaffEmailAddressManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<StaffEmailAddress> GetByStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffEmailAddress));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<StaffEmailAddress>();
        }
		
		#endregion
    }
}