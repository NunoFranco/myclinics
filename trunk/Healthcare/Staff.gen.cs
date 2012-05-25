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
    /// Staff entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class Staff : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private ClearCanvas.Healthcare.PersonName _name;
	  	
	  	private ClearCanvas.Healthcare.SexEnum _sex;
	  	
	  	private string _title;
	  	
	  	private string _licenseNumber;
	  	
	  	private string _billingNumber;
	  	
	  	private ClearCanvas.Healthcare.StaffTypeEnum _type;
	  	
	  	private string _userName;
	  	
	  	private IList<ClearCanvas.Healthcare.EmailAddress> _emailAddresses;
	  	
	  	private IList<ClearCanvas.Healthcare.Address> _addresses;
	  	
	  	private IList<ClearCanvas.Healthcare.TelephoneNumber> _telephoneNumbers;
	  	
	  	private IDictionary<string, string> _extendedProperties;
	  	
	  	private ISet<ClearCanvas.Healthcare.StaffGroup> _groups;
	  	
	  	private ISet<ClearCanvas.Healthcare.Facility> _clinics;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Staff()
	  	{
		 	
		  	_name = new ClearCanvas.Healthcare.PersonName();
		  	
		  	_emailAddresses = new List<ClearCanvas.Healthcare.EmailAddress>();
		  	
		  	_addresses = new List<ClearCanvas.Healthcare.Address>();
		  	
		  	_telephoneNumbers = new List<ClearCanvas.Healthcare.TelephoneNumber>();
		  	
		  	_extendedProperties = new Dictionary<string, string>();
		  	
		  	_groups = new HashedSet<ClearCanvas.Healthcare.StaffGroup>();
		  	
		  	_clinics = new HashedSet<ClearCanvas.Healthcare.Facility>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Staff(string id1, ClearCanvas.Healthcare.PersonName name1, ClearCanvas.Healthcare.SexEnum sex1, string title1, string licensenumber1, string billingnumber1, ClearCanvas.Healthcare.StaffTypeEnum type1, string username1, IList<ClearCanvas.Healthcare.EmailAddress> emailaddresses1, IList<ClearCanvas.Healthcare.Address> addresses1, IList<ClearCanvas.Healthcare.TelephoneNumber> telephonenumbers1, IDictionary<string, string> extendedproperties1, ISet<ClearCanvas.Healthcare.StaffGroup> groups1, ISet<ClearCanvas.Healthcare.Facility> clinics1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_name = name1;
		  	
		  	_sex = sex1;
		  	
		  	_title = title1;
		  	
		  	_licenseNumber = licensenumber1;
		  	
		  	_billingNumber = billingnumber1;
		  	
		  	_type = type1;
		  	
		  	_userName = username1;
		  	
		  	_emailAddresses = emailaddresses1;
		  	
		  	_addresses = addresses1;
		  	
		  	_telephoneNumbers = telephonenumbers1;
		  	
		  	_extendedProperties = extendedproperties1;
		  	
		  	_groups = groups1;
		  	
		  	_clinics = clinics1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(30)]
		[Unique]
	  	public virtual string Id
	  	{
			
			get { return _id; }
			
			
			 set { _id = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[EmbeddedValue]
	  	public virtual ClearCanvas.Healthcare.PersonName Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.SexEnum Sex
	  	{
			
			get { return _sex; }
			
			
			 set { _sex = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string Title
	  	{
			
			get { return _title; }
			
			
			 set { _title = value; }
			
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
	  	public virtual ClearCanvas.Healthcare.StaffTypeEnum Type
	  	{
			
			get { return _type; }
			
			
			 set { _type = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string UserName
	  	{
			
			get { return _userName; }
			
			
			 set { _userName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.EmailAddress))]
	  	public virtual IList<ClearCanvas.Healthcare.EmailAddress> EmailAddresses
	  	{
			
			get { return _emailAddresses; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.Address))]
	  	public virtual IList<ClearCanvas.Healthcare.Address> Addresses
	  	{
			
			get { return _addresses; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.TelephoneNumber))]
	  	public virtual IList<ClearCanvas.Healthcare.TelephoneNumber> TelephoneNumbers
	  	{
			
			get { return _telephoneNumbers; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[ExtendedPropertiesCollection]
	  	public virtual IDictionary<string, string> ExtendedProperties
	  	{
			
			get { return _extendedProperties; }
			
			
			protected set { _extendedProperties = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.StaffGroup> Groups
	  	{
			
			get { return _groups; }
			
			
			protected set { _groups = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.Facility> Clinics
	  	{
			
			get { return _clinics; }
			
			
			protected set { _clinics = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
