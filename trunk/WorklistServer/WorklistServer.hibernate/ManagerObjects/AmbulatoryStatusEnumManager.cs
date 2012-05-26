using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAmbulatoryStatusEnumManager : IManagerBase<AmbulatoryStatusEnum, string>
    {
	}
	
	partial class AmbulatoryStatusEnumManager : ManagerBase<AmbulatoryStatusEnum, string>, IAmbulatoryStatusEnumManager
    {
	}
}