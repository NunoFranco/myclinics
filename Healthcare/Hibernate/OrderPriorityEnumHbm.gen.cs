using System;
using System.Collections;
using System.Text;

namespace ClearCanvas.Healthcare.Hibernate
{
    /// <summary>
    /// NHibernate mapping class for <see cref="OrderPriorityEnum enumeration"/>.
    /// This file is machine generated - changes will be lost.
    /// </summary>
    public class OrderPriorityEnumHbm : NHibernate.Type.EnumStringType
    {
        public OrderPriorityEnumHbm()
            : base(typeof(OrderPriority))
        {
        }
    }
}
