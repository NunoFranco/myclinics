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
		// Get Methods
		User GetByUserName_(System.String userName);
    }

    partial class UserManager : ManagerBase<User, System.Guid>, IUserManager
    {
		#region Constructors
		
		public UserManager() : base()
        {
        }
        public UserManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public User GetByUserName_(System.String userName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(User));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("UserName", userName));
			
			IList<User> result = criteria.List<User>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}