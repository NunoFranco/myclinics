using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileEmailAddressManager : IManagerBase<PatientProfileEmailAddress, System.Guid>
    {
	}
	
	partial class PatientProfileEmailAddressManager : ManagerBase<PatientProfileEmailAddress, System.Guid>, IPatientProfileEmailAddressManager
    {
	}
}