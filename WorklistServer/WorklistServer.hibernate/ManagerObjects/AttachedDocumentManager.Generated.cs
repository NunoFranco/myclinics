using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAttachedDocumentManager : IManagerBase<AttachedDocument, System.Guid>
    {
		// Get Methods
		IList<AttachedDocument> GetByCreationTime_(System.DateTime creationTime);
		IList<AttachedDocument> GetByReceivedTime_(System.DateTime receivedTime);
    }

    partial class AttachedDocumentManager : ManagerBase<AttachedDocument, System.Guid>, IAttachedDocumentManager
    {
		#region Constructors
		
		public AttachedDocumentManager() : base()
        {
        }
        public AttachedDocumentManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<AttachedDocument> GetByCreationTime_(System.DateTime creationTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(AttachedDocument));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("CreationTime", creationTime));
			
			return criteria.List<AttachedDocument>();
        }
		
		public IList<AttachedDocument> GetByReceivedTime_(System.DateTime receivedTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(AttachedDocument));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ReceivedTime", receivedTime));
			
			return criteria.List<AttachedDocument>();
        }
		
		#endregion
    }
}