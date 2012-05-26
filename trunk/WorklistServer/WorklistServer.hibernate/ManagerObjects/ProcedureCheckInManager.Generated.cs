using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IProcedureCheckInManager : IManagerBase<ProcedureCheckIn, System.Guid>
    {
		// Get Methods
		IList<ProcedureCheckIn> GetByCheckInTime_(System.DateTime checkInTime);
		IList<ProcedureCheckIn> GetByCheckOutTime_(System.DateTime checkOutTime);
    }

    partial class ProcedureCheckInManager : ManagerBase<ProcedureCheckIn, System.Guid>, IProcedureCheckInManager
    {
		#region Constructors
		
		public ProcedureCheckInManager() : base()
        {
        }
        public ProcedureCheckInManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<ProcedureCheckIn> GetByCheckInTime_(System.DateTime checkInTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureCheckIn));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("CheckInTime", checkInTime));
			
			return criteria.List<ProcedureCheckIn>();
        }
		
		public IList<ProcedureCheckIn> GetByCheckOutTime_(System.DateTime checkOutTime)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(ProcedureCheckIn));
			
			
			criteria.Add(NHibernate.Criterion.Expression.Eq("CheckOutTime", checkOutTime));
			
			return criteria.List<ProcedureCheckIn>();
        }
		
		#endregion
    }
}