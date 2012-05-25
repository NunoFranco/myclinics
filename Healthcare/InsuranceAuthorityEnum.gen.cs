// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// InsuranceAuthorityEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class InsuranceAuthorityEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected InsuranceAuthorityEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public InsuranceAuthorityEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}