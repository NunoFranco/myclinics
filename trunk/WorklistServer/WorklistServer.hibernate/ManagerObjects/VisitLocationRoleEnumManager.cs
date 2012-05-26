using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitLocationRoleEnumManager : IManagerBase<VisitLocationRoleEnum, string>
    {
	}
	
	partial class VisitLocationRoleEnumManager : ManagerBase<VisitLocationRoleEnum, string>, IVisitLocationRoleEnumManager
    {
	}
}