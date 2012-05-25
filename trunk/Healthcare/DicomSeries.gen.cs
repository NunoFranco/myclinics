// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using Iesi.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{


    /// <summary>
    /// DicomSeries entity
    /// </summary>
	
	public partial class DicomSeries : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.ModalityPerformedProcedureStep _modalityPerformedProcedureStep;
	  	
	  	private string _studyInstanceUID;
	  	
	  	private string _seriesInstanceUID;
	  	
	  	private string _seriesDescription;
	  	
	  	private string _seriesNumber;
	  	
	  	private int _numberOfSeriesRelatedInstances;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public DicomSeries()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public DicomSeries(ClearCanvas.Healthcare.ModalityPerformedProcedureStep modalityperformedprocedurestep1, string studyinstanceuid1, string seriesinstanceuid1, string seriesdescription1, string seriesnumber1, int numberofseriesrelatedinstances1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_modalityPerformedProcedureStep = modalityperformedprocedurestep1;
		  	
		  	_studyInstanceUID = studyinstanceuid1;
		  	
		  	_seriesInstanceUID = seriesinstanceuid1;
		  	
		  	_seriesDescription = seriesdescription1;
		  	
		  	_seriesNumber = seriesnumber1;
		  	
		  	_numberOfSeriesRelatedInstances = numberofseriesrelatedinstances1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ModalityPerformedProcedureStep ModalityPerformedProcedureStep
	  	{
			
			get { return _modalityPerformedProcedureStep; }
			
			
			 set { _modalityPerformedProcedureStep = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string StudyInstanceUID
	  	{
			
			get { return _studyInstanceUID; }
			
			
			 set { _studyInstanceUID = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string SeriesInstanceUID
	  	{
			
			get { return _seriesInstanceUID; }
			
			
			 set { _seriesInstanceUID = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string SeriesDescription
	  	{
			
			get { return _seriesDescription; }
			
			
			 set { _seriesDescription = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string SeriesNumber
	  	{
			
			get { return _seriesNumber; }
			
			
			 set { _seriesNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual int NumberOfSeriesRelatedInstances
	  	{
			
			get { return _numberOfSeriesRelatedInstances; }
			
			
			 set { _numberOfSeriesRelatedInstances = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
