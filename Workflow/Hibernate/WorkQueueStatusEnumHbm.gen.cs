using System;
using System.Collections;
using System.Text;

namespace ClearCanvas.Workflow.Hibernate
{
    /// <summary>
    /// NHibernate mapping class for <see cref="WorkQueueStatusEnum enumeration"/>.
    /// This file is machine generated - changes will be lost.
    /// </summary>
    public class WorkQueueStatusEnumHbm : NHibernate.Type.EnumStringType
    {
        public WorkQueueStatusEnumHbm()
            : base(typeof(WorkQueueStatus))
        {
        }
    }
}
