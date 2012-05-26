using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ITranscriptionRejectReasonEnumManager : IManagerBase<TranscriptionRejectReasonEnum, string>
    {
	}
	
	partial class TranscriptionRejectReasonEnumManager : ManagerBase<TranscriptionRejectReasonEnum, string>, ITranscriptionRejectReasonEnumManager
    {
	}
}