using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astec.Common
{
    public class ExecuteStoreProcedures
    {
        private static string ConnString = ConfigurationManager.ConnectionStrings["AstecConnection"].ConnectionString;

        public string ExecuteStoredProcedure(string procedureName)
        {
            SqlConnection sqlConnObj = new SqlConnection(ConnString);
            sqlConnObj.Open();
            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            //Lấy ra id
            object obj = sqlCmd.ExecuteScalar();

            //sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();
            return obj.ToString();
        }

        /// <summary>
        /// Lấy ra id để insert cho từng bảng
        /// </summary>
        /// <param name="tableName">tên bảng</param>
        /// <param name="tableId">tên id của bảng</param>
        /// <param name="codeIdTable">chuỗi kí tự đầu của id ngăn cách bằng dấu _</param>
        /// <param name="_longidtable">độ dài của id</param>
        /// <returns></returns>
        public string GetID(string tableName, string tableId, string codeIdTable, int _longidtable)// tên bảng, tên ID bảng , mã để gắn ào ID bảng, chiều dài của ID bảng: 20
        {
            string _querySql = "select ISNULL(max(cast(RIGHT(" + tableId + ",5)as int)),0) +1 as max from " + tableName;
            string _ID = "";
            DataTable dt = InsertResidentID(_querySql);
            if (dt.Rows.Count > 0)
            {
                int _max = int.Parse(dt.Rows[0]["max"].ToString());
                string teamp = _max.ToString();
                while (teamp.Length < _longidtable - (codeIdTable).Length)
                {
                    teamp = "0" + teamp;
                }
                _ID = codeIdTable + teamp;
            }
            return _ID;
        }

        /// <summary>
        /// Thực thi câu lệnh sql
        /// </summary>
        /// <param name="_querySql"></param>
        /// <returns></returns>
        public DataTable InsertResidentID(string _querySql)
        {
            SqlConnection sqlConnObj = new SqlConnection(ConnString);
            try
            {
              
                sqlConnObj.Open();

                SqlDataAdapter _adapter = new SqlDataAdapter(String.Format(_querySql), sqlConnObj);
                DataTable _dataTable = new DataTable();
                _adapter.Fill(_dataTable);

                return _dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnObj.Close();
            }
        }
    }
}
