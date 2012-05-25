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
    /// Location entity
    /// </summary>
	
	[DeactivationFlag("Deactivated")]
	public partial class Location : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _id;
	  	
	  	private string _name;
	  	
	  	private string _description;
	  	
	  	private ClearCanvas.Healthcare.Facility _facility;
	  	
	  	private string _building;
	  	
	  	private string _floor;
	  	
	  	private string _pointOfCare;
	  	
	  	private string _room;
	  	
	  	private string _bed;
	  	
	  	private bool _deactivated;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Location()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Location(string id1, string name1, string description1, ClearCanvas.Healthcare.Facility facility1, string building1, string floor1, string pointofcare1, string room1, string bed1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_id = id1;
		  	
		  	_name = name1;
		  	
		  	_description = description1;
		  	
		  	_facility = facility1;
		  	
		  	_building = building1;
		  	
		  	_floor = floor1;
		  	
		  	_pointOfCare = pointofcare1;
		  	
		  	_room = room1;
		  	
		  	_bed = bed1;
		  	
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
		[Unique]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(2000)]
	  	public virtual string Description
	  	{
			
			get { return _description; }
			
			
			 set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Facility Facility
	  	{
			
			get { return _facility; }
			
			
			 set { _facility = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string Building
	  	{
			
			get { return _building; }
			
			
			 set { _building = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string Floor
	  	{
			
			get { return _floor; }
			
			
			 set { _floor = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string PointOfCare
	  	{
			
			get { return _pointOfCare; }
			
			
			 set { _pointOfCare = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string Room
	  	{
			
			get { return _room; }
			
			
			 set { _room = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(100)]
	  	public virtual string Bed
	  	{
			
			get { return _bed; }
			
			
			 set { _bed = value; }
			
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
