using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureCheckInManager : IManagerBase<ProcedureCheckIn, System.Guid>
    {
	}
	
	partial class ProcedureCheckInManager : ManagerBase<ProcedureCheckIn, System.Guid>, IProcedureCheckInManager
    {
	}
}