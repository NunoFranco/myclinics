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
    /// PatientNote entity
    /// </summary>
	
	public partial class PatientNote : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Patient _patient;
	  	
	  	private DateTime _creationTime;
	  	
	  	private ClearCanvas.Healthcare.Staff _author;
	  	
	  	private ClearCanvas.Healthcare.PatientNoteCategory _category;
	  	
	  	private string _comment;
	  	
	  	private ClearCanvas.Healthcare.DateTimeRange _validRange;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public PatientNote()
	  	{
		 	
		  	_creationTime = Platform.Time;
		  	
		  	_validRange = new ClearCanvas.Healthcare.DateTimeRange();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public PatientNote(ClearCanvas.Healthcare.Patient patient1, DateTime creationtime1, ClearCanvas.Healthcare.Staff author1, ClearCanvas.Healthcare.PatientNoteCategory category1, string comment1, ClearCanvas.Healthcare.DateTimeRange validrange1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_patient = patient1;
		  	
		  	_creationTime = creationtime1;
		  	
		  	_author = author1;
		  	
		  	_category = category1;
		  	
		  	_comment = comment1;
		  	
		  	_validRange = validrange1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Patient Patient
	  	{
			
			get { return _patient; }
			
			
			 set { _patient = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime CreationTime
	  	{
			
			get { return _creationTime; }
			
			
			 set { _creationTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.Staff Author
	  	{
			
			get { return _author; }
			
			
			 set { _author = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual ClearCanvas.Healthcare.PatientNoteCategory Category
	  	{
			
			get { return _category; }
			
			
			 set { _category = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(1024)]
	  	public virtual string Comment
	  	{
			
			get { return _comment; }
			
			
			 set { _comment = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.DateTimeRange ValidRange
	  	{
			
			get { return _validRange; }
			
			
			 set { _validRange = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
