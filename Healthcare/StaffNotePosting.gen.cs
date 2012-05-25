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
    /// StaffNotePosting entity
    /// </summary>
	
	public partial class StaffNotePosting : ClearCanvas.Healthcare.NotePosting
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Staff _recipient;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public StaffNotePosting()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public StaffNotePosting(ClearCanvas.Healthcare.Note note1, bool isacknowledged1, ClearCanvas.Healthcare.NoteAcknowledgement acknowledgedby1, ClearCanvas.Healthcare.Staff recipient1)
			:base(note1, isacknowledged1, acknowledgedby1)
	  	{
		  	CustomInitialize();

			
		  	_recipient = recipient1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Staff Recipient
	  	{
			
			get { return _recipient; }
			
			
			 set { _recipient = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
