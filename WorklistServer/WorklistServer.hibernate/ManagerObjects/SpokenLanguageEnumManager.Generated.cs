using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ISpokenLanguageEnumManager : IManagerBase<SpokenLanguageEnum, string>
    {
		// Get Methods
    }

    partial class SpokenLanguageEnumManager : ManagerBase<SpokenLanguageEnum, string>, ISpokenLanguageEnumManager
    {
		#region Constructors
		
		public SpokenLanguageEnumManager() : base()
        {
        }
        public SpokenLanguageEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}