using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IDiagnosticServiceManager : IManagerBase<DiagnosticService, System.Guid>
    {
		// Get Methods
		DiagnosticService GetById_(System.String id);
		DiagnosticService GetByName_(System.String name);
    }

    partial class DiagnosticServiceManager : ManagerBase<DiagnosticService, System.Guid>, IDiagnosticServiceManager
    {
		#region Constructors
		
		public DiagnosticServiceManager() : base()
        {
        }
        public DiagnosticServiceManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public DiagnosticService GetById_(System.String id)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(DiagnosticService));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Id", id));
			
			IList<DiagnosticService> result = criteria.List<DiagnosticService>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		public DiagnosticService GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(DiagnosticService));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<DiagnosticService> result = criteria.List<DiagnosticService>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}