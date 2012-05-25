// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Healthcare
{

    /// <summary>
    /// ReportStatusEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class ReportStatusEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected ReportStatusEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public ReportStatusEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}