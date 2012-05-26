using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ITestManager : IManagerBase<Test, System.Guid>
    {
	}
	
	partial class TestManager : ManagerBase<Test, System.Guid>, ITestManager
    {
	}
}