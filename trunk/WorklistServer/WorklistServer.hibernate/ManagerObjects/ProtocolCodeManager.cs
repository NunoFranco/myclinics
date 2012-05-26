using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolCodeManager : IManagerBase<ProtocolCode, System.Guid>
    {
	}
	
	partial class ProtocolCodeManager : ManagerBase<ProtocolCode, System.Guid>, IProtocolCodeManager
    {
	}
}