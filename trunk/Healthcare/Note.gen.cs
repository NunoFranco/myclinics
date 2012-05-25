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
    /// Note entity
    /// </summary>
	
	public partial class Note : ClearCanvas.Enterprise.Core.Entity
	{
       	#region Private fields
       	
		
	  	private string _category;
	  	
	  	private string _body;
	  	
	  	private bool _urgent;
	  	
	  	private DateTime _creationTime;
	  	
	  	private ClearCanvas.Healthcare.Staff _author;
	  	
	  	private ClearCanvas.Healthcare.StaffGroup _onBehalfOfGroup;
	  	
	  	private DateTime? _postTime;
	  	
	  	private bool _isFullyAcknowledged;
	  	
	  	private ISet<ClearCanvas.Healthcare.NotePosting> _postings;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public Note()
	  	{
		 	
		  	_creationTime = Platform.Time;
		  	
		  	_postings = new HashedSet<ClearCanvas.Healthcare.NotePosting>();
		  	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public Note(string category1, string body1, bool urgent1, DateTime creationtime1, ClearCanvas.Healthcare.Staff author1, ClearCanvas.Healthcare.StaffGroup onbehalfofgroup1, DateTime? posttime1, bool isfullyacknowledged1, ISet<ClearCanvas.Healthcare.NotePosting> postings1)
			:base()
	  	{
		  	CustomInitialize();

			
		  	_category = category1;
		  	
		  	_body = body1;
		  	
		  	_urgent = urgent1;
		  	
		  	_creationTime = creationtime1;
		  	
		  	_author = author1;
		  	
		  	_onBehalfOfGroup = onbehalfofgroup1;
		  	
		  	_postTime = posttime1;
		  	
		  	_isFullyAcknowledged = isfullyacknowledged1;
		  	
		  	_postings = postings1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Length(1024)]
	  	public virtual string Category
	  	{
			
			get { return _category; }
			
			
			 set { _category = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Length(65000)]
	  	public virtual string Body
	  	{
			
			get { return _body; }
			
			
			 set { _body = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool Urgent
	  	{
			
			get { return _urgent; }
			
			
			 set { _urgent = value; }
			
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
	  	public virtual ClearCanvas.Healthcare.StaffGroup OnBehalfOfGroup
	  	{
			
			get { return _onBehalfOfGroup; }
			
			
			 set { _onBehalfOfGroup = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual DateTime? PostTime
	  	{
			
			get { return _postTime; }
			
			
			 set { _postTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public virtual bool IsFullyAcknowledged
	  	{
			
			get { return _isFullyAcknowledged; }
			
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public virtual ISet<ClearCanvas.Healthcare.NotePosting> Postings
	  	{
			
			get { return _postings; }
			
			
			protected set { _postings = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
