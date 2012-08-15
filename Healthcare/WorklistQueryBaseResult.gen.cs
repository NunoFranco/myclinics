// This file is machine generated - changes will be lost.
using System;
using System.Collections;
using System.Text;

using Iesi.Collections;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Core;


namespace ClearCanvas.Healthcare
{


    /// <summary>
    /// WorklistQueryBaseResult query result container
    /// </summary>
	public partial class WorklistQueryBaseResult : System.Object
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Patient _patient;
	  	
	  	private ClearCanvas.Healthcare.PatientProfile _patientProfile;
	  	
	  	private ClearCanvas.Healthcare.Order _order;
	  	
	  	private ClearCanvas.Healthcare.Procedure _procedure;
	  	
	  	private ClearCanvas.Healthcare.PersonName _patientName;
	  	
	  	private ClearCanvas.Healthcare.PatientIdentifier _patientMrn;
	  	
	  	private string _accessionNumber;
	  	
	  	private string _procedureName;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor
	  	/// </summary>
	  	public WorklistQueryBaseResult()
	  	{
	  	}
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
	  	public ClearCanvas.Healthcare.Patient Patient
	  	{
			get { return _patient; }
			set { _patient = value; }
	  	}
	  	
	  	public ClearCanvas.Healthcare.PatientProfile PatientProfile
	  	{
			get { return _patientProfile; }
			set { _patientProfile = value; }
	  	}
	  	
	  	public ClearCanvas.Healthcare.Order Order
	  	{
			get { return _order; }
			set { _order = value; }
	  	}
	  	
	  	public ClearCanvas.Healthcare.Procedure Procedure
	  	{
			get { return _procedure; }
			set { _procedure = value; }
	  	}
	  	
	  	public ClearCanvas.Healthcare.PersonName PatientName
	  	{
			get { return _patientName; }
			set { _patientName = value; }
	  	}
	  	
	  	public ClearCanvas.Healthcare.PatientIdentifier PatientMrn
	  	{
			get { return _patientMrn; }
			set { _patientMrn = value; }
	  	}
	  	
	  	public string AccessionNumber
	  	{
			get { return _accessionNumber; }
			set { _accessionNumber = value; }
	  	}
	  	
	  	public string ProcedureName
	  	{
			get { return _procedureName; }
			set { _procedureName = value; }
	  	}
	  	
	  	
	  	#endregion
	}
}
