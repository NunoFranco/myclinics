using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IResultCommunicationModeEnumManager : IManagerBase<ResultCommunicationModeEnum, string>
    {
		// Get Methods
    }

    partial class ResultCommunicationModeEnumManager : ManagerBase<ResultCommunicationModeEnum, string>, IResultCommunicationModeEnumManager
    {
		#region Constructors
		
		public ResultCommunicationModeEnumManager() : base()
        {
        }
        public ResultCommunicationModeEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}