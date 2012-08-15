// This file is machine generated - changes will be lost.
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;


namespace ClearCanvas.Material.Healthcare
{

    /// <summary>
    /// StockTransactionTypeEnum enumeration
    /// </summary>
	[UniqueKey("Code", new[] { "Code","Value","Clinic.Code"})]
    
    public class StockTransactionTypeEnum : EnumValue
    {
		/// <summary>
		/// Default constructor.
		/// </summary>
		protected StockTransactionTypeEnum()
		{
		}
		
		/// <summary>
		/// Constructor for creating dummy values during unit testing. Not for production use.
		/// </summary>
		public StockTransactionTypeEnum(string code, string value, string description)
			:base(code, value, description)
		{
		}
    }
}