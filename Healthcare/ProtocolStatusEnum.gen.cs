// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// ProtocolStatusEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class ProtocolStatusEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected ProtocolStatusEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public ProtocolStatusEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}