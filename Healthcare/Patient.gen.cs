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
    /// Patient entity
    /// </summary>
	
	public partial class Patient : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private ISet<ClearCanvas.Healthcare.PatientProfile> _profiles;
	  	
	  	private IList<ClearCanvas.Healthcare.PatientAttachment> _attachments;
	  	
	  	private ISet<ClearCanvas.Healthcare.PatientNote> _notes;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Patient()
	  	{
		 	
		  	_profiles = new HashedSet<ClearCanvas.Healthcare.PatientProfile>();
		  	
		  	_attachments = new List<ClearCanvas.Healthcare.PatientAttachment>();
		  	
		  	_notes = new HashedSet<ClearCanvas.Healthcare.PatientNote>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Patient(ClearCanvas.Healthcare.Facility clinic1, ISet<ClearCanvas.Healthcare.PatientProfile> profiles1, IList<ClearCanvas.Healthcare.PatientAttachment> attachments1, ISet<ClearCanvas.Healthcare.PatientNote> notes1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_clinic = clinic1;
		  	
		  	_profiles = profiles1;
		  	
		  	_attachments = attachments1;
		  	
		  	_notes = notes1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			 set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.PatientProfile> Profiles
	  	{
			
			get { return _profiles; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[EmbeddedValueCollection(typeof(ClearCanvas.Healthcare.PatientAttachment))]
	  	public virtual IList<ClearCanvas.Healthcare.PatientAttachment> Attachments
	  	{
			
			get { return _attachments; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.PatientNote> Notes
	  	{
			
			get { return _notes; }
			
			
			protected set { _notes = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
