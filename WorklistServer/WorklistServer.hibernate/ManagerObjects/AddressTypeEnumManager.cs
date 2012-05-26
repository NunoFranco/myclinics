using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAddressTypeEnumManager : IManagerBase<AddressTypeEnum, string>
    {
	}
	
	partial class AddressTypeEnumManager : ManagerBase<AddressTypeEnum, string>, IAddressTypeEnumManager
    {
	}
}