using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IInformationAuthorityEnumManager : IManagerBase<InformationAuthorityEnum, string>
    {
	}
	
	partial class InformationAuthorityEnumManager : ManagerBase<InformationAuthorityEnum, string>, IInformationAuthorityEnumManager
    {
	}
}