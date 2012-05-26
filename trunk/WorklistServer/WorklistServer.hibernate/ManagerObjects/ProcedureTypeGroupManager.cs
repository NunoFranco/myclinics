using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureTypeGroupManager : IManagerBase<ProcedureTypeGroup, System.Guid>
    {
	}
	
	partial class ProcedureTypeGroupManager : ManagerBase<ProcedureTypeGroup, System.Guid>, IProcedureTypeGroupManager
    {
	}
}