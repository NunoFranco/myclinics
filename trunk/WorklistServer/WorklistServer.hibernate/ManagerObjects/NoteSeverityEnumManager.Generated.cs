using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface INoteSeverityEnumManager : IManagerBase<NoteSeverityEnum, string>
    {
		// Get Methods
    }

    partial class NoteSeverityEnumManager : ManagerBase<NoteSeverityEnum, string>, INoteSeverityEnumManager
    {
		#region Constructors
		
		public NoteSeverityEnumManager() : base()
        {
        }
        public NoteSeverityEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}