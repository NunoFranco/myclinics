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
	}
	
	partial class ContactPersonTypeEnumManager : ManagerBase<ContactPersonTypeEnum, string>, IContactPersonTypeEnumManager
    {
	}
}