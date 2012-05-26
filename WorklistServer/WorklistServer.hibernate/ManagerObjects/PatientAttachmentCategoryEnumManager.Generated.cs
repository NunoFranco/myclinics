using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientAttachmentCategoryEnumManager : IManagerBase<PatientAttachmentCategoryEnum, string>
    {
		// Get Methods
    }

    partial class PatientAttachmentCategoryEnumManager : ManagerBase<PatientAttachmentCategoryEnum, string>, IPatientAttachmentCategoryEnumManager
    {
		#region Constructors
		
		public PatientAttachmentCategoryEnumManager() : base()
        {
        }
        public PatientAttachmentCategoryEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}