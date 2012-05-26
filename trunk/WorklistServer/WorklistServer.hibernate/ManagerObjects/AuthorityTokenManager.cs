using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAuthorityTokenManager : IManagerBase<AuthorityToken, System.Guid>
    {
	}
	
	partial class AuthorityTokenManager : ManagerBase<AuthorityToken, System.Guid>, IAuthorityTokenManager
    {
	}
}