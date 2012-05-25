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
    /// DiagnosticService entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class DiagnosticService : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private string _name;
	  	
	  	private ISet<ClearCanvas.Healthcare.ProcedureType> _procedureTypes;
	  	
	  	private Decimal _packagePrice;
	  	
	  	private bool _isAutoUpdatePrice;
	  	
	  	private bool _isPackageProcedure;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public DiagnosticService()
	  	{
		 	
		  	_procedureTypes = new HashedSet<ClearCanvas.Healthcare.ProcedureType>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public DiagnosticService(string id1, string name1, ISet<ClearCanvas.Healthcare.ProcedureType> proceduretypes1, Decimal packageprice1, bool isautoupdateprice1, bool ispackageprocedure1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_name = name1;
		  	
		  	_procedureTypes = proceduretypes1;
		  	
		  	_packagePrice = packageprice1;
		  	
		  	_isAutoUpdatePrice = isautoupdateprice1;
		  	
		  	_isPackageProcedure = ispackageprocedure1;
		  	
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
		[Length(100)]
		[Unique]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.ProcedureType> ProcedureTypes
	  	{
			
			get { return _procedureTypes; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal PackagePrice
	  	{
			
			get { return _packagePrice; }
			
			
			 set { _packagePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsAutoUpdatePrice
	  	{
			
			get { return _isAutoUpdatePrice; }
			
			
			 set { _isAutoUpdatePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsPackageProcedure
	  	{
			
			get { return _isPackageProcedure; }
			
			
			 set { _isPackageProcedure = value; }
			
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
