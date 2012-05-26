using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClearCanvas.Common;
namespace ClearCanvas.Ris.Billing.View.WinForms.reports
{
    public class LoadHospitalInfo
    {
        static Byte[] LoadImage(string Path)
        {

            //System.Data.DataTable dt = new System.Data.DataTable();
            //System.Data.DataColumn col = new System.Data.DataColumn();
            //dt.Columns.Add("logo", System.Type.GetType("System.Byte[]"));

            try
            {
                if (Path != null && System.IO.File.Exists(Path))
                {
                    //System.Data.DataRow row = dt.NewRow();
                    System.IO.FileStream f = new System.IO.FileStream(Path, System.IO.FileMode.Open);
                    System.IO.BinaryReader br = new System.IO.BinaryReader(f);
                    byte[] buf = br.ReadBytes((int)f.Length);
                    //row[0] = buf;
                    //dt.Rows.Add(row);
                    br.Close();
                    f.Close();
                    return buf;
                }
                else
                {
                    //Platform.Log(LogLevel.Error, "Logo could Not be Found : " + Path);
                }
            }
            catch (Exception ex)
            {
                //Platform.Log(LogLevel.Error, ex.Message + "\n" + ex.StackTrace);
                throw ex;
            }
            return null;
        }
        public static DataTable GetHospitalInfoDataSource()
        {

            System.Data.DataTable dt = new DataTable();// LoadReportComponent.LoadImage(_component.ImageLogoPath);
            dt.Columns.Add("logo", System.Type.GetType("System.Byte[]"));
            dt.Columns.Add("Address", Type.GetType("System.String"));
            dt.Columns.Add("Phone", Type.GetType("System.String"));
            dt.Columns.Add("WebSite", Type.GetType("System.String"));
            dt.Columns.Add("HospitalName", Type.GetType("System.String"));
            if (!GetReportSettings.IsLoaded)
                GetReportSettings.LoadSetting();
            System.Data.DataRow row = dt.NewRow();
            row["logo"] = LoadImage(GetReportSettings.ImageLogoPath);
            row["Address"] = GetReportSettings.Address;
            row["Phone"] = GetReportSettings.Phone;
            row["WebSite"] = GetReportSettings.Website;
            row["HospitalName"] = GetReportSettings.HospitalName;

            dt.Rows.Add(row);
            return dt;
        }
    }
}
