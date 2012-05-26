using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolManager : IManagerBase<Protocol, System.Guid>
    {
	}
	
	partial class ProtocolManager : ManagerBase<Protocol, System.Guid>, IProtocolManager
    {
	}
}