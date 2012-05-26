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
		// Get Methods
    }

    partial class ProtocolUrgencyEnumManager : ManagerBase<ProtocolUrgencyEnum, string>, IProtocolUrgencyEnumManager
    {
		#region Constructors
		
		public ProtocolUrgencyEnumManager() : base()
        {
        }
        public ProtocolUrgencyEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}