using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IContactPersonRelationshipEnumManager : IManagerBase<ContactPersonRelationshipEnum, string>
    {
		// Get Methods
    }

    partial class ContactPersonRelationshipEnumManager : ManagerBase<ContactPersonRelationshipEnum, string>, IContactPersonRelationshipEnumManager
    {
		#region Constructors
		
		public ContactPersonRelationshipEnumManager() : base()
        {
        }
        public ContactPersonRelationshipEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}