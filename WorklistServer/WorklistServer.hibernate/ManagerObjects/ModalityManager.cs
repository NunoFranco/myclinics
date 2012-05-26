using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IModalityManager : IManagerBase<Modality, System.Guid>
    {
	}
	
	partial class ModalityManager : ManagerBase<Modality, System.Guid>, IModalityManager
    {
	}
}