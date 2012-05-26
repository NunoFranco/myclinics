using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ILateralityEnumManager : IManagerBase<LateralityEnum, string>
    {
	}
	
	partial class LateralityEnumManager : ManagerBase<LateralityEnum, string>, ILateralityEnumManager
    {
	}
}