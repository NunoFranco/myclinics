using System;
using System.Collections;
using System.Text;

namespace ClearCanvas.Healthcare.Hibernate
{
    /// <summary>
    /// NHibernate mapping class for <see cref="ProcedureStatusEnum enumeration"/>.
    /// This file is machine generated - changes will be lost.
    /// </summary>
    public class ProcedureStatusEnumHbm : NHibernate.Type.EnumStringType
    {
        public ProcedureStatusEnumHbm()
            : base(typeof(ProcedureStatus))
        {
        }
    }
}
