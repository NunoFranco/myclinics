using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IDicomSeriesManager : IManagerBase<DicomSeries, System.Guid>
    {
		// Get Methods
		IList<DicomSeries> GetByModalityPerformedProcedureStepOID_(System.Guid performedProcedureStep);
    }

    partial class DicomSeriesManager : ManagerBase<DicomSeries, System.Guid>, IDicomSeriesManager
    {
		#region Constructors
		
		public DicomSeriesManager() : base()
        {
        }
        public DicomSeriesManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		public IList<DicomSeries> GetByModalityPerformedProcedureStepOID_(System.Guid performedProcedureStep)
        {
            ICriteria criteria = Session.GetISession().CreateCriteria(typeof(DicomSeries));
			
			
			ICriteria performedProcedureStepCriteria = criteria.CreateCriteria("PerformedProcedureStep");
            performedProcedureStepCriteria.Add(NHibernate.Criterion.Expression.Eq("Id", performedProcedureStep));
			
			return criteria.List<DicomSeries>();
        }
		
		#endregion
    }
}