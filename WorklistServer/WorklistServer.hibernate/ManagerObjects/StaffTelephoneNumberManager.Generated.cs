using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffTelephoneNumberManager : IManagerBase<StaffTelephoneNumber, System.Guid>
    {
		// Get Methods
		IList<StaffTelephoneNumber> GetByEquipment_(System.String telephoneEquipmentEnum);
		IList<StaffTelephoneNumber> GetByStaffOID_(System.Guid staff);
		IList<StaffTelephoneNumber> GetByUse_(System.String telephoneUseEnum);
    }

    partial class StaffTelephoneNumberManager : ManagerBase<StaffTelephoneNumber, System.Guid>, IStaffTelephoneNumberManager
    {
		#region Constructors
		
		public StaffTelephoneNumberManager() : base()
        {
        }
        public StaffTelephoneNumberManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<StaffTelephoneNumber> GetByEquipment_(System.String telephoneEquipmentEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffTelephoneNumber));
			
			
			ICriteria telephoneEquipmentEnumCriteria = criteria.CreateCriteria("TelephoneEquipmentEnum");
            telephoneEquipmentEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", telephoneEquipmentEnum));
			
			return criteria.List<StaffTelephoneNumber>();
        }
		
		public IList<StaffTelephoneNumber> GetByStaffOID_(System.Guid staff)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffTelephoneNumber));
			
			
			ICriteria staffCriteria = criteria.CreateCriteria("Staff");
            staffCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff));
			
			return criteria.List<StaffTelephoneNumber>();
        }
		
		public IList<StaffTelephoneNumber> GetByUse_(System.String telephoneUseEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffTelephoneNumber));
			
			
			ICriteria telephoneUseEnumCriteria = criteria.CreateCriteria("TelephoneUseEnum");
            telephoneUseEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", telephoneUseEnum));
			
			return criteria.List<StaffTelephoneNumber>();
        }
		
		#endregion
    }
}