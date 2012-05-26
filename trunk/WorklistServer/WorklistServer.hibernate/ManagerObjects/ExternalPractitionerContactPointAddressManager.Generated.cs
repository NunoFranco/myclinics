using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointAddressManager : IManagerBase<ExternalPractitionerContactPointAddress, System.Guid>
    {
		// Get Methods
		IList<ExternalPractitionerContactPointAddress> GetByExternalPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint);
		IList<ExternalPractitionerContactPointAddress> GetByType_(System.String addressTypeEnum);
    }

    partial class ExternalPractitionerContactPointAddressManager : ManagerBase<ExternalPractitionerContactPointAddress, System.Guid>, IExternalPractitionerContactPointAddressManager
    {
		#region Constructors
		
		public ExternalPractitionerContactPointAddressManager() : base()
        {
        }
        public ExternalPractitionerContactPointAddressManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ExternalPractitionerContactPointAddress> GetByExternalPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPointAddress));
			
			
			ICriteria externalPractitionerContactPointCriteria = criteria.CreateCriteria("ExternalPractitionerContactPoint");
            externalPractitionerContactPointCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitionerContactPoint));
			
			return criteria.List<ExternalPractitionerContactPointAddress>();
        }
		
		public IList<ExternalPractitionerContactPointAddress> GetByType_(System.String addressTypeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPointAddress));
			
			
			ICriteria addressTypeEnumCriteria = criteria.CreateCriteria("AddressTypeEnum");
            addressTypeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", addressTypeEnum));
			
			return criteria.List<ExternalPractitionerContactPointAddress>();
        }
		
		#endregion
    }
}