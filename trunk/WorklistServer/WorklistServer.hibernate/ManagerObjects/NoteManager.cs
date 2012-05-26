using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface INoteManager : IManagerBase<Note, System.Guid>
    {
	}
	
	partial class NoteManager : ManagerBase<Note, System.Guid>, INoteManager
    {
	}
}