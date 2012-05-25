using System;
using System.Collections.Generic;
using System.Text;

namespace ClearCanvas.Common
{
    public class GetReportSettings
    {
        
            public static string HospitalName { get; set; }
            public static string ReportTitile { get; set; }
            public static string Address { get; set; }
            public static string Phone { get; set; }
            public static string Website { get; set; }
            public static string ImageLogoPath { get; set; }
            public static string HospitalInfoDirName { get; set; }
            public static string ReportURL { get; set; }
            public static string ViewStudyHistoryTemplateURL { get; set; }
            public static bool IsLoaded { get; set; }
        
            public static void LoadSetting()
            {
                IsLoaded = true;
                CommonReportSetting rptSetting = new CommonReportSetting();
                HospitalName = rptSetting.HospitalName;
                ReportTitile = rptSetting.ReportTitile;
                Phone = rptSetting.Phone;
                Website = rptSetting.Website;
                string hospitalInfoFolder = rptSetting.HospitalInfoDirName.Replace('/', '\\');
                hospitalInfoFolder = hospitalInfoFolder.EndsWith("\\") ? hospitalInfoFolder : hospitalInfoFolder + ("\\");
                ImageLogoPath = hospitalInfoFolder + rptSetting.LogoImage;
                ReportURL = hospitalInfoFolder + rptSetting.ReportUrl;
                ViewStudyHistoryTemplateURL = hospitalInfoFolder + rptSetting.ViewStudyhistoryTemplate;
                Address = rptSetting.Address;
            }
        
    }
}
