// This file is machine generated - changes will be lost.
using System;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// Search criteria for <see cref="OrderInvoices"/> class.
    /// </summary>
	public partial class OrderInvoicesSearchCriteria : EntitySearchCriteria<OrderInvoices>
	{
		/// <summary>
		/// Constructor for top-level search criteria (no key required)
		/// </summary>
		public OrderInvoicesSearchCriteria()
		{
		}
	
		/// <summary>
		/// Constructor for sub-criteria (key required)
		/// </summary>
		public OrderInvoicesSearchCriteria(string key)
			:base(key)
		{
		}
		
		/// <summary>
		/// Copy constructor
		/// </summary>
		protected OrderInvoicesSearchCriteria(OrderInvoicesSearchCriteria other)
			:base(other)
		{
		}
		
		public override object Clone()
        {
            return new OrderInvoicesSearchCriteria(this);
        }


		
	  	public ClearCanvas.Healthcare.OrderSearchCriteria InvoiceOrder
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InvoiceOrder"))
	  			{
	  				this.SubCriteria["InvoiceOrder"] = new ClearCanvas.Healthcare.OrderSearchCriteria("InvoiceOrder");
	  			}
	  			return (ClearCanvas.Healthcare.OrderSearchCriteria)this.SubCriteria["InvoiceOrder"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> InvoiceNumber
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("InvoiceNumber"))
	  			{
	  				this.SubCriteria["InvoiceNumber"] = new SearchCondition<string>("InvoiceNumber");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["InvoiceNumber"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> TotalCollect
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TotalCollect"))
	  			{
	  				this.SubCriteria["TotalCollect"] = new SearchCondition<Decimal>("TotalCollect");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["TotalCollect"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> TotalInsurance
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TotalInsurance"))
	  			{
	  				this.SubCriteria["TotalInsurance"] = new SearchCondition<Decimal>("TotalInsurance");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["TotalInsurance"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> TotalDiscount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TotalDiscount"))
	  			{
	  				this.SubCriteria["TotalDiscount"] = new SearchCondition<Decimal>("TotalDiscount");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["TotalDiscount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> TotalWaitingAmount
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TotalWaitingAmount"))
	  			{
	  				this.SubCriteria["TotalWaitingAmount"] = new SearchCondition<Decimal>("TotalWaitingAmount");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["TotalWaitingAmount"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsCollectedInsurance
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("IsCollectedInsurance"))
	  			{
	  				this.SubCriteria["IsCollectedInsurance"] = new SearchCondition<bool>("IsCollectedInsurance");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["IsCollectedInsurance"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> CreatedUser
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreatedUser"))
	  			{
	  				this.SubCriteria["CreatedUser"] = new SearchCondition<string>("CreatedUser");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["CreatedUser"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> Deactivated
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("Deactivated"))
	  			{
	  				this.SubCriteria["Deactivated"] = new SearchCondition<bool>("Deactivated");
	  			}
	  			return (ISearchCondition<bool>)this.SubCriteria["Deactivated"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> TotalReceived
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TotalReceived"))
	  			{
	  				this.SubCriteria["TotalReceived"] = new SearchCondition<Decimal>("TotalReceived");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["TotalReceived"];
	  		}
	  	}
	  	
	  	public ISearchCondition<Decimal> TotalChanges
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("TotalChanges"))
	  			{
	  				this.SubCriteria["TotalChanges"] = new SearchCondition<Decimal>("TotalChanges");
	  			}
	  			return (ISearchCondition<Decimal>)this.SubCriteria["TotalChanges"];
	  		}
	  	}
	  	
	  	public ISearchCondition<string> ListProcedures
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("ListProcedures"))
	  			{
	  				this.SubCriteria["ListProcedures"] = new SearchCondition<string>("ListProcedures");
	  			}
	  			return (ISearchCondition<string>)this.SubCriteria["ListProcedures"];
	  		}
	  	}
	  	
	  	public ISearchCondition<DateTime> CreatedDate
	  	{
	  		get
	  		{
	  			if(!this.SubCriteria.ContainsKey("CreatedDate"))
	  			{
	  				this.SubCriteria["CreatedDate"] = new SearchCondition<DateTime>("CreatedDate");
	  			}
	  			return (ISearchCondition<DateTime>)this.SubCriteria["CreatedDate"];
	  		}
	  	}
	  	
	}
}
