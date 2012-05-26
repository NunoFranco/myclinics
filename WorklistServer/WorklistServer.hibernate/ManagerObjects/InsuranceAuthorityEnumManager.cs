using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IInsuranceAuthorityEnumManager : IManagerBase<InsuranceAuthorityEnum, string>
    {
	}
	
	partial class InsuranceAuthorityEnumManager : ManagerBase<InsuranceAuthorityEnum, string>, IInsuranceAuthorityEnumManager
    {
	}
}