using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientClassEnumManager : IManagerBase<PatientClassEnum, string>
    {
		// Get Methods
    }

    partial class PatientClassEnumManager : ManagerBase<PatientClassEnum, string>, IPatientClassEnumManager
    {
		#region Constructors
		
		public PatientClassEnumManager() : base()
        {
        }
        public PatientClassEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}