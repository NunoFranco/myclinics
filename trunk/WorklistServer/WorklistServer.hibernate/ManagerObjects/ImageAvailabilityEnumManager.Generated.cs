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
		// Get Methods
    }

    partial class ImageAvailabilityEnumManager : ManagerBase<ImageAvailabilityEnum, string>, IImageAvailabilityEnumManager
    {
		#region Constructors
		
		public ImageAvailabilityEnumManager() : base()
        {
        }
        public ImageAvailabilityEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}