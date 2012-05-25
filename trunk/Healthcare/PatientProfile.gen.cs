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
    /// PatientProfile entity
    /// </summary>
	
	public partial class PatientProfile : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.PatientIdentifier _mrn;
	  	
	  	private IList<ClearCanvas.Healthcare.PatientIdentifier> _expiredMrns;
	  	
	  	private ClearCanvas.Healthcare.HealthcardNumber _healthcard;
	  	
	  	private ClearCanvas.Healthcare.PersonName _name;
	  	
	  	private DateTime? _dateOfBirth;
	  	
	  	private ClearCanvas.Healthcare.SexEnum _sex;
	  	
	  	private ClearCanvas.Healthcare.SpokenLanguageEnum _primaryLanguage;
	  	
	  	private ClearCanvas.Healthcare.ReligionEnum _religion;
	  	
	  	private bool _deathIndicator;
	  	
	  	private DateTime? _timeOfDeath;
	  	
	  	private IList<ClearCanvas.Healthcare.ContactPerson> _contactPersons;
	  	
	  	private IList<ClearCanvas.Healthcare.EmailAddress> _emailAddresses;
	  	
	  	private IList<ClearCanvas.Healthcare.TelephoneNumber> _telephoneNumbers;
	  	
	  	private IList<ClearCanvas.Healthcare.Address> _addresses;
	  	
	  	private ClearCanvas.Healthcare.Patient _patient;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private ClearCanvas.Healthcare.InsuranceTypeEnum _insuranceType;
	  	
	  	private ClearCanvas.Healthcare.DiscountTypeEnum _discountType;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public PatientProfile()
	  	{
		 	
		  	_mrn = new ClearCanvas.Healthcare.PatientIdentifier();
		  	
		  	_expiredMrns = new List<ClearCanvas.Healthcare.PatientIdentifier>();
		  	
		  	_healthcard = new ClearCanvas.Healthcare.HealthcardNumber();
		  	
		  	_name = new ClearCanvas.Healthcare.PersonName();
		  	
		  	_contactPersons = new List<ClearCanvas.Healthcare.ContactPerson>();
		  	
		  	_emailAddresses = new List<ClearCanvas.Healthcare.EmailAddress>();
		  	
		  	_telephoneNumbers = new List<ClearCanvas.Healthcare.TelephoneNumber>();
		  	
		  	_addresses = new List<ClearCanvas.Healthcare.Address>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public PatientProfile(ClearCanvas.Healthcare.PatientIdentifier mrn1, IList<ClearCanvas.Healthcare.PatientIdentifier> expiredmrns1, ClearCanvas.Healthcare.HealthcardNumber healthcard1, ClearCanvas.Healthcare.PersonName name1, DateTime? dateofbirth1, ClearCanvas.Healthcare.SexEnum sex1, ClearCanvas.Healthcare.SpokenLanguageEnum primarylanguage1, ClearCanvas.Healthcare.ReligionEnum religion1, bool deathindicator1, DateTime? timeofdeath1, IList<ClearCanvas.Healthcare.ContactPerson> contactpersons1, IList<ClearCanvas.Healthcare.EmailAddress> emailaddresses1, IList<ClearCanvas.Healthcare.TelephoneNumber> telephonenumbers1, IList<ClearCanvas.Healthcare.Address> addresses1, ClearCanvas.Healthcare.Patient patient1, ClearCanvas.Healthcare.Facility clinic1, ClearCanvas.Healthcare.InsuranceTypeEnum insurancetype1, ClearCanvas.Healthcare.DiscountTypeEnum discounttype1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_mrn = mrn1;
		  	
		  	_expiredMrns = expiredmrns1;
		  	
		  	_healthcard = healthcard1;
		  	
		  	_name = name1;
		  	
		  	_dateOfBirth = dateofbirth1;
		  	
		  	_sex = sex1;
		  	
		  	_primaryLanguage = primarylanguage1;
		  	
		  	_religion = religion1;
		  	
		  	_deathIndicator = deathindicator1;
		  	
		  	_timeOfDeath = timeofdeath1;
		  	
		  	_contactPersons = contactpersons1;
		  	
		  	_emailAddresses = emailaddresses1;
		  	
		  	_telephoneNumbers = telephonenumbers1;
		  	
		  	_addresses = addresses1;
		  	
		  	_patient = patient1;
		  	
		  	_clinic = clinic1;
		  	
		  	_insuranceType = insurancetype1;
		  	
		  	_discountType = discounttype1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[EmbeddedValue]
	  	public virtual ClearCanvas.Healthcare.PatientIdentifier Mrn
	  	{
			
			get { return _mrn; }
			
			
			 set { _mrn = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.PatientIdentifier))]
	  	public virtual IList<ClearCanvas.Healthcare.PatientIdentifier> ExpiredMrns
	  	{
			
			get { return _expiredMrns; }
			
			
			protected set { _expiredMrns = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValue]
	  	public virtual ClearCanvas.Healthcare.HealthcardNumber Healthcard
	  	{
			
			get { return _healthcard; }
			
			
			 set { _healthcard = value; }
			
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
	  	public virtual ClearCanvas.Healthcare.SpokenLanguageEnum PrimaryLanguage
	  	{
			
			get { return _primaryLanguage; }
			
			
			 set { _primaryLanguage = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ReligionEnum Religion
	  	{
			
			get { return _religion; }
			
			
			 set { _religion = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool DeathIndicator
	  	{
			
			get { return _deathIndicator; }
			
			
			 set { _deathIndicator = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? TimeOfDeath
	  	{
			
			get { return _timeOfDeath; }
			
			
			 set { _timeOfDeath = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.ContactPerson))]
	  	public virtual IList<ClearCanvas.Healthcare.ContactPerson> ContactPersons
	  	{
			
			get { return _contactPersons; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.EmailAddress))]
	  	public virtual IList<ClearCanvas.Healthcare.EmailAddress> EmailAddresses
	  	{
			
			get { return _emailAddresses; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.TelephoneNumber))]
	  	public virtual IList<ClearCanvas.Healthcare.TelephoneNumber> TelephoneNumbers
	  	{
			
			get { return _telephoneNumbers; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.Address))]
	  	public virtual IList<ClearCanvas.Healthcare.Address> Addresses
	  	{
			
			get { return _addresses; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Patient Patient
	  	{
			
			get { return _patient; }
			
			
			 set { _patient = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.InsuranceTypeEnum InsuranceType
	  	{
			
			get { return _insuranceType; }
			
			
			 set { _insuranceType = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.DiscountTypeEnum DiscountType
	  	{
			
			get { return _discountType; }
			
			
			 set { _discountType = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
