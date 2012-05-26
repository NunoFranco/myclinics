using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointManager : IManagerBase<ExternalPractitionerContactPoint, System.Guid>
    {
		// Get Methods
		IList<ExternalPractitionerContactPoint> GetByPractitionerOID_(System.Guid externalPractitioner);
		IList<ExternalPractitionerContactPoint> GetByPreferredResultCommunicationMode_(System.String resultCommunicationModeEnum);
    }

    partial class ExternalPractitionerContactPointManager : ManagerBase<ExternalPractitionerContactPoint, System.Guid>, IExternalPractitionerContactPointManager
    {
		#region Constructors
		
		public ExternalPractitionerContactPointManager() : base()
        {
        }
        public ExternalPractitionerContactPointManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ExternalPractitionerContactPoint> GetByPractitionerOID_(System.Guid externalPractitioner)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPoint));
			
			
			ICriteria externalPractitionerCriteria = criteria.CreateCriteria("ExternalPractitioner");
            externalPractitionerCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitioner));
			
			return criteria.List<ExternalPractitionerContactPoint>();
        }
		
		public IList<ExternalPractitionerContactPoint> GetByPreferredResultCommunicationMode_(System.String resultCommunicationModeEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPoint));
			
			
			ICriteria resultCommunicationModeEnumCriteria = criteria.CreateCriteria("ResultCommunicationModeEnum");
            resultCommunicationModeEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", resultCommunicationModeEnum));
			
			return criteria.List<ExternalPractitionerContactPoint>();
        }
		
		#endregion
    }
}