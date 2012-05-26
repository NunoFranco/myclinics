using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerContactPointTelephoneNumberManager : IManagerBase<ExternalPractitionerContactPointTelephoneNumber, System.Guid>
    {
		// Get Methods
		IList<ExternalPractitionerContactPointTelephoneNumber> GetByEquipment_(System.String telephoneEquipmentEnum);
		IList<ExternalPractitionerContactPointTelephoneNumber> GetByExternalPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint);
		IList<ExternalPractitionerContactPointTelephoneNumber> GetByUse_(System.String telephoneUseEnum);
    }

    partial class ExternalPractitionerContactPointTelephoneNumberManager : ManagerBase<ExternalPractitionerContactPointTelephoneNumber, System.Guid>, IExternalPractitionerContactPointTelephoneNumberManager
    {
		#region Constructors
		
		public ExternalPractitionerContactPointTelephoneNumberManager() : base()
        {
        }
        public ExternalPractitionerContactPointTelephoneNumberManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ExternalPractitionerContactPointTelephoneNumber> GetByEquipment_(System.String telephoneEquipmentEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPointTelephoneNumber));
			
			
			ICriteria telephoneEquipmentEnumCriteria = criteria.CreateCriteria("TelephoneEquipmentEnum");
            telephoneEquipmentEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", telephoneEquipmentEnum));
			
			return criteria.List<ExternalPractitionerContactPointTelephoneNumber>();
        }
		
		public IList<ExternalPractitionerContactPointTelephoneNumber> GetByExternalPractitionerContactPointOID_(System.Guid externalPractitionerContactPoint)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPointTelephoneNumber));
			
			
			ICriteria externalPractitionerContactPointCriteria = criteria.CreateCriteria("ExternalPractitionerContactPoint");
            externalPractitionerContactPointCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitionerContactPoint));
			
			return criteria.List<ExternalPractitionerContactPointTelephoneNumber>();
        }
		
		public IList<ExternalPractitionerContactPointTelephoneNumber> GetByUse_(System.String telephoneUseEnum)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerContactPointTelephoneNumber));
			
			
			ICriteria telephoneUseEnumCriteria = criteria.CreateCriteria("TelephoneUseEnum");
            telephoneUseEnumCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", telephoneUseEnum));
			
			return criteria.List<ExternalPractitionerContactPointTelephoneNumber>();
        }
		
		#endregion
    }
}