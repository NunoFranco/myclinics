using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPerformedProcedureStepManager : IManagerBase<PerformedProcedureStep, System.Guid>
    {
	}
	
	partial class PerformedProcedureStepManager : ManagerBase<PerformedProcedureStep, System.Guid>, IPerformedProcedureStepManager
    {
	}
}