// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="DicomSeries"/> class.
    /// </summary>
	public partial class DicomSeriesSearchCriteria : EntitySearchCriteria<DicomSeries>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public DicomSeriesSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public DicomSeriesSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected DicomSeriesSearchCriteria(DicomSeriesSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new DicomSeriesSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.ModalityPerformedProcedureStepSearchCriteria ModalityPerformedProcedureStep
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ModalityPerformedProcedureStep"))
	  			{
	  				this.SubCriteria["ModalityPerformedProcedureStep"] = new ClearCanvas.Healthcare.ModalityPerformedProcedureStepSearchCriteria("ModalityPerformedProcedureStep");
	  			}
	  			return (ClearCanvas.Healthcare.ModalityPerformedProcedureStepSearchCriteria)this.SubCriteria["ModalityPerformedProcedureStep"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> StudyInstanceUID
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("StudyInstanceUID"))
	  			{
	  				this.SubCriteria["StudyInstanceUID"] = new SearchCondition<string>("StudyInstanceUID");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["StudyInstanceUID"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> SeriesInstanceUID
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SeriesInstanceUID"))
	  			{
	  				this.SubCriteria["SeriesInstanceUID"] = new SearchCondition<string>("SeriesInstanceUID");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["SeriesInstanceUID"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> SeriesDescription
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SeriesDescription"))
	  			{
	  				this.SubCriteria["SeriesDescription"] = new SearchCondition<string>("SeriesDescription");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["SeriesDescription"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> SeriesNumber
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("SeriesNumber"))
	  			{
	  				this.SubCriteria["SeriesNumber"] = new SearchCondition<string>("SeriesNumber");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["SeriesNumber"];
	  		}
	  	}
	  	
	  	public ISearchCondition<int> NumberOfSeriesRelatedInstances
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("NumberOfSeriesRelatedInstances"))
	  			{
	  				this.SubCriteria["NumberOfSeriesRelatedInstances"] = new SearchCondition<int>("NumberOfSeriesRelatedInstances");
	  			}
	  			return (ISearchCondition<int>)this.SubCriteria["NumberOfSeriesRelatedInstances"];
	  		}
	  	}
	  	
	}
}
