using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProtocolRejectReasonEnumManager : IManagerBase<ProtocolRejectReasonEnum, string>
    {
		// Get Methods
    }

    partial class ProtocolRejectReasonEnumManager : ManagerBase<ProtocolRejectReasonEnum, string>, IProtocolRejectReasonEnumManager
    {
		#region Constructors
		
		public ProtocolRejectReasonEnumManager() : base()
        {
        }
        public ProtocolRejectReasonEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}