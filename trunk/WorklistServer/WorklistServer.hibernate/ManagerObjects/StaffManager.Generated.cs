using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffManager : IManagerBase<Staff, System.Guid>
    {
		// Get Methods
		IList<Staff> GetBySex_(System.String sexEnum);
		IList<Staff> GetByType_(System.String staffTypeEnum);
		IList<Staff> GetByFamilyName_(System.String familyName);
		IList<Staff> GetByGivenName_(System.String givenName);
		IList<Staff> GetByUserName_(System.String userName);
		Staff GetById_(System.String id);
    }

    partial class StaffManager : ManagerBase<Staff, System.Guid>, IStaffManager
    {
		#region Constructors
		
		public StaffManager() : base()
        {
        }
        public StaffManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Staff> GetBySex_(System.String sexEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Staff));
			
			
			ICriteria sexEnumCriteria = criteria.CreateCriteria("SexEnum");
            sexEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", sexEnum));
			
			return criteria.List<Staff>();
        }
		
		public IList<Staff> GetByType_(System.String staffTypeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Staff));
			
			
			ICriteria staffTypeEnumCriteria = criteria.CreateCriteria("StaffTypeEnum");
            staffTypeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffTypeEnum));
			
			return criteria.List<Staff>();
        }
		
		public IList<Staff> GetByFamilyName_(System.String familyName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Staff));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("FamilyName", familyName));
			
			return criteria.List<Staff>();
        }
		
		public IList<Staff> GetByGivenName_(System.String givenName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Staff));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("GivenName", givenName));
			
			return criteria.List<Staff>();
        }
		
		public IList<Staff> GetByUserName_(System.String userName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Staff));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("UserName", userName));
			
			return criteria.List<Staff>();
        }
		
		public Staff GetById_(System.String id)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Staff));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Id", id));
			
			IList<Staff> result = criteria.List<Staff>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}