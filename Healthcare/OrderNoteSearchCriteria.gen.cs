// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="OrderNote"/> class.
    /// </summary>
	public partial class OrderNoteSearchCriteria : NoteSearchCriteria
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public OrderNoteSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public OrderNoteSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected OrderNoteSearchCriteria(OrderNoteSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new OrderNoteSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.OrderSearchCriteria Order
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Order"))
	  			{
	  				this.SubCriteria["Order"] = new ClearCanvas.Healthcare.OrderSearchCriteria("Order");
	  			}
	  			return (ClearCanvas.Healthcare.OrderSearchCriteria)this.SubCriteria["Order"];
	  		}
	  	}
	  	
	}
}
