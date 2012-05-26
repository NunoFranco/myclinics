using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IImageAvailabilityEnumManager : IManagerBase<ImageAvailabilityEnum, string>
    {
	}
	
	partial class ImageAvailabilityEnumManager : ManagerBase<ImageAvailabilityEnum, string>, IImageAvailabilityEnumManager
    {
	}
}