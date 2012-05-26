using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileManager : IManagerBase<PatientProfile, System.Guid>
    {
	}
	
	partial class PatientProfileManager : ManagerBase<PatientProfile, System.Guid>, IPatientProfileManager
    {
	}
}