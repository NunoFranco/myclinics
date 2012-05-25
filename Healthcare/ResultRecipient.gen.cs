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
    /// ResultRecipient component
    /// </summary>
	public sealed partial class ResultRecipient : ValueObject, IEquatable<ResultRecipient>, IAuditFormattable
	{
       	#region Private fields
       	
		
	  	private ClearCanvas.Healthcare.ExternalPractitionerContactPoint _practitionerContactPoint;
	  	
	  	private ClearCanvas.Healthcare.ResultCommunicationModeEnum _preferredCommunicationMode;
	  	
	  	
	  	#endregion
	  	
	  	#region Constructors
	  	
	  	/// <summary>
	  	/// Default no-args constructor required by NHibernate
	  	/// </summary>
	  	public ResultRecipient()
	  	{
		 	
		  	
		  	CustomInitialize();
	  	}

		
	  	/// <summary>
	  	/// All fields constructor
	  	/// </summary>
	  	public ResultRecipient(ClearCanvas.Healthcare.ExternalPractitionerContactPoint practitionercontactpoint1, ClearCanvas.Healthcare.ResultCommunicationModeEnum preferredcommunicationmode1)
	  	{
		  	CustomInitialize();

			
		  	_practitionerContactPoint = practitionercontactpoint1;
		  	
		  	_preferredCommunicationMode = preferredcommunicationmode1;
		  	
	  	}
		
                
	  	#endregion
	  	
	  	#region Public Properties
	  	
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.ExternalPractitionerContactPoint PractitionerContactPoint
	  	{
			
			get { return _practitionerContactPoint; }
			
			
			set { _practitionerContactPoint = value; }
			
	  	}
		
	  	
		
		
		[PersistentProperty]
		[Required]
	  	public ClearCanvas.Healthcare.ResultCommunicationModeEnum PreferredCommunicationMode
	  	{
			
			get { return _preferredCommunicationMode; }
			
			
			set { _preferredCommunicationMode = value; }
			
	  	}
		
	  	
	  	
	  	#endregion
	  	
	  	#region IEquatable methods
	  	
	  	public bool Equals(ResultRecipient that)
		{
			return (that != null) &&
	  	
			((this._practitionerContactPoint == default(ClearCanvas.Healthcare.ExternalPractitionerContactPoint)) ? (that._practitionerContactPoint == default(ClearCanvas.Healthcare.ExternalPractitionerContactPoint)) : this._practitionerContactPoint.Equals(that._practitionerContactPoint)) &&
	  	
			((this._preferredCommunicationMode == default(ClearCanvas.Healthcare.ResultCommunicationModeEnum)) ? (that._preferredCommunicationMode == default(ClearCanvas.Healthcare.ResultCommunicationModeEnum)) : this._preferredCommunicationMode.Equals(that._preferredCommunicationMode)) &&
	  	
				true;
		}
	  	
	  	#endregion
	  	
	  	#region Object overrides
	  	
	  	public override bool Equals(object that)
		{
			return this.Equals(that as ResultRecipient);
		}
		
		public override int GetHashCode()
		{
			return
	  	
				(_practitionerContactPoint == default(ClearCanvas.Healthcare.ExternalPractitionerContactPoint) ? 0 : _practitionerContactPoint.GetHashCode()) ^
	  	
				(_preferredCommunicationMode == default(ClearCanvas.Healthcare.ResultCommunicationModeEnum) ? 0 : _preferredCommunicationMode.GetHashCode()) ^
	  	
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
			ResultRecipient clone = new ResultRecipient();
		
		
	  		clone._practitionerContactPoint = this._practitionerContactPoint;
		
	  		clone._preferredCommunicationMode = this._preferredCommunicationMode;
		
			return clone;
        }
		
		#region IAuditFormattable Members

		void IAuditFormattable.Write(IObjectWriter writer)
		{
			
		  	writer.WriteProperty("PractitionerContactPoint", _practitionerContactPoint);
		  	
		  	writer.WriteProperty("PreferredCommunicationMode", _preferredCommunicationMode);
		  	
		}

		#endregion
	}
}
