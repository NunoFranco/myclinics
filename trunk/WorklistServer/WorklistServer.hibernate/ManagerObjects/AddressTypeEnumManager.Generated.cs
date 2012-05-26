using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface IAddressTypeEnumManager : IManagerBase<AddressTypeEnum, string>
    {
		// Get Methods
    }

    partial class AddressTypeEnumManager : ManagerBase<AddressTypeEnum, string>, IAddressTypeEnumManager
    {
		#region Constructors
		
		public AddressTypeEnumManager() : base()
        {
        }
        public AddressTypeEnumManager(INHibernateSession session) : base(session)
        {
        }
		
		#endregion
		
        #region Get Methods

		
		#endregion
    }
}