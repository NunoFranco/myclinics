using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare
{
    public class OrderInvoicesSearchCriteria : EntitySearchCriteria<OrderInvoices>
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


		
        //public ISearchCondition<string> ClassCode
        //{
        //    get
        //    {
        //        if(!this.SubCriteria.ContainsKey("ClassCode"))
        //        {
        //            this.SubCriteria["ClassCode"] = new SearchCondition<string>("ClassCode");
        //        }
        //        return (ISearchCondition<string>)this.SubCriteria["ClassCode"];
        //    }
        //}
	  	
	  	public ISearchCondition<string> InvoiceNumber
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("InvoiceNumber"))
	  			{
                    this.SubCriteria["InvoiceNumber"] = new SearchCondition<string>("InvoiceNumber");
	  			}
                return (ISearchCondition<string>)this.SubCriteria["InvoiceNumber"];
	  		}
	  	}

        public ISearchCondition<Order> InvoiceOrder
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("InvoiceOrder"))
	  			{
                    this.SubCriteria["InvoiceOrder"] = new SearchCondition<Order>("InvoiceOrder");
	  			}
                return (ISearchCondition<Order>)this.SubCriteria["InvoiceOrder"];
	  		}
	  	}
	  	
	  	public ISearchCondition<bool> IsFinished
	  	{
	  		get
	  		{
                if (!this.SubCriteria.ContainsKey("IsFinished"))
	  			{
                    this.SubCriteria["IsFinished"] = new SearchCondition<bool>("IsFinished");
	  			}
                return (ISearchCondition<bool>)this.SubCriteria["IsFinished"];
	  		}
	  	}
        public ISearchCondition<string> ListProcedures
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("ListProcedures"))
                {
                    this.SubCriteria["ListProcedures"] = new SearchCondition<string>("ListProcedures");
                }
                return (ISearchCondition<string>)this.SubCriteria["ListProcedures"];
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
        public ISearchCondition<DateTime> CreatedDate
        {
            get
            {
                if (!this.SubCriteria.ContainsKey("CreatedDate"))
                {
                    this.SubCriteria["CreatedDate"] = new SearchCondition<DateTime>("CreatedDate");
                }
                return (ISearchCondition<DateTime>)this.SubCriteria["CreatedDate"];
            }
        }
    }
}
