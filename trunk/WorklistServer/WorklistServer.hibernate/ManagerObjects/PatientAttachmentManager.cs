using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientAttachmentManager : IManagerBase<PatientAttachment, System.Guid>
    {
	}
	
	partial class PatientAttachmentManager : ManagerBase<PatientAttachment, System.Guid>, IPatientAttachmentManager
    {
	}
}