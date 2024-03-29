using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAuthorityGroupManager : IManagerBase<AuthorityGroup, System.Guid>
    {
	}
	
	partial class AuthorityGroupManager : ManagerBase<AuthorityGroup, System.Guid>, IAuthorityGroupManager
    {
	}
}