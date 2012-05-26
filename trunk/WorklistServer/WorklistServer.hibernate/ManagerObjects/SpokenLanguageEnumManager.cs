using System;
using System.Collections.Generic;
using System.Text;

using NHibernate;
using WorklistServer.hibernate.BusinessObjects;
using WorklistServer.hibernate.Base;

namespace WorklistServer.hibernate.ManagerObjects
{
    public partial interface ISpokenLanguageEnumManager : IManagerBase<SpokenLanguageEnum, string>
    {
	}
	
	partial class SpokenLanguageEnumManager : ManagerBase<SpokenLanguageEnum, string>, ISpokenLanguageEnumManager
    {
	}
}