using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureStepManager : IManagerBase<ProcedureStep, System.Guid>
    {
	}
	
	partial class ProcedureStepManager : ManagerBase<ProcedureStep, System.Guid>, IProcedureStepManager
    {
	}
}