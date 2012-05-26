using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolManager : IManagerBase<Protocol, System.Guid>
    {
		// Get Methods
		IList<Protocol> GetByAuthorOID_(System.Guid staff1);
		IList<Protocol> GetByRejectReason_(System.String protocolRejectReasonEnum);
		IList<Protocol> GetByStatus_(System.String protocolStatusEnum);
		IList<Protocol> GetBySupervisorOID_(System.Guid staff2);
		IList<Protocol> GetByUrgency_(System.String protocolUrgencyEnum);
    }

    partial class ProtocolManager : ManagerBase<Protocol, System.Guid>, IProtocolManager
    {
		#region Constructors
		
		public ProtocolManager() : base()
        {
        }
        public ProtocolManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Protocol> GetByAuthorOID_(System.Guid staff1)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Protocol));
			
			
			ICriteria staff1Criteria = criteria.CreateCriteria("Staff1");
            staff1Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff1));
			
			return criteria.List<Protocol>();
        }
		
		public IList<Protocol> GetByRejectReason_(System.String protocolRejectReasonEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Protocol));
			
			
			ICriteria protocolRejectReasonEnumCriteria = criteria.CreateCriteria("ProtocolRejectReasonEnum");
            protocolRejectReasonEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", protocolRejectReasonEnum));
			
			return criteria.List<Protocol>();
        }
		
		public IList<Protocol> GetByStatus_(System.String protocolStatusEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Protocol));
			
			
			ICriteria protocolStatusEnumCriteria = criteria.CreateCriteria("ProtocolStatusEnum");
            protocolStatusEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", protocolStatusEnum));
			
			return criteria.List<Protocol>();
        }
		
		public IList<Protocol> GetBySupervisorOID_(System.Guid staff2)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Protocol));
			
			
			ICriteria staff2Criteria = criteria.CreateCriteria("Staff2");
            staff2Criteria.Add(NHibernate.Criterion.Expression.Eq("Id", staff2));
			
			return criteria.List<Protocol>();
        }
		
		public IList<Protocol> GetByUrgency_(System.String protocolUrgencyEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Protocol));
			
			
			ICriteria protocolUrgencyEnumCriteria = criteria.CreateCriteria("ProtocolUrgencyEnum");
            protocolUrgencyEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", protocolUrgencyEnum));
			
			return criteria.List<Protocol>();
        }
		
		#endregion
    }
}