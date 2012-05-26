using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IFacilityManager : IManagerBase<Facility, System.Guid>
    {
		// Get Methods
		IList<Facility> GetByInformationAuthority_(System.String informationAuthorityEnum);
		Facility GetByCode_(System.String code);
		Facility GetByName_(System.String name);
    }

    partial class FacilityManager : ManagerBase<Facility, System.Guid>, IFacilityManager
    {
		#region Constructors
		
		public FacilityManager() : base()
        {
        }
        public FacilityManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<Facility> GetByInformationAuthority_(System.String informationAuthorityEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Facility));
			
			
			ICriteria informationAuthorityEnumCriteria = criteria.CreateCriteria("InformationAuthorityEnum");
            informationAuthorityEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", informationAuthorityEnum));
			
			return criteria.List<Facility>();
        }
		
		public Facility GetByCode_(System.String code)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Facility));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Code", code));
			
			IList<Facility> result = criteria.List<Facility>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		public Facility GetByName_(System.String name)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(Facility));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name", name));
			
			IList<Facility> result = criteria.List<Facility>();
			return (result.Count > 0) ? result[0] : null;
        }
		
		#endregion
    }
}