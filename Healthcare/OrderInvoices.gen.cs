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
    /// OrderInvoices entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class OrderInvoices : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Order _invoiceOrder;
	  	
	  	private string _invoiceNumber;
	  	
	  	private Decimal _totalCollect;
	  	
	  	private Decimal _totalInsurance;
	  	
	  	private Decimal _totalDiscount;
	  	
	  	private Decimal _totalWaitingAmount;
	  	
	  	private bool _isCollectedInsurance;
	  	
	  	private string _createdUser;
	  	
	  	private bool _deactivated;
	  	
	  	private Decimal _totalReceived;
	  	
	  	private Decimal _totalChanges;
	  	
	  	private string _listProcedures;
	  	
	  	private DateTime _createdDate;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public OrderInvoices()
	  	{
		 	
		  	_createdDate = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public OrderInvoices(ClearCanvas.Healthcare.Order invoiceorder1, string invoicenumber1, Decimal totalcollect1, Decimal totalinsurance1, Decimal totaldiscount1, Decimal totalwaitingamount1, bool iscollectedinsurance1, string createduser1, Decimal totalreceived1, Decimal totalchanges1, string listprocedures1, DateTime createddate1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_invoiceOrder = invoiceorder1;
		  	
		  	_invoiceNumber = invoicenumber1;
		  	
		  	_totalCollect = totalcollect1;
		  	
		  	_totalInsurance = totalinsurance1;
		  	
		  	_totalDiscount = totaldiscount1;
		  	
		  	_totalWaitingAmount = totalwaitingamount1;
		  	
		  	_isCollectedInsurance = iscollectedinsurance1;
		  	
		  	_createdUser = createduser1;
		  	
		  	_totalReceived = totalreceived1;
		  	
		  	_totalChanges = totalchanges1;
		  	
		  	_listProcedures = listprocedures1;
		  	
		  	_createdDate = createddate1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Order InvoiceOrder
	  	{
			
			get { return _invoiceOrder; }
			
			
			 set { _invoiceOrder = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(50)]
	  	public virtual string InvoiceNumber
	  	{
			
			get { return _invoiceNumber; }
			
			
			 set { _invoiceNumber = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal TotalCollect
	  	{
			
			get { return _totalCollect; }
			
			
			 set { _totalCollect = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal TotalInsurance
	  	{
			
			get { return _totalInsurance; }
			
			
			 set { _totalInsurance = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal TotalDiscount
	  	{
			
			get { return _totalDiscount; }
			
			
			 set { _totalDiscount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal TotalWaitingAmount
	  	{
			
			get { return _totalWaitingAmount; }
			
			
			 set { _totalWaitingAmount = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsCollectedInsurance
	  	{
			
			get { return _isCollectedInsurance; }
			
			
			 set { _isCollectedInsurance = value; }
			
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
	  	public virtual Decimal TotalReceived
	  	{
			
			get { return _totalReceived; }
			
			
			 set { _totalReceived = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal TotalChanges
	  	{
			
			get { return _totalChanges; }
			
			
			 set { _totalChanges = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(65000)]
	  	public virtual string ListProcedures
	  	{
			
			get { return _listProcedures; }
			
			
			 set { _listProcedures = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime CreatedDate
	  	{
			
			get { return _createdDate; }
			
			
			 set { _createdDate = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
