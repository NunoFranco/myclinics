using System;
using System.Collections;
using System.Text;

namespace ClearCanvas.Material.Healthcare.Hibernate
{
    /// <summary>
    /// NHibernate mapping class for <see cref="TransactionTypeEnum enumeration"/>.
    /// This file is machine generated - changes will be lost.
    /// </summary>
    public class TransactionTypeEnumHbm : NHibernate.Type.EnumStringType
    {
        public TransactionTypeEnumHbm()
            : base(typeof(StockTransactionType))
        {
        }
    }
}
