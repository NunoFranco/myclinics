using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IUserSessionManager : IManagerBase<UserSession, System.Guid>
    {
	}
	
	partial class UserSessionManager : ManagerBase<UserSession, System.Guid>, IUserSessionManager
    {
	}
}