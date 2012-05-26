using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IVisitExtendedPropertyManager : IManagerBase<VisitExtendedProperty, string>
    {
	}
	
	partial class VisitExtendedPropertyManager : ManagerBase<VisitExtendedProperty, string>, IVisitExtendedPropertyManager
    {
	}
}