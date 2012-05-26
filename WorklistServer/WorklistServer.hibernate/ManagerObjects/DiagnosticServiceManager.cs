using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IDiagnosticServiceManager : IManagerBase<DiagnosticService, System.Guid>
    {
	}
	
	partial class DiagnosticServiceManager : ManagerBase<DiagnosticService, System.Guid>, IDiagnosticServiceManager
    {
	}
}