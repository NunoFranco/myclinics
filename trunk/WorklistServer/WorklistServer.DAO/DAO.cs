using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace WorklistServer.DAO
{
  

    public class DAO
    {
        private string _strConn { get; set; }
        public Dictionary<string,string> parameters { get; set; }

        public DAO(string connectionString)
        {
            _strConn = connectionString;
            parameters = new Dictionary<string, string>();
        }

        public DataTable LoadWorklist()
        {
            
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conn = new SqlConnection(_strConn);
                conn.Open();
                //string procedure = "Exec GetWorklist @Mod,@PatientName,@AccessionNumber,@PatientID";
                string procName="GetWorklist";
                SqlCommand cmd = new SqlCommand(procName,conn);
                cmd.CommandText = procName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Mod", parameters["Mod"]));
                cmd.Parameters.Add(new SqlParameter("@PatientName", parameters["PatientName"]));
                cmd.Parameters.Add(new SqlParameter("@AccessionNumber", parameters["AccessionNumber"]));
                cmd.Parameters.Add(new SqlParameter("@PatientID", parameters["PatientID"]));
                //cmd.Parameters.Add(new SqlParameter("Mod", ""));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
