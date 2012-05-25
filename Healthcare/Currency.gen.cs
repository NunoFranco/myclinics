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
    /// Currency entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class Currency : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _currencyCode;
	  	
	  	private string _currencyName;
	  	
	  	private Decimal _rateToPrimaryExRate;
	  	
	  	private string _displayLocale;
	  	
	  	private string _customDisplayFormat;
	  	
	  	private bool _isPrimaryExRateCurrency;
	  	
	  	private bool _isPrimaryCurrency;
	  	
	  	private string _createdUser;
	  	
	  	private bool _deactivated;
	  	
	  	private DateTime _createdOn;
	  	
	  	private DateTime _lastUpdated;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Currency()
	  	{
		 	
		  	_createdOn = Platform.Time;
		  	
		  	_lastUpdated = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Currency(string currencycode1, string currencyname1, Decimal ratetoprimaryexrate1, string displaylocale1, string customdisplayformat1, bool isprimaryexratecurrency1, bool isprimarycurrency1, string createduser1, DateTime createdon1, DateTime lastupdated1, ClearCanvas.Healthcare.Facility clinic1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_currencyCode = currencycode1;
		  	
		  	_currencyName = currencyname1;
		  	
		  	_rateToPrimaryExRate = ratetoprimaryexrate1;
		  	
		  	_displayLocale = displaylocale1;
		  	
		  	_customDisplayFormat = customdisplayformat1;
		  	
		  	_isPrimaryExRateCurrency = isprimaryexratecurrency1;
		  	
		  	_isPrimaryCurrency = isprimarycurrency1;
		  	
		  	_createdUser = createduser1;
		  	
		  	_createdOn = createdon1;
		  	
		  	_lastUpdated = lastupdated1;
		  	
		  	_clinic = clinic1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(10)]
	  	public virtual string CurrencyCode
	  	{
			
			get { return _currencyCode; }
			
			
			 set { _currencyCode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(50)]
	  	public virtual string CurrencyName
	  	{
			
			get { return _currencyName; }
			
			
			 set { _currencyName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal RateToPrimaryExRate
	  	{
			
			get { return _rateToPrimaryExRate; }
			
			
			 set { _rateToPrimaryExRate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public virtual string DisplayLocale
	  	{
			
			get { return _displayLocale; }
			
			
			 set { _displayLocale = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public virtual string CustomDisplayFormat
	  	{
			
			get { return _customDisplayFormat; }
			
			
			 set { _customDisplayFormat = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsPrimaryExRateCurrency
	  	{
			
			get { return _isPrimaryExRateCurrency; }
			
			
			 set { _isPrimaryExRateCurrency = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsPrimaryCurrency
	  	{
			
			get { return _isPrimaryCurrency; }
			
			
			 set { _isPrimaryCurrency = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string CreatedUser
	  	{
			
			get { return _createdUser; }
			
			
			 set { _createdUser = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime CreatedOn
	  	{
			
			get { return _createdOn; }
			
			
			 set { _createdOn = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime LastUpdated
	  	{
			
			get { return _lastUpdated; }
			
			
			 set { _lastUpdated = value; }
			
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
