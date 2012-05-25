// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// ImageAvailabilityEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class ImageAvailabilityEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected ImageAvailabilityEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public ImageAvailabilityEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}