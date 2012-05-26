using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileTelephoneNumberManager : IManagerBase<PatientProfileTelephoneNumber, System.Guid>
    {
	}
	
	partial class PatientProfileTelephoneNumberManager : ManagerBase<PatientProfileTelephoneNumber, System.Guid>, IPatientProfileTelephoneNumberManager
    {
	}
}