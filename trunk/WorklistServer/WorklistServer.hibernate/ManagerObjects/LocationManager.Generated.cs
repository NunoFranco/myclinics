using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ILocationManager : IManagerBase<Location, System.Guid>
    {
		// Get Methods
		IList<Location> GetByFacilityOID_(System.Guid facility);
		Location GetById_(System.String id);
		Location GetByName_(System.String name);
    }

    partial class LocationManager : ManagerBase<Location, System.Guid>, ILocationManager
    {
		#region Constructors
		
		public LocationManager() : base()
        {
        }
        public LocationManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Location> GetByFacilityOID_(System.Guid facility)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Location));
			
			
			ICriteria facilityCriteria = criteria.CreateCriteria("Facility");
            facilityCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", facility));
			
			return criteria.List<Location>();
        }
		
		public Location GetById_(System.String id)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Location));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Id", id));
			
			IList<Location> result = criteria.List<Location>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		public Location GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Location));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<Location> result = criteria.List<Location>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}