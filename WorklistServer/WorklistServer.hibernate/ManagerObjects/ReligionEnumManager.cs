using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IReligionEnumManager : IManagerBase<ReligionEnum, string>
    {
	}
	
	partial class ReligionEnumManager : ManagerBase<ReligionEnum, string>, IReligionEnumManager
    {
	}
}