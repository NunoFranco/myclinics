using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IInsuranceAuthorityEnumManager : IManagerBase<InsuranceAuthorityEnum, string>
    {
		// Get Methods
    }

    partial class InsuranceAuthorityEnumManager : ManagerBase<InsuranceAuthorityEnum, string>, IInsuranceAuthorityEnumManager
    {
		#region Constructors
		
		public InsuranceAuthorityEnumManager() : base()
        {
        }
        public InsuranceAuthorityEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}