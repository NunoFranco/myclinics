using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface INoteSeverityEnumManager : IManagerBase<NoteSeverityEnum, string>
    {
	}
	
	partial class NoteSeverityEnumManager : ManagerBase<NoteSeverityEnum, string>, INoteSeverityEnumManager
    {
	}
}