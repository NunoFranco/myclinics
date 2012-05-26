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
		// Get Methods
		AuthorityToken GetByName_(System.String name);
    }

    partial class AuthorityTokenManager : ManagerBase<AuthorityToken, System.Guid>, IAuthorityTokenManager
    {
		#region Constructors
		
		public AuthorityTokenManager() : base()
        {
        }
        public AuthorityTokenManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public AuthorityToken GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(AuthorityToken));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<AuthorityToken> result = criteria.List<AuthorityToken>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}