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
	}
	
	partial class DicomSeriesManager : ManagerBase<DicomSeries, System.Guid>, IDicomSeriesManager
    {
	}
}