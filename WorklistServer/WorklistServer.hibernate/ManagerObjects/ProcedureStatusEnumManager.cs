using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureStatusEnumManager : IManagerBase<ProcedureStatusEnum, string>
    {
	}
	
	partial class ProcedureStatusEnumManager : ManagerBase<ProcedureStatusEnum, string>, IProcedureStatusEnumManager
    {
	}
}