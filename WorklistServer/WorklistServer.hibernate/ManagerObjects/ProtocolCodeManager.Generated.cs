using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolCodeManager : IManagerBase<ProtocolCode, System.Guid>
    {
		// Get Methods
		ProtocolCode GetByName_(System.String name);
    }

    partial class ProtocolCodeManager : ManagerBase<ProtocolCode, System.Guid>, IProtocolCodeManager
    {
		#region Constructors
		
		public ProtocolCodeManager() : base()
        {
        }
        public ProtocolCodeManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public ProtocolCode GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProtocolCode));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<ProtocolCode> result = criteria.List<ProtocolCode>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}