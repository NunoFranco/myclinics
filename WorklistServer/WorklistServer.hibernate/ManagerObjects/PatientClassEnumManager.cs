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
	}
	
	partial class PatientClassEnumManager : ManagerBase<PatientClassEnum, string>, IPatientClassEnumManager
    {
	}
}