using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IInformationAuthorityEnumManager : IManagerBase<InformationAuthorityEnum, string>
    {
		// Get Methods
    }

    partial class InformationAuthorityEnumManager : ManagerBase<InformationAuthorityEnum, string>, IInformationAuthorityEnumManager
    {
		#region Constructors
		
		public InformationAuthorityEnumManager() : base()
        {
        }
        public InformationAuthorityEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}