using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IContactPersonTypeEnumManager : IManagerBase<ContactPersonTypeEnum, string>
    {
		// Get Methods
    }

    partial class ContactPersonTypeEnumManager : ManagerBase<ContactPersonTypeEnum, string>, IContactPersonTypeEnumManager
    {
		#region Constructors
		
		public ContactPersonTypeEnumManager() : base()
        {
        }
        public ContactPersonTypeEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}