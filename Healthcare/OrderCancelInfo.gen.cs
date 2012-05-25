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
    /// OrderCancelInfo component
    /// </summary>
	public sealed partial class OrderCancelInfo : ValueObject, IEquatable<OrderCancelInfo>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.OrderCancelReasonEnum _reason;
	  	
	  	private ClearCanvas.Healthcare.Staff _cancelledBy;
	  	
	  	private string _comment;
	  	
	  	private ClearCanvas.Healthcare.Order _replacementOrder;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public OrderCancelInfo()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public OrderCancelInfo(ClearCanvas.Healthcare.OrderCancelReasonEnum reason1, ClearCanvas.Healthcare.Staff cancelledby1, string comment1, ClearCanvas.Healthcare.Order replacementorder1)
	  	{
		  	CustomInitialize();

			
		  	_reason = reason1;
		  	
		  	_cancelledBy = cancelledby1;
		  	
		  	_comment = comment1;
		  	
		  	_replacementOrder = replacementorder1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.OrderCancelReasonEnum Reason
	  	{
			
			get { return _reason; }
			
			
			set { _reason = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.Staff CancelledBy
	  	{
			
			get { return _cancelledBy; }
			
			
			set { _cancelledBy = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public string Comment
	  	{
			
			get { return _comment; }
			
			
			set { _comment = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.Order ReplacementOrder
	  	{
			
			get { return _replacementOrder; }
			
			
			set { _replacementOrder = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(OrderCancelInfo that)
		{
			return (that != null) &&
	  	
			((this._reason == default(ClearCanvas.Healthcare.OrderCancelReasonEnum)) ? (that._reason == default(ClearCanvas.Healthcare.OrderCancelReasonEnum)) : this._reason.Equals(that._reason)) &&
	  	
			((this._cancelledBy == default(ClearCanvas.Healthcare.Staff)) ? (that._cancelledBy == default(ClearCanvas.Healthcare.Staff)) : this._cancelledBy.Equals(that._cancelledBy)) &&
	  	
			((this._comment == default(string)) ? (that._comment == default(string)) : this._comment.Equals(that._comment)) &&
	  	
			((this._replacementOrder == default(ClearCanvas.Healthcare.Order)) ? (that._replacementOrder == default(ClearCanvas.Healthcare.Order)) : this._replacementOrder.Equals(that._replacementOrder)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as OrderCancelInfo);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_reason == default(ClearCanvas.Healthcare.OrderCancelReasonEnum) ? 0 : _reason.GetHashCode()) ^
	  	
				(_cancelledBy == default(ClearCanvas.Healthcare.Staff) ? 0 : _cancelledBy.GetHashCode()) ^
	  	
				(_comment == default(string) ? 0 : _comment.GetHashCode()) ^
	  	
				(_replacementOrder == default(ClearCanvas.Healthcare.Order) ? 0 : _replacementOrder.GetHashCode()) ^
	  	
				0;
		}
				
	  	#endregion
	  	
	  	/// <summary>
	  	/// Returns a clone of this object.  A deep-copy is performed, so the clone will not share
	  	/// any mutable data with this object.
	  	/// NB. Note that collections are not currently supported.  If this object contains collections
	  	/// they will not be cloned.  It should be relatively easy to add collection support when the need arises.
	  	/// </summary>
        public override object Clone()
        {
			OrderCancelInfo clone = new OrderCancelInfo();
		
		
	  		clone._reason = this._reason;
		
	  		clone._cancelledBy = this._cancelledBy;
		
	  		clone._comment = this._comment;
		
	  		clone._replacementOrder = this._replacementOrder;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Reason", _reason);
		  	
		  	writer.WriteProperty("CancelledBy", _cancelledBy);
		  	
		  	writer.WriteProperty("Comment", _comment);
		  	
		  	writer.WriteProperty("ReplacementOrder", _replacementOrder);
		  	
		}

		#endregion
	}
}
