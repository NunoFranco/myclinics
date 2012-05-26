using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IUserManager : IManagerBase<User, System.Guid>
    {
	}
	
	partial class UserManager : ManagerBase<User, System.Guid>, IUserManager
    {
	}
}