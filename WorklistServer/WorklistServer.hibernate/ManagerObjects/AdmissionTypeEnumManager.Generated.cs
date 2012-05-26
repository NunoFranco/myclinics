using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAdmissionTypeEnumManager : IManagerBase<AdmissionTypeEnum, string>
    {
		// Get Methods
    }

    partial class AdmissionTypeEnumManager : ManagerBase<AdmissionTypeEnum, string>, IAdmissionTypeEnumManager
    {
		#region Constructors
		
		public AdmissionTypeEnumManager() : base()
        {
        }
        public AdmissionTypeEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}