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
    /// ExternalPractitioner entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class ExternalPractitioner : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.PersonName _name;
	  	
	  	private string _licenseNumber;
	  	
	  	private string _billingNumber;
	  	
	  	private ISet<ClearCanvas.Healthcare.ExternalPractitionerContactPoint> _contactPoints;
	  	
	  	private IDictionary<string, string> _extendedProperties;
	  	
	  	private bool _deactivated;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ExternalPractitioner()
	  	{
		 	
		  	_name = new ClearCanvas.Healthcare.PersonName();
		  	
		  	_contactPoints = new HashedSet<ClearCanvas.Healthcare.ExternalPractitionerContactPoint>();
		  	
		  	_extendedProperties = new Dictionary<string, string>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ExternalPractitioner(ClearCanvas.Healthcare.PersonName name1, string licensenumber1, string billingnumber1, ISet<ClearCanvas.Healthcare.ExternalPractitionerContactPoint> contactpoints1, IDictionary<string, string> extendedproperties1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_licenseNumber = licensenumber1;
		  	
		  	_billingNumber = billingnumber1;
		  	
		  	_contactPoints = contactpoints1;
		  	
		  	_extendedProperties = extendedproperties1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[EmbeddedValue]
	  	public virtual ClearCanvas.Healthcare.PersonName Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string LicenseNumber
	  	{
			
			get { return _licenseNumber; }
			
			
			 set { _licenseNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string BillingNumber
	  	{
			
			get { return _billingNumber; }
			
			
			 set { _billingNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.ExternalPractitionerContactPoint> ContactPoints
	  	{
			
			get { return _contactPoints; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[ExtendedPropertiesCollection]
	  	public virtual IDictionary<string, string> ExtendedProperties
	  	{
			
			get { return _extendedProperties; }
			
			
			protected set { _extendedProperties = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
