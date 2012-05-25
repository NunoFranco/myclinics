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
    /// AttachedDocument entity
    /// </summary>
	
	public partial class AttachedDocument : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _mimeType;
	  	
	  	private string _fileExtension;
	  	
	  	private DateTime _creationTime;
	  	
	  	private DateTime _receivedTime;
	  	
	  	private string _contentUrl;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public AttachedDocument()
	  	{
		 	
		  	_creationTime = Platform.Time;
		  	
		  	_receivedTime = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public AttachedDocument(string mimetype1, string fileextension1, DateTime creationtime1, DateTime receivedtime1, string contenturl1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_mimeType = mimetype1;
		  	
		  	_fileExtension = fileextension1;
		  	
		  	_creationTime = creationtime1;
		  	
		  	_receivedTime = receivedtime1;
		  	
		  	_contentUrl = contenturl1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(32)]
	  	public virtual string MimeType
	  	{
			
			get { return _mimeType; }
			
			
			 set { _mimeType = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(16)]
	  	public virtual string FileExtension
	  	{
			
			get { return _fileExtension; }
			
			
			 set { _fileExtension = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime CreationTime
	  	{
			
			get { return _creationTime; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual DateTime ReceivedTime
	  	{
			
			get { return _receivedTime; }
			
			
			 set { _receivedTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
		[Length(1024)]
	  	public virtual string ContentUrl
	  	{
			
			get { return _contentUrl; }
			
			
			 set { _contentUrl = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
