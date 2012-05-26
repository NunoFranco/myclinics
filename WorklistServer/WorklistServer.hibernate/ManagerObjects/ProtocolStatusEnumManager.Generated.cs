using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolStatusEnumManager : IManagerBase<ProtocolStatusEnum, string>
    {
		// Get Methods
    }

    partial class ProtocolStatusEnumManager : ManagerBase<ProtocolStatusEnum, string>, IProtocolStatusEnumManager
    {
		#region Constructors
		
		public ProtocolStatusEnumManager() : base()
        {
        }
        public ProtocolStatusEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}