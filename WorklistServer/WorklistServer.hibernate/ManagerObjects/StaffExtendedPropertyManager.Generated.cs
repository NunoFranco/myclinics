using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IStaffExtendedPropertyManager : IManagerBase<StaffExtendedProperty, string>
    {
		// Get Methods
		StaffExtendedProperty GetById(System.Guid staffOID, System.String name);
		IList<StaffExtendedProperty> GetByStaffOID_(System.Guid staffOID);
    }

    partial class StaffExtendedPropertyManager : ManagerBase<StaffExtendedProperty, string>, IStaffExtendedPropertyManager
    {
		#region Constructors
		
		public StaffExtendedPropertyManager() : base()
        {
        }
        public StaffExtendedPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override StaffExtendedProperty GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for StaffExtendedPropertyManager.GetById");
			
			return GetById(new System.Guid(keys[0]), keys[1]);
		}
		public StaffExtendedProperty GetById(System.Guid staffOID, System.String name)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffExtendedProperty));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("StaffOID_", staffOID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name_", name));
			
			StaffExtendedProperty result = (StaffExtendedProperty)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<StaffExtendedProperty> GetByStaffOID_(System.Guid staffOID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(StaffExtendedProperty));
			
			
			ICriteria staffOIDCriteria = criteria.CreateCriteria("StaffOID");
            staffOIDCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", staffOID));
			
			return criteria.List<StaffExtendedProperty>();
        }
		
		#endregion
    }
}