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
    /// DiscountRule entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class DiscountRule : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.DiscountTypeEnum _classID;
	  	
	  	private ClearCanvas.Healthcare.ProcedureType _procedureType;
	  	
	  	private string _ruleCode;
	  	
	  	private string _ruleName;
	  	
	  	private DisCountInsuranceAmountType _amountType;
	  	
	  	private Decimal _amount;
	  	
	  	private DateTime? _startDate;
	  	
	  	private DateTime? _expireDate;
	  	
	  	private string _createdUser;
	  	
	  	private DateTime? _createdDate;
	  	
	  	private DateTime? _lastUpdated;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public DiscountRule()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public DiscountRule(ClearCanvas.Healthcare.DiscountTypeEnum classid1, ClearCanvas.Healthcare.ProcedureType proceduretype1, string rulecode1, string rulename1, DisCountInsuranceAmountType amounttype1, Decimal amount1, DateTime? startdate1, DateTime? expiredate1, string createduser1, DateTime? createddate1, DateTime? lastupdated1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_classID = classid1;
		  	
		  	_procedureType = proceduretype1;
		  	
		  	_ruleCode = rulecode1;
		  	
		  	_ruleName = rulename1;
		  	
		  	_amountType = amounttype1;
		  	
		  	_amount = amount1;
		  	
		  	_startDate = startdate1;
		  	
		  	_expireDate = expiredate1;
		  	
		  	_createdUser = createduser1;
		  	
		  	_createdDate = createddate1;
		  	
		  	_lastUpdated = lastupdated1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.DiscountTypeEnum ClassID
	  	{
			
			get { return _classID; }
			
			
			 set { _classID = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ProcedureType ProcedureType
	  	{
			
			get { return _procedureType; }
			
			
			 set { _procedureType = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public virtual string RuleCode
	  	{
			
			get { return _ruleCode; }
			
			
			 set { _ruleCode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public virtual string RuleName
	  	{
			
			get { return _ruleName; }
			
			
			 set { _ruleName = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DisCountInsuranceAmountType AmountType
	  	{
			
			get { return _amountType; }
			
			
			 set { _amountType = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Decimal Amount
	  	{
			
			get { return _amount; }
			
			
			 set { _amount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? StartDate
	  	{
			
			get { return _startDate; }
			
			
			 set { _startDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? ExpireDate
	  	{
			
			get { return _expireDate; }
			
			
			 set { _expireDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public virtual string CreatedUser
	  	{
			
			get { return _createdUser; }
			
			
			 set { _createdUser = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? CreatedDate
	  	{
			
			get { return _createdDate; }
			
			
			 set { _createdDate = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? LastUpdated
	  	{
			
			get { return _lastUpdated; }
			
			
			 set { _lastUpdated = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
