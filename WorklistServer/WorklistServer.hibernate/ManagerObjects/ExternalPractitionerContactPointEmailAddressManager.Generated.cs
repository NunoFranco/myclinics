using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointEmailAddressManager : IManagerBase<ExternalPractitionerContactPointEmailAddress, System.Guid>
    {
		// Get Methods
		IList<ExternalPractitionerContactPointEmailAddress> GetByExternalPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint);
    }

    partial class ExternalPractitionerContactPointEmailAddressManager : ManagerBase<ExternalPractitionerContactPointEmailAddress, System.Guid>, IExternalPractitionerContactPointEmailAddressManager
    {
		#region Constructors
		
		public ExternalPractitionerContactPointEmailAddressManager() : base()
        {
        }
        public ExternalPractitionerContactPointEmailAddressManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ExternalPractitionerContactPointEmailAddress> GetByExternalPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPointEmailAddress));
			
			
			ICriteria externalPractitionerContactPointCriteria = criteria.CreateCriteria("ExternalPractitionerContactPoint");
            externalPractitionerContactPointCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitionerContactPoint));
			
			return criteria.List<ExternalPractitionerContactPointEmailAddress>();
        }
		
		#endregion
    }
}