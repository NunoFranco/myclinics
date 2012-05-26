using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IOrderResultRecipientManager : IManagerBase<OrderResultRecipient, System.Guid>
    {
		// Get Methods
		IList<OrderResultRecipient> GetByOrderOID_(System.Guid order);
		IList<OrderResultRecipient> GetByPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint);
		IList<OrderResultRecipient> GetByPreferredCommunicationMode_(System.String resultCommunicationModeEnum);
    }

    partial class OrderResultRecipientManager : ManagerBase<OrderResultRecipient, System.Guid>, IOrderResultRecipientManager
    {
		#region Constructors
		
		public OrderResultRecipientManager() : base()
        {
        }
        public OrderResultRecipientManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<OrderResultRecipient> GetByOrderOID_(System.Guid order)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderResultRecipient));
			
			
			ICriteria orderCriteria = criteria.CreateCriteria("Order");
            orderCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", order));
			
			return criteria.List<OrderResultRecipient>();
        }
		
		public IList<OrderResultRecipient> GetByPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderResultRecipient));
			
			
			ICriteria externalPractitionerContactPointCriteria = criteria.CreateCriteria("ExternalPractitionerContactPoint");
            externalPractitionerContactPointCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitionerContactPoint));
			
			return criteria.List<OrderResultRecipient>();
        }
		
		public IList<OrderResultRecipient> GetByPreferredCommunicationMode_(System.String resultCommunicationModeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(OrderResultRecipient));
			
			
			ICriteria resultCommunicationModeEnumCriteria = criteria.CreateCriteria("ResultCommunicationModeEnum");
            resultCommunicationModeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", resultCommunicationModeEnum));
			
			return criteria.List<OrderResultRecipient>();
        }
		
		#endregion
    }
}