using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAdmissionTypeEnumManager : IManagerBase<AdmissionTypeEnum, string>
    {
	}
	
	partial class AdmissionTypeEnumManager : ManagerBase<AdmissionTypeEnum, string>, IAdmissionTypeEnumManager
    {
	}
}