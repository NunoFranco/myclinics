using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ILocationManager : IManagerBase<Location, System.Guid>
    {
	}
	
	partial class LocationManager : ManagerBase<Location, System.Guid>, ILocationManager
    {
	}
}