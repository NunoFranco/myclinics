using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitLocationManager : IManagerBase<VisitLocation, System.Guid>
    {
	}
	
	partial class VisitLocationManager : ManagerBase<VisitLocation, System.Guid>, IVisitLocationManager
    {
	}
}