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
	}
	
	partial class ContactPersonRelationshipEnumManager : ManagerBase<ContactPersonRelationshipEnum, string>, IContactPersonRelationshipEnumManager
    {
	}
}