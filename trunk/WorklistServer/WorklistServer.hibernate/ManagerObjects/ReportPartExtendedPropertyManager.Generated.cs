using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IReportPartExtendedPropertyManager : IManagerBase<ReportPartExtendedProperty, string>
    {
		// Get Methods
		ReportPartExtendedProperty GetById(System.Guid reportPartOID, System.String name);
		IList<ReportPartExtendedProperty> GetByReportPartOID_(System.Guid reportPartOID);
    }

    partial class ReportPartExtendedPropertyManager : ManagerBase<ReportPartExtendedProperty, string>, IReportPartExtendedPropertyManager
    {
		#region Constructors
		
		public ReportPartExtendedPropertyManager() : base()
        {
        }
        public ReportPartExtendedPropertyManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		public override ReportPartExtendedProperty GetById(string id)
		{
			string[] keys = id.Split('^');
			
			if(keys.Length != 2)
				throw new Exception("Invalid Id for ReportPartExtendedPropertyManager.GetById");
			
			return GetById(new System.Guid(keys[0]), keys[1]);
		}
		public ReportPartExtendedProperty GetById(System.Guid reportPartOID, System.String name)
		{
			ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPartExtendedProperty));
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("ReportPartOID_", reportPartOID));
			criteria.Add(NHibernate.Criterion.Expression.Eq("Name_", name));
			
			ReportPartExtendedProperty result = (ReportPartExtendedProperty)criteria.UniqueResult();

            if (result == null)
                throw new NHibernate.ObjectDeletedException("", null, null);

            return result;
		}
		
		
		public IList<ReportPartExtendedProperty> GetByReportPartOID_(System.Guid reportPartOID)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ReportPartExtendedProperty));
			
			
			ICriteria reportPartOIDCriteria = criteria.CreateCriteria("ReportPartOID");
            reportPartOIDCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", reportPartOID));
			
			return criteria.List<ReportPartExtendedProperty>();
        }
		
		#endregion
    }
}