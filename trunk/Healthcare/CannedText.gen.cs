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
    /// CannedText entity
    /// </summary>
	
	public partial class CannedText : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _name;
	  	
	  	private string _category;
	  	
	  	private ClearCanvas.Healthcare.Staff _staff;
	  	
	  	private ClearCanvas.Healthcare.StaffGroup _staffGroup;
	  	
	  	private string _text;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public CannedText()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public CannedText(string name1, string category1, ClearCanvas.Healthcare.Staff staff1, ClearCanvas.Healthcare.StaffGroup staffgroup1, string text1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_name = name1;
		  	
		  	_category = category1;
		  	
		  	_staff = staff1;
		  	
		  	_staffGroup = staffgroup1;
		  	
		  	_text = text1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(100)]
	  	public virtual string Name
	  	{
			
			get { return _name; }
			
			
			 set { _name = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(255)]
	  	public virtual string Category
	  	{
			
			get { return _category; }
			
			
			 set { _category = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Staff
	  	{
			
			get { return _staff; }
			
			
			 set { _staff = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.StaffGroup StaffGroup
	  	{
			
			get { return _staffGroup; }
			
			
			 set { _staffGroup = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(65000)]
	  	public virtual string Text
	  	{
			
			get { return _text; }
			
			
			 set { _text = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
