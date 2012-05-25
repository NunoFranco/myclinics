using System;
using System.Collections;
using System.Text;

namespace ClearCanvas.Healthcare.Hibernate
{
    /// <summary>
    /// NHibernate mapping class for <see cref="VisitStatusEnum enumeration"/>.
    /// This file is machine generated - changes will be lost.
    /// </summary>
    public class VisitStatusEnumHbm : NHibernate.Type.EnumStringType
    {
        public VisitStatusEnumHbm()
            : base(typeof(VisitStatus))
        {
        }
    }
}
