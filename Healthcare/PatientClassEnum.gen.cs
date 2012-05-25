// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// PatientClassEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class PatientClassEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected PatientClassEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public PatientClassEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}