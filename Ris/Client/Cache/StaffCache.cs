using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin;
using ClearCanvas.Common;
namespace ClearCanvas.Ris.Client.Cache
{
    public class StaffCache : ClientCacheBase
    {
        List<StaffSummary> _allStaff;
        string AllActiveStaffCacheKey = "StaffCacheAllActiveStaff";
        public List<StaffSummary> AllActiveStaff
        {
            get
            {
                if (CacheData.ContainsKey(AllActiveStaffCacheKey))
                {
                    return (List<StaffSummary>)CacheData[AllActiveStaffCacheKey];
                }
                AddAllStaffCache();
                return _allStaff;
            }

        }

        public void AddAllStaffCache()
        {
            List<StaffSummary> f = new List<StaffSummary>();
            Platform.GetService<ClearCanvas.Ris.Application.Common.Admin.StaffAdmin.IStaffAdminService>
                (service => f = service.ListStaff (new ClearCanvas.Ris.Application.Common.Admin.StaffAdmin.ListStaffRequest ()).Staffs );
            _allStaff = f;
            AddCache(AllActiveStaffCacheKey, _allStaff);
        }
        public override void Refesh()
        {
            Clear(AllActiveStaffCacheKey);
            AddAllStaffCache();
        }
    }

}
