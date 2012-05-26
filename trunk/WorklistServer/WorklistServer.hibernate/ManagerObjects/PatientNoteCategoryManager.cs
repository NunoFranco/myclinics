using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IPatientNoteCategoryManager : IManagerBase<PatientNoteCategory, System.Guid>
    {
	}
	
	partial class PatientNoteCategoryManager : ManagerBase<PatientNoteCategory, System.Guid>, IPatientNoteCategoryManager
    {
	}
}