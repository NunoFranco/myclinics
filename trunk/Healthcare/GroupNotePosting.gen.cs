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
    /// GroupNotePosting entity
    /// </summary>
	
	public partial class GroupNotePosting : ClearCanvas.Healthcare.NotePosting
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.StaffGroup _recipient;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public GroupNotePosting()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public GroupNotePosting(ClearCanvas.Healthcare.Note note1, bool isacknowledged1, ClearCanvas.Healthcare.NoteAcknowledgement acknowledgedby1, ClearCanvas.Healthcare.StaffGroup recipient1)
			:base(note1, isacknowledged1, acknowledgedby1)
	  	{
		  	CustomInitialize();

			
		  	_recipient = recipient1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.StaffGroup Recipient
	  	{
			
			get { return _recipient; }
			
			
			 set { _recipient = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
