using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAttachedDocumentManager : IManagerBase<AttachedDocument, System.Guid>
    {
	}
	
	partial class AttachedDocumentManager : ManagerBase<AttachedDocument, System.Guid>, IAttachedDocumentManager
    {
	}
}