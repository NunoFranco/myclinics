using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerManager : IManagerBase<ExternalPractitioner, System.Guid>
    {
		// Get Methods
		IList<ExternalPractitioner> GetByFamilyName_(System.String familyName);
		IList<ExternalPractitioner> GetByGivenName_(System.String givenName);
    }

    partial class ExternalPractitionerManager : ManagerBase<ExternalPractitioner, System.Guid>, IExternalPractitionerManager
    {
		#region Constructors
		
		public ExternalPractitionerManager() : base()
        {
        }
        public ExternalPractitionerManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ExternalPractitioner> GetByFamilyName_(System.String familyName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitioner));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("FamilyName", familyName));
			
			return criteria.List<ExternalPractitioner>();
        }
		
		public IList<ExternalPractitioner> GetByGivenName_(System.String givenName)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitioner));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("GivenName", givenName));
			
			return criteria.List<ExternalPractitioner>();
        }
		
		#endregion
    }
}