using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Common
{
    public class InsertIdBySequences
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["AstecConnection"].ConnectionString;
        public string GetId(string sequence)
        {
            SqlCommand cmdTime = null;
            SqlConnection sqlConnObj = new SqlConnection(ConnString);
            string result = "";
            try
            {
                
                if (ConnString == null)
                    return result;
                sqlConnObj.Open();
                string sql = "select next value for "+sequence;
                cmdTime = new SqlCommand(sql, sqlConnObj);
                using (SqlDataReader aread = cmdTime.ExecuteReader())
                {
                    if (aread.HasRows)
                    {
                        if (aread.Read())
                        {
                            result = aread[0].ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                if (cmdTime != null)
                    cmdTime.Dispose();
                sqlConnObj.Close();
            }
            return result;
        }

        public string GetLastID(string sequence)
        {
            string gid = GetId(sequence);
            string defaultval = "0000000000000000000";

            string lastId = "GOLD1_" + defaultval.Substring(0, defaultval.Length - gid.Length) + gid;
            return lastId;
        }
    }
}
