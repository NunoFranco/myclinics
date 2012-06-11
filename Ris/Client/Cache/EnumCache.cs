using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin;
using ClearCanvas.Ris.Application.Common.Admin.EnumerationAdmin;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
namespace ClearCanvas.Ris.Client.Cache
{
    public class EnumCache<T> : ClientCacheBase
    {
        List<EnumValueInfo> _allEnum;
        string AllActiveEnumCacheKey = "EnumCacheAll" + typeof(T).Name;
        public List<EnumValueInfo> AllActiveEnum
        {
            get
            {
                if (CacheData.ContainsKey(AllActiveEnumCacheKey))
                {
                    return (List<EnumValueInfo>)CacheData[AllActiveEnumCacheKey];
                }
                AddAllEnumCache();
                return _allEnum;
            }

        }
        public List<EnumValueAdminInfo> AllAdminActiveEnum
        {
            get
            {
                List<EnumValueInfo> tmp = new List<EnumValueInfo>();
                if (! CacheData.ContainsKey(AllActiveEnumCacheKey))
                {
                     AddAllEnumCache();
                }
                tmp = (List<EnumValueInfo>)CacheData[AllActiveEnumCacheKey];
                return CollectionUtils.Map<EnumValueInfo, EnumValueAdminInfo>(tmp, delegate(EnumValueInfo value)
                {
                    return new EnumValueAdminInfo(value.OID, value.Code, value.Value, value.Description, false, value.ClinicOID);
                });
            }

        }
        public void AddAllEnumCache()
        {
            List<EnumerationSummary> enums;
            List<EnumValueAdminInfo> f = new List<EnumValueAdminInfo>();
            Platform.GetService<ClearCanvas.Ris.Application.Common.Admin.EnumerationAdmin.IEnumerationAdminService>
                (service =>
                {
                    enums = service.ListEnumerations(new ListEnumerationsRequest()).Enumerations;

                    f = service.ListEnumerationValues(new ClearCanvas.Ris.Application.Common.Admin.EnumerationAdmin.ListEnumerationValuesRequest ()).Values;

                });
            
            AddCache(AllActiveEnumCacheKey, _allEnum);
        }
        public override void Refesh()
        {
            Clear(AllActiveEnumCacheKey);
            AddAllEnumCache();
        }
    }

}
