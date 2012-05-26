using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitPractitionerRoleEnumManager : IManagerBase<VisitPractitionerRoleEnum, string>
    {
	}
	
	partial class VisitPractitionerRoleEnumManager : ManagerBase<VisitPractitionerRoleEnum, string>, IVisitPractitionerRoleEnumManager
    {
	}
}