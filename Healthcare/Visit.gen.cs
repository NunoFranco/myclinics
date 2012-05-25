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
    /// Visit entity
    /// </summary>
	
	public partial class Visit : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Patient _patient;
	  	
	  	private ClearCanvas.Healthcare.VisitNumber _visitNumber;
	  	
	  	private ClearCanvas.Healthcare.VisitStatusEnum _status;
	  	
	  	private DateTime? _admitTime;
	  	
	  	private DateTime? _dischargeTime;
	  	
	  	private string _dischargeDisposition;
	  	
	  	private ClearCanvas.Healthcare.PatientClassEnum _patientClass;
	  	
	  	private ClearCanvas.Healthcare.PatientTypeEnum _patientType;
	  	
	  	private ClearCanvas.Healthcare.AdmissionTypeEnum _admissionType;
	  	
	  	private ClearCanvas.Healthcare.Facility _facility;
	  	
	  	private ClearCanvas.Healthcare.Location _currentLocation;
	  	
	  	private IList<ClearCanvas.Healthcare.VisitLocation> _locations;
	  	
	  	private IList<ClearCanvas.Healthcare.VisitPractitioner> _practitioners;
	  	
	  	private bool _vipIndicator;
	  	
	  	private string _preadmitNumber;
	  	
	  	private ISet<ClearCanvas.Healthcare.AmbulatoryStatusEnum> _ambulatoryStatuses;
	  	
	  	private IDictionary<string, string> _extendedProperties;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Visit()
	  	{
		 	
		  	_visitNumber = new ClearCanvas.Healthcare.VisitNumber();
		  	
		  	_locations = new List<ClearCanvas.Healthcare.VisitLocation>();
		  	
		  	_practitioners = new List<ClearCanvas.Healthcare.VisitPractitioner>();
		  	
		  	_ambulatoryStatuses = new HashedSet<ClearCanvas.Healthcare.AmbulatoryStatusEnum>();
		  	
		  	_extendedProperties = new Dictionary<string, string>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Visit(ClearCanvas.Healthcare.Patient patient1, ClearCanvas.Healthcare.VisitNumber visitnumber1, ClearCanvas.Healthcare.VisitStatusEnum status1, DateTime? admittime1, DateTime? dischargetime1, string dischargedisposition1, ClearCanvas.Healthcare.PatientClassEnum patientclass1, ClearCanvas.Healthcare.PatientTypeEnum patienttype1, ClearCanvas.Healthcare.AdmissionTypeEnum admissiontype1, ClearCanvas.Healthcare.Facility facility1, ClearCanvas.Healthcare.Location currentlocation1, IList<ClearCanvas.Healthcare.VisitLocation> locations1, IList<ClearCanvas.Healthcare.VisitPractitioner> practitioners1, bool vipindicator1, string preadmitnumber1, ISet<ClearCanvas.Healthcare.AmbulatoryStatusEnum> ambulatorystatuses1, IDictionary<string, string> extendedproperties1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_patient = patient1;
		  	
		  	_visitNumber = visitnumber1;
		  	
		  	_status = status1;
		  	
		  	_admitTime = admittime1;
		  	
		  	_dischargeTime = dischargetime1;
		  	
		  	_dischargeDisposition = dischargedisposition1;
		  	
		  	_patientClass = patientclass1;
		  	
		  	_patientType = patienttype1;
		  	
		  	_admissionType = admissiontype1;
		  	
		  	_facility = facility1;
		  	
		  	_currentLocation = currentlocation1;
		  	
		  	_locations = locations1;
		  	
		  	_practitioners = practitioners1;
		  	
		  	_vipIndicator = vipindicator1;
		  	
		  	_preadmitNumber = preadmitnumber1;
		  	
		  	_ambulatoryStatuses = ambulatorystatuses1;
		  	
		  	_extendedProperties = extendedproperties1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Patient Patient
	  	{
			
			get { return _patient; }
			
			
			 set { _patient = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[EmbeddedValue]
	  	public virtual ClearCanvas.Healthcare.VisitNumber VisitNumber
	  	{
			
			get { return _visitNumber; }
			
			
			 set { _visitNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.VisitStatusEnum Status
	  	{
			
			get { return _status; }
			
			
			 set { _status = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? AdmitTime
	  	{
			
			get { return _admitTime; }
			
			
			 set { _admitTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? DischargeTime
	  	{
			
			get { return _dischargeTime; }
			
			
			 set { _dischargeTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string DischargeDisposition
	  	{
			
			get { return _dischargeDisposition; }
			
			
			 set { _dischargeDisposition = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.PatientClassEnum PatientClass
	  	{
			
			get { return _patientClass; }
			
			
			 set { _patientClass = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.PatientTypeEnum PatientType
	  	{
			
			get { return _patientType; }
			
			
			 set { _patientType = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.AdmissionTypeEnum AdmissionType
	  	{
			
			get { return _admissionType; }
			
			
			 set { _admissionType = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Facility Facility
	  	{
			
			get { return _facility; }
			
			
			 set { _facility = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Location CurrentLocation
	  	{
			
			get { return _currentLocation; }
			
			
			 set { _currentLocation = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.VisitLocation))]
	  	public virtual IList<ClearCanvas.Healthcare.VisitLocation> Locations
	  	{
			
			get { return _locations; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.VisitPractitioner))]
	  	public virtual IList<ClearCanvas.Healthcare.VisitPractitioner> Practitioners
	  	{
			
			get { return _practitioners; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool VipIndicator
	  	{
			
			get { return _vipIndicator; }
			
			
			 set { _vipIndicator = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(20)]
	  	public virtual string PreadmitNumber
	  	{
			
			get { return _preadmitNumber; }
			
			
			 set { _preadmitNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.AmbulatoryStatusEnum> AmbulatoryStatuses
	  	{
			
			get { return _ambulatoryStatuses; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[ExtendedPropertiesCollection]
	  	public virtual IDictionary<string, string> ExtendedProperties
	  	{
			
			get { return _extendedProperties; }
			
			
			protected set { _extendedProperties = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
