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
    /// ProcedureType entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class ProcedureType : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private string _name;
	  	
	  	private ClearCanvas.Healthcare.ProcedureType _baseType;
	  	
	  	private string _planXml;
	  	
	  	private bool _deactivated;
	  	
	  	private Decimal _basePrice;
	  	
	  	private string _mainIngredient;
	  	
	  	private Decimal _tax;
	  	
	  	private bool _isRequired;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private ClearCanvas.Healthcare.ProcedureTypeCategoryEnum _category;
	  	
	  	private string _useDirection;
	  	
	  	private string _medicineDose;
	  	
	  	private Decimal _inputPrice;
	  	
	  	private Decimal _manualPrice;
	  	
	  	private bool _isAutomaticPrice;
	  	
	  	private bool _saleable;
	  	
	  	private Decimal _insurancePrice;
	  	
	  	private Double _mininumAllow;
	  	
	  	private Double _currentQuantity;
	  	
	  	private string _barcode;
	  	
	  	private bool _isPoisonA;
	  	
	  	private bool _isPoisonB;
	  	
	  	private bool _isSaleWithOrder;
	  	
	  	private string _sideEffective;
	  	
	  	private string _packingMethod;
	  	
	  	private ClearCanvas.Healthcare.UOMEnum _uOM;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ProcedureType()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ProcedureType(string id1, string name1, ClearCanvas.Healthcare.ProcedureType basetype1, string planxml1, Decimal baseprice1, string mainingredient1, Decimal tax1, bool isrequired1, ClearCanvas.Healthcare.Facility clinic1, ClearCanvas.Healthcare.ProcedureTypeCategoryEnum category1, string usedirection1, string medicinedose1, Decimal inputprice1, Decimal manualprice1, bool isautomaticprice1, bool saleable1, Decimal insuranceprice1, Double mininumallow1, Double currentquantity1, string barcode1, bool ispoisona1, bool ispoisonb1, bool issalewithorder1, string sideeffective1, string packingmethod1, ClearCanvas.Healthcare.UOMEnum uom1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_name = name1;
		  	
		  	_baseType = basetype1;
		  	
		  	_planXml = planxml1;
		  	
		  	_basePrice = baseprice1;
		  	
		  	_mainIngredient = mainingredient1;
		  	
		  	_tax = tax1;
		  	
		  	_isRequired = isrequired1;
		  	
		  	_clinic = clinic1;
		  	
		  	_category = category1;
		  	
		  	_useDirection = usedirection1;
		  	
		  	_medicineDose = medicinedose1;
		  	
		  	_inputPrice = inputprice1;
		  	
		  	_manualPrice = manualprice1;
		  	
		  	_isAutomaticPrice = isautomaticprice1;
		  	
		  	_saleable = saleable1;
		  	
		  	_insurancePrice = insuranceprice1;
		  	
		  	_mininumAllow = mininumallow1;
		  	
		  	_currentQuantity = currentquantity1;
		  	
		  	_barcode = barcode1;
		  	
		  	_isPoisonA = ispoisona1;
		  	
		  	_isPoisonB = ispoisonb1;
		  	
		  	_isSaleWithOrder = issalewithorder1;
		  	
		  	_sideEffective = sideeffective1;
		  	
		  	_packingMethod = packingmethod1;
		  	
		  	_uOM = uom1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(100)]
		[Unique]
	  	public virtual string Id
	  	{
			
			get { return _id; }
			
			
			 set { _id = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(255)]
		[Unique]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.ProcedureType BaseType
	  	{
			
			get { return _baseType; }
			
			
			 set { _baseType = value; }
			
	  	}
		
	  	
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Deactivated
	  	{
			
			get { return _deactivated; }
			
			
			 set { _deactivated = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal BasePrice
	  	{
			
			get { return _basePrice; }
			
			
			 set { _basePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string MainIngredient
	  	{
			
			get { return _mainIngredient; }
			
			
			 set { _mainIngredient = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual Decimal Tax
	  	{
			
			get { return _tax; }
			
			
			 set { _tax = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsRequired
	  	{
			
			get { return _isRequired; }
			
			
			 set { _isRequired = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.ProcedureTypeCategoryEnum Category
	  	{
			
			get { return _category; }
			
			
			 set { _category = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string UseDirection
	  	{
			
			get { return _useDirection; }
			
			
			 set { _useDirection = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string MedicineDose
	  	{
			
			get { return _medicineDose; }
			
			
			 set { _medicineDose = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Decimal InputPrice
	  	{
			
			get { return _inputPrice; }
			
			
			 set { _inputPrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Decimal ManualPrice
	  	{
			
			get { return _manualPrice; }
			
			
			 set { _manualPrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool IsAutomaticPrice
	  	{
			
			get { return _isAutomaticPrice; }
			
			
			 set { _isAutomaticPrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool Saleable
	  	{
			
			get { return _saleable; }
			
			
			 set { _saleable = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Decimal InsurancePrice
	  	{
			
			get { return _insurancePrice; }
			
			
			 set { _insurancePrice = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Double MininumAllow
	  	{
			
			get { return _mininumAllow; }
			
			
			 set { _mininumAllow = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual Double CurrentQuantity
	  	{
			
			get { return _currentQuantity; }
			
			
			 set { _currentQuantity = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Unique]
	  	public virtual string Barcode
	  	{
			
			get { return _barcode; }
			
			
			 set { _barcode = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool IsPoisonA
	  	{
			
			get { return _isPoisonA; }
			
			
			 set { _isPoisonA = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool IsPoisonB
	  	{
			
			get { return _isPoisonB; }
			
			
			 set { _isPoisonB = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual bool IsSaleWithOrder
	  	{
			
			get { return _isSaleWithOrder; }
			
			
			 set { _isSaleWithOrder = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string SideEffective
	  	{
			
			get { return _sideEffective; }
			
			
			 set { _sideEffective = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual string PackingMethod
	  	{
			
			get { return _packingMethod; }
			
			
			 set { _packingMethod = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.UOMEnum UOM
	  	{
			
			get { return _uOM; }
			
			
			 set { _uOM = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
