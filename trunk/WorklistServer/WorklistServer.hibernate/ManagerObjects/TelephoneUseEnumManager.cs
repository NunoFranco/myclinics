using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ITelephoneUseEnumManager : IManagerBase<TelephoneUseEnum, string>
    {
	}
	
	partial class TelephoneUseEnumManager : ManagerBase<TelephoneUseEnum, string>, ITelephoneUseEnumManager
    {
	}
}