using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IExternalPractitionerExtendedPropertyManager : IManagerBase<ExternalPractitionerExtendedProperty, string>
    {
		// Get Methods
		ExternalPractitionerExtendedProperty GetById(System.Guid externalPractitionerOID, System.String name);
		IList<ExternalPractitionerExtendedProperty> GetByExternalPractitionerOID_(System.Guid externalPractitionerOID);
    }

    partial class ExternalPractitionerExtendedPropertyManager : ManagerBase<ExternalPractitionerExtendedProperty, string>, IExternalPractitionerExtendedPropertyManager
    {
		#region Constructors
		
		public ExternalPractitionerExtendedPropertyManager() : base()
        {
        }
        public ExternalPractitionerExtendedPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override ExternalPractitionerExtendedProperty GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for ExternalPractitionerExtendedPropertyManager.GetById");
			
			return GetById(new System.Guid(keys[0]), keys[1]);
		}
		public ExternalPractitionerExtendedProperty GetById(System.Guid externalPractitionerOID, System.String name)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerExtendedProperty));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ExternalPractitionerOID_", externalPractitionerOID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name_", name));
			
			ExternalPractitionerExtendedProperty result = (ExternalPractitionerExtendedProperty)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<ExternalPractitionerExtendedProperty> GetByExternalPractitionerOID_(System.Guid externalPractitionerOID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ExternalPractitionerExtendedProperty));
			
			
			ICriteria externalPractitionerOIDCriteria = criteria.CreateCriteria("ExternalPractitionerOID");
            externalPractitionerOIDCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", externalPractitionerOID));
			
			return criteria.List<ExternalPractitionerExtendedProperty>();
        }
		
		#endregion
    }
}