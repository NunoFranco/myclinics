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
		// Get Methods
		AuthorityGroup GetByName_(System.String name);
    }

    partial class AuthorityGroupManager : ManagerBase<AuthorityGroup, System.Guid>, IAuthorityGroupManager
    {
		#region Constructors
		
		public AuthorityGroupManager() : base()
        {
        }
        public AuthorityGroupManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public AuthorityGroup GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(AuthorityGroup));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<AuthorityGroup> result = criteria.List<AuthorityGroup>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}