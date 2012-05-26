using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientTypeEnumManager : IManagerBase<PatientTypeEnum, string>
    {
	}
	
	partial class PatientTypeEnumManager : ManagerBase<PatientTypeEnum, string>, IPatientTypeEnumManager
    {
	}
}