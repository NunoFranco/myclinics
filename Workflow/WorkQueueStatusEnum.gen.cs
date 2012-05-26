// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Workflow
{

    /// <summary>
    /// WorkQueueStatusEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class WorkQueueStatusEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected WorkQueueStatusEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public WorkQueueStatusEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}