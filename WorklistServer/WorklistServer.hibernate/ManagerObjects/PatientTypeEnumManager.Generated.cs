using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientTypeEnumManager : IManagerBase<PatientTypeEnum, string>
    {
		// Get Methods
    }

    partial class PatientTypeEnumManager : ManagerBase<PatientTypeEnum, string>, IPatientTypeEnumManager
    {
		#region Constructors
		
		public PatientTypeEnumManager() : base()
        {
        }
        public PatientTypeEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}