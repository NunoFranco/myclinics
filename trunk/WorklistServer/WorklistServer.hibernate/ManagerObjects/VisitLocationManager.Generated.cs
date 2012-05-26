using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitLocationManager : IManagerBase<VisitLocation, System.Guid>
    {
		// Get Methods
		IList<VisitLocation> GetByLocationOID_(System.Guid location);
		IList<VisitLocation> GetByRole_(System.String visitLocationRoleEnum);
		IList<VisitLocation> GetByVisitOID_(System.Guid visit);
    }

    partial class VisitLocationManager : ManagerBase<VisitLocation, System.Guid>, IVisitLocationManager
    {
		#region Constructors
		
		public VisitLocationManager() : base()
        {
        }
        public VisitLocationManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<VisitLocation> GetByLocationOID_(System.Guid location)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitLocation));
			
			
			ICriteria locationCriteria = criteria.CreateCriteria("Location");
            locationCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", location));
			
			return criteria.List<VisitLocation>();
        }
		
		public IList<VisitLocation> GetByRole_(System.String visitLocationRoleEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitLocation));
			
			
			ICriteria visitLocationRoleEnumCriteria = criteria.CreateCriteria("VisitLocationRoleEnum");
            visitLocationRoleEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", visitLocationRoleEnum));
			
			return criteria.List<VisitLocation>();
        }
		
		public IList<VisitLocation> GetByVisitOID_(System.Guid visit)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitLocation));
			
			
			ICriteria visitCriteria = criteria.CreateCriteria("Visit");
            visitCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", visit));
			
			return criteria.List<VisitLocation>();
        }
		
		#endregion
    }
}