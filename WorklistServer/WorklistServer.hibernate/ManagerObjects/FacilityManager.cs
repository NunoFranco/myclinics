using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IFacilityManager : IManagerBase<Facility, System.Guid>
    {
	}
	
	partial class FacilityManager : ManagerBase<Facility, System.Guid>, IFacilityManager
    {
	}
}