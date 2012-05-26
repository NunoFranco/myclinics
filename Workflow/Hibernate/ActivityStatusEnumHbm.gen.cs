using System;
using System.Collections;
using System.Text;

namespace ClearCanvas.Workflow.Hibernate
{
    /// <summary>
    /// NHibernate mapping class for <see cref="ActivityStatusEnum enumeration"/>.
    /// This file is machine generated - changes will be lost.
    /// </summary>
    public class ActivityStatusEnumHbm : NHibernate.Type.EnumStringType
    {
        public ActivityStatusEnumHbm()
            : base(typeof(ActivityStatus))
        {
        }
    }
}
