using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitExtendedPropertyManager : IManagerBase<VisitExtendedProperty, string>
    {
		// Get Methods
		VisitExtendedProperty GetById(System.Guid visitOID, System.String name);
		IList<VisitExtendedProperty> GetByVisitOID_(System.Guid visitOID);
    }

    partial class VisitExtendedPropertyManager : ManagerBase<VisitExtendedProperty, string>, IVisitExtendedPropertyManager
    {
		#region Constructors
		
		public VisitExtendedPropertyManager() : base()
        {
        }
        public VisitExtendedPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override VisitExtendedProperty GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for VisitExtendedPropertyManager.GetById");
			
			return GetById(new System.Guid(keys[0]), keys[1]);
		}
		public VisitExtendedProperty GetById(System.Guid visitOID, System.String name)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitExtendedProperty));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("VisitOID_", visitOID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name_", name));
			
			VisitExtendedProperty result = (VisitExtendedProperty)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<VisitExtendedProperty> GetByVisitOID_(System.Guid visitOID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(VisitExtendedProperty));
			
			
			ICriteria visitOIDCriteria = criteria.CreateCriteria("VisitOID");
            visitOIDCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", visitOID));
			
			return criteria.List<VisitExtendedProperty>();
        }
		
		#endregion
    }
}