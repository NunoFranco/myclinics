using System;
using System.Collections;
using System.Text;

namespace ClearCanvas.Healthcare.Hibernate
{
    /// <summary>
    /// NHibernate mapping class for <see cref="OrderStatusEnum enumeration"/>.
    /// This file is machine generated - changes will be lost.
    /// </summary>
    public class OrderStatusEnumHbm : NHibernate.Type.EnumStringType
    {
        public OrderStatusEnumHbm()
            : base(typeof(OrderStatus))
        {
        }
    }
}
