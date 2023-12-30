using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.DataDAL.SqlHelper
{
    /// <summary>
    /// 抽象数据库帮助类
    /// </summary>
    public abstract class SqlHelper
    {
        #region 
        /// <summary>
        /// 
        /// </summary>
        private static readonly string ConnStrings = ConfigurationManager.ConnectionStrings["BeautySalonDataConn"].ConnectionString;
        #endregion

        #region 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static SqlConnection CreateConn()
        {
            return new SqlConnection(ConnStrings);
        }

        #endregion

        #region

        public static DataTable GetDataTable(string sql, int cmdType, params SqlParameter[] cmdParms)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = CreateConn())
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        #endregion
    }
}
