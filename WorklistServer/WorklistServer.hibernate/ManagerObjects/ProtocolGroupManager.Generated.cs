using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolGroupManager : IManagerBase<ProtocolGroup, System.Guid>
    {
		// Get Methods
		ProtocolGroup GetByName_(System.String name);
    }

    partial class ProtocolGroupManager : ManagerBase<ProtocolGroup, System.Guid>, IProtocolGroupManager
    {
		#region Constructors
		
		public ProtocolGroupManager() : base()
        {
        }
        public ProtocolGroupManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public ProtocolGroup GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProtocolGroup));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<ProtocolGroup> result = criteria.List<ProtocolGroup>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}