using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientManager : IManagerBase<Patient, System.Guid>
    {
	}
	
	partial class PatientManager : ManagerBase<Patient, System.Guid>, IPatientManager
    {
	}
}