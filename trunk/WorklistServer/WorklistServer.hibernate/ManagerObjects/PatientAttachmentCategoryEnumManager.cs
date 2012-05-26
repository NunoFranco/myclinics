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
	}
	
	partial class PatientAttachmentCategoryEnumManager : ManagerBase<PatientAttachmentCategoryEnum, string>, IPatientAttachmentCategoryEnumManager
    {
	}
}