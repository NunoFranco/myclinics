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
    /// ProtocolGroup entity
    /// </summary>
	
	public partial class ProtocolGroup : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _name;
	  	
	  	private string _description;
	  	
	  	private ISet<ClearCanvas.Healthcare.ReadingGroup> _readingGroups;
	  	
	  	private IList<ClearCanvas.Healthcare.ProtocolCode> _codes;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ProtocolGroup()
	  	{
		 	
		  	_readingGroups = new HashedSet<ClearCanvas.Healthcare.ReadingGroup>();
		  	
		  	_codes = new List<ClearCanvas.Healthcare.ProtocolCode>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ProtocolGroup(string name1, string description1, ISet<ClearCanvas.Healthcare.ReadingGroup> readinggroups1, IList<ClearCanvas.Healthcare.ProtocolCode> codes1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_description = description1;
		  	
		  	_readingGroups = readinggroups1;
		  	
		  	_codes = codes1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
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
		[Length(1024)]
	  	public virtual string Description
	  	{
			
			get { return _description; }
			
			
			 set { _description = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.ReadingGroup> ReadingGroups
	  	{
			
			get { return _readingGroups; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual IList<ClearCanvas.Healthcare.ProtocolCode> Codes
	  	{
			
			get { return _codes; }
			
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
