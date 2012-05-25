// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// ProtocolRejectReasonEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class ProtocolRejectReasonEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected ProtocolRejectReasonEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public ProtocolRejectReasonEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}