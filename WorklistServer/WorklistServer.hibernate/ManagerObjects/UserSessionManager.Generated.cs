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
		// Get Methods
		IList<UserSession> GetByUserOID_(System.Guid user);
		UserSession GetBySessionId_(System.String sessionId);
    }

    partial class UserSessionManager : ManagerBase<UserSession, System.Guid>, IUserSessionManager
    {
		#region Constructors
		
		public UserSessionManager() : base()
        {
        }
        public UserSessionManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<UserSession> GetByUserOID_(System.Guid user)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserSession));
			
			
			ICriteria userCriteria = criteria.CreateCriteria("User");
            userCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", user));
			
			return criteria.List<UserSession>();
        }
		
		public UserSession GetBySessionId_(System.String sessionId)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(UserSession));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("SessionId", sessionId));
			
			IList<UserSession> result = criteria.List<UserSession>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}