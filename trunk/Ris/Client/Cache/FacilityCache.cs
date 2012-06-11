using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin;
using ClearCanvas.Common;
namespace ClearCanvas.Ris.Client.Cache
{
    public class FacilityCache : ClientCacheBase
    {
        List<FacilitySummary> _allFacility;
        string AllActiveFacilityCacheKey = "FacilittyCacheAllActiveFacility";
        public List<FacilitySummary> AllActiveFacility
        {
            get
            {

                if (CacheData.ContainsKey(AllActiveFacilityCacheKey))
                {
                   
                    return (List<FacilitySummary>)CacheData[AllActiveFacilityCacheKey];
                }
                AddAllFacilityCache();
                return _allFacility;
            }

        }

        public void AddAllFacilityCache()
        {
            List<FacilitySummary> f=new List<FacilitySummary>();
            Platform.GetService<ClearCanvas.Ris.Application.Common.Admin.FacilityAdmin.IFacilityAdminService>
                (service=>f=service.ListAllFacilities(new ClearCanvas.Ris.Application.Common.Admin.FacilityAdmin.ListAllFacilitiesRequest()).Facilities);
            _allFacility = f;
            AddCache(AllActiveFacilityCacheKey,_allFacility );
        }

        public override void Refesh()
        {
            Clear(AllActiveFacilityCacheKey);
            AddAllFacilityCache();
        }
    }

}
