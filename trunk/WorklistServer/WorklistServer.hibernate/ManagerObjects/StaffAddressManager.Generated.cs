using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffAddressManager : IManagerBase<StaffAddress, System.Guid>
    {
		// Get Methods
		IList<StaffAddress> GetByStaffOID_(System.Guid staff);
		IList<StaffAddress> GetByType_(System.String addressTypeEnum);
    }

    partial class StaffAddressManager : ManagerBase<StaffAddress, System.Guid>, IStaffAddressManager
    {
		#region Constructors
		
		public StaffAddressManager() : base()
        {
        }
        public StaffAddressManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<StaffAddress> GetByStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffAddress));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<StaffAddress>();
        }
		
		public IList<StaffAddress> GetByType_(System.String addressTypeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffAddress));
			
			
			ICriteria addressTypeEnumCriteria = criteria.CreateCriteria("AddressTypeEnum");
            addressTypeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", addressTypeEnum));
			
			return criteria.List<StaffAddress>();
        }
		
		#endregion
    }
}