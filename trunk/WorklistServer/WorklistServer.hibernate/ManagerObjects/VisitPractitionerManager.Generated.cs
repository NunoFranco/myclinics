using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitPractitionerManager : IManagerBase<VisitPractitioner, System.Guid>
    {
		// Get Methods
		IList<VisitPractitioner> GetByPractitionerOID_(System.Guid externalPractitioner);
		IList<VisitPractitioner> GetByRole_(System.String visitPractitionerRoleEnum);
		IList<VisitPractitioner> GetByVisitOID_(System.Guid visit);
    }

    partial class VisitPractitionerManager : ManagerBase<VisitPractitioner, System.Guid>, IVisitPractitionerManager
    {
		#region Constructors
		
		public VisitPractitionerManager() : base()
        {
        }
        public VisitPractitionerManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<VisitPractitioner> GetByPractitionerOID_(System.Guid externalPractitioner)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitPractitioner));
			
			
			ICriteria externalPractitionerCriteria = criteria.CreateCriteria("ExternalPractitioner");
            externalPractitionerCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitioner));
			
			return criteria.List<VisitPractitioner>();
        }
		
		public IList<VisitPractitioner> GetByRole_(System.String visitPractitionerRoleEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitPractitioner));
			
			
			ICriteria visitPractitionerRoleEnumCriteria = criteria.CreateCriteria("VisitPractitionerRoleEnum");
            visitPractitionerRoleEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", visitPractitionerRoleEnum));
			
			return criteria.List<VisitPractitioner>();
        }
		
		public IList<VisitPractitioner> GetByVisitOID_(System.Guid visit)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitPractitioner));
			
			
			ICriteria visitCriteria = criteria.CreateCriteria("Visit");
            visitCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", visit));
			
			return criteria.List<VisitPractitioner>();
        }
		
		#endregion
    }
}