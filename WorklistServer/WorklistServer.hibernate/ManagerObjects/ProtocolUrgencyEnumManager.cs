using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolUrgencyEnumManager : IManagerBase<ProtocolUrgencyEnum, string>
    {
	}
	
	partial class ProtocolUrgencyEnumManager : ManagerBase<ProtocolUrgencyEnum, string>, IProtocolUrgencyEnumManager
    {
	}
}