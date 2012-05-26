using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IModalityManager : IManagerBase<Modality, System.Guid>
    {
		// Get Methods
		Modality GetById_(System.String id);
		Modality GetByName_(System.String name);
    }

    partial class ModalityManager : ManagerBase<Modality, System.Guid>, IModalityManager
    {
		#region Constructors
		
		public ModalityManager() : base()
        {
        }
        public ModalityManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public Modality GetById_(System.String id)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Modality));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Id", id));
			
			IList<Modality> result = criteria.List<Modality>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		public Modality GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Modality));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<Modality> result = criteria.List<Modality>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}