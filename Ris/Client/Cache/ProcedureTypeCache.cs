using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.Admin;
using ClearCanvas.Common;
using ClearCanvas.Healthcare;
namespace ClearCanvas.Ris.Client.Cache
{
    public class ProcedureTypeCache : ClientCacheBase
    {
        List<ProcedureTypeSummary> _allProcedureType;
        string AllActiveProcedureTypeCacheKey = "ProcedureTypeCacheAllActiveProcedureType";
        public List<ProcedureTypeSummary> AllActiveProcedureType
        {
            get
            {

                if (CacheData.ContainsKey(AllActiveProcedureTypeCacheKey))
                {

                    return (List<ProcedureTypeSummary>)CacheData[AllActiveProcedureTypeCacheKey];
                }
                AddAllProcedureTypeCache();
                return _allProcedureType;
            }

        }
        public List<ProcedureTypeSummary> AllOrderRequiredProcedureType
        {
            get
            {
                var q = (from t in AllActiveProcedureType where t.IsRequired  == true select t).ToList();
                return q;
            }
        }
        public List<ProcedureTypeSummary> AllPerformingProcedureType
        {
            get
            {
                var q = (from t in AllActiveProcedureType where t.Category.Code == ProcedureTypeCategory.PRO.ToString() select t).ToList();
                return q;
            }
        }

        public List<ProcedureTypeSummary> AllMedicines
        {
            get
            {
                var q = (from t in AllActiveProcedureType where t.Category.Code == ProcedureTypeCategory.ME.ToString() select t).ToList();
                return q;
            }
        }

        public List<ProcedureTypeSummary> AllEqipment
        {
            get
            {
                var q = (from t in AllActiveProcedureType where t.Category.Code == ProcedureTypeCategory.EQ.ToString() select t).ToList();
                return q;
            }
        }

        public List<ProcedureTypeSummary> AllEqipment_Medicines
        {
            get
            {
                var q = (from t in AllActiveProcedureType where (t.Category.Code == ProcedureTypeCategory.ME.ToString() || t.Category.Code == ProcedureTypeCategory.EQ.ToString()) select t).ToList();
                return q;
            }
        }

        public void AddAllProcedureTypeCache()
        {
            List<ProcedureTypeSummary> f = new List<ProcedureTypeSummary>();
            ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin.ListProcedureTypesRequest request = new ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin.ListProcedureTypesRequest();
            request.ClinicRef = LoginSession.Current.WorkingFacility.FacilityRef;
            request.Category = ProcedureTypeCategory.ALL;
            request.IncludeDeactivated = false;
            
            Platform.GetService<ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin.IProcedureTypeAdminService>
                (service => f = service.ListProcedureTypes(request ).ProcedureTypes );
            _allProcedureType = f;
            AddCache(AllActiveProcedureTypeCacheKey, _allProcedureType);
        }
        public override void Refesh()
        {
            Clear(AllActiveProcedureTypeCacheKey);
            AddAllProcedureTypeCache();
        }
    }

}
