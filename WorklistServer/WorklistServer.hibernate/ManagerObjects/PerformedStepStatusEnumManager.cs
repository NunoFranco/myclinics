using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPerformedStepStatusEnumManager : IManagerBase<PerformedStepStatusEnum, string>
    {
	}
	
	partial class PerformedStepStatusEnumManager : ManagerBase<PerformedStepStatusEnum, string>, IPerformedStepStatusEnumManager
    {
	}
}