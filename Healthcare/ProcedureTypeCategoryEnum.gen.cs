// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// ProcedureTypeCategoryEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class ProcedureTypeCategoryEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected ProcedureTypeCategoryEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public ProcedureTypeCategoryEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}