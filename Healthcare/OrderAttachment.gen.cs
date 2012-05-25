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
    /// OrderAttachment component
    /// </summary>
	public sealed partial class OrderAttachment : ValueObject, IEquatable<OrderAttachment>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.OrderAttachmentCategoryEnum _category;
	  	
	  	private ClearCanvas.Healthcare.Staff _attachedBy;
	  	
	  	private DateTime _attachedTime;
	  	
	  	private ClearCanvas.Healthcare.Facility _clinic;
	  	
	  	private ClearCanvas.Healthcare.AttachedDocument _document;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public OrderAttachment()
	  	{
		 	
		  	_attachedTime = Platform.Time;
		  	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public OrderAttachment(ClearCanvas.Healthcare.OrderAttachmentCategoryEnum category1, ClearCanvas.Healthcare.Staff attachedby1, DateTime attachedtime1, ClearCanvas.Healthcare.Facility clinic1, ClearCanvas.Healthcare.AttachedDocument document1)
	  	{
		  	CustomInitialize();

			
		  	_category = category1;
		  	
		  	_attachedBy = attachedby1;
		  	
		  	_attachedTime = attachedtime1;
		  	
		  	_clinic = clinic1;
		  	
		  	_document = document1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.OrderAttachmentCategoryEnum Category
	  	{
			
			get { return _category; }
			
			
			set { _category = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.Staff AttachedBy
	  	{
			
			get { return _attachedBy; }
			
			
			set { _attachedBy = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public DateTime AttachedTime
	  	{
			
			get { return _attachedTime; }
			
			
			set { _attachedTime = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
	  	public ClearCanvas.Healthcare.Facility Clinic
	  	{
			
			get { return _clinic; }
			
			
			set { _clinic = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.AttachedDocument Document
	  	{
			
			get { return _document; }
			
			
			set { _document = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(OrderAttachment that)
		{
			return (that != null) &&
	  	
			((this._category == default(ClearCanvas.Healthcare.OrderAttachmentCategoryEnum)) ? (that._category == default(ClearCanvas.Healthcare.OrderAttachmentCategoryEnum)) : this._category.Equals(that._category)) &&
	  	
			((this._attachedBy == default(ClearCanvas.Healthcare.Staff)) ? (that._attachedBy == default(ClearCanvas.Healthcare.Staff)) : this._attachedBy.Equals(that._attachedBy)) &&
	  	
			((this._attachedTime == default(DateTime)) ? (that._attachedTime == default(DateTime)) : this._attachedTime.Equals(that._attachedTime)) &&
	  	
			((this._clinic == default(ClearCanvas.Healthcare.Facility)) ? (that._clinic == default(ClearCanvas.Healthcare.Facility)) : this._clinic.Equals(that._clinic)) &&
	  	
			((this._document == default(ClearCanvas.Healthcare.AttachedDocument)) ? (that._document == default(ClearCanvas.Healthcare.AttachedDocument)) : this._document.Equals(that._document)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as OrderAttachment);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_category == default(ClearCanvas.Healthcare.OrderAttachmentCategoryEnum) ? 0 : _category.GetHashCode()) ^
	  	
				(_attachedBy == default(ClearCanvas.Healthcare.Staff) ? 0 : _attachedBy.GetHashCode()) ^
	  	
				(_attachedTime == default(DateTime) ? 0 : _attachedTime.GetHashCode()) ^
	  	
				(_clinic == default(ClearCanvas.Healthcare.Facility) ? 0 : _clinic.GetHashCode()) ^
	  	
				(_document == default(ClearCanvas.Healthcare.AttachedDocument) ? 0 : _document.GetHashCode()) ^
	  	
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
			OrderAttachment clone = new OrderAttachment();
		
		
	  		clone._category = this._category;
		
	  		clone._attachedBy = this._attachedBy;
		
	  		clone._attachedTime = this._attachedTime;
		
	  		clone._clinic = this._clinic;
		
	  		clone._document = this._document;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("Category", _category);
		  	
		  	writer.WriteProperty("AttachedBy", _attachedBy);
		  	
		  	writer.WriteProperty("AttachedTime", _attachedTime);
		  	
		  	writer.WriteProperty("Clinic", _clinic);
		  	
		  	writer.WriteProperty("Document", _document);
		  	
		}

		#endregion
	}
}
