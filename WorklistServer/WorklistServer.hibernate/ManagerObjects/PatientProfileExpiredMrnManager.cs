using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileExpiredMrnManager : IManagerBase<PatientProfileExpiredMrn, System.Guid>
    {
	}
	
	partial class PatientProfileExpiredMrnManager : ManagerBase<PatientProfileExpiredMrn, System.Guid>, IPatientProfileExpiredMrnManager
    {
	}
}