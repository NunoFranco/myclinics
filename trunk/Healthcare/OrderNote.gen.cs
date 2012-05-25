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
    /// OrderNote entity
    /// </summary>
	
	public partial class OrderNote : ClearCanvas.Healthcare.Note
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.Order _order;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public OrderNote()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}
                
		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public OrderNote(string category1, string body1, bool urgent1, DateTime creationtime1, ClearCanvas.Healthcare.Staff author1, ClearCanvas.Healthcare.StaffGroup onbehalfofgroup1, DateTime? posttime1, bool isfullyacknowledged1, ISet<ClearCanvas.Healthcare.NotePosting> postings1, ClearCanvas.Healthcare.Order order1)
			:base(category1, body1, urgent1, creationtime1, author1, onbehalfofgroup1, posttime1, isfullyacknowledged1, postings1)
	  	{
		  	CustomInitialize();

			
		  	_order = order1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public virtual ClearCanvas.Healthcare.Order Order
	  	{
			
			get { return _order; }
			
			
			 set { _order = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	}
}
