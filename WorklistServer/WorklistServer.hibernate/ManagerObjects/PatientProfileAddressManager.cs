using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientProfileAddressManager : IManagerBase<PatientProfileAddress, System.Guid>
    {
	}
	
	partial class PatientProfileAddressManager : ManagerBase<PatientProfileAddress, System.Guid>, IPatientProfileAddressManager
    {
	}
}