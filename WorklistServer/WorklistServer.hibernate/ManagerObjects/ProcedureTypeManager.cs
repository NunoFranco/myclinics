using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureTypeManager : IManagerBase<ProcedureType, System.Guid>
    {
	}
	
	partial class ProcedureTypeManager : ManagerBase<ProcedureType, System.Guid>, IProcedureTypeManager
    {
	}
}