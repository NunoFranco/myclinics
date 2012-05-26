using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAccessionSequenceManager : IManagerBase<AccessionSequence, long>
    {
		// Get Methods
    }

    partial class AccessionSequenceManager : ManagerBase<AccessionSequence, long>, IAccessionSequenceManager
    {
		#region Constructors
		
		public AccessionSequenceManager() : base()
        {
        }
        public AccessionSequenceManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}