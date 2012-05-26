using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPerformedProcedureStepExtendedPropertyManager : IManagerBase<PerformedProcedureStepExtendedProperty, string>
    {
	}
	
	partial class PerformedProcedureStepExtendedPropertyManager : ManagerBase<PerformedProcedureStepExtendedProperty, string>, IPerformedProcedureStepExtendedPropertyManager
    {
	}
}