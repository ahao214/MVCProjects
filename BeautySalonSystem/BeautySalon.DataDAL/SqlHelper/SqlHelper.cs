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
        #region 创建连接数据库对象
        /// <summary>
        /// 创建连接数据库对象
        /// </summary>
        private static readonly string ConnStrings = ConfigurationManager.ConnectionStrings["BeautySalonDataConn"].ConnectionString;
        #endregion

        #region 创建SqlConnection对象
        /// <summary>
        /// 创建SqlConnection对象
        /// </summary>
        /// <returns></returns>
        private static SqlConnection CreateConn()
        {
            return new SqlConnection(ConnStrings);
        }

        #endregion

        #region 创建SqlCommand对象
        /// <summary>
        /// 创建SqlCommand对象
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="trans"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        private static SqlCommand CreateCommand(SqlConnection conn, string sql, int cmdType, SqlTransaction trans, params SqlParameter[] paras)
        {
            if (conn is null) throw new ArgumentNullException("程序异常");
            SqlCommand cmd = new SqlCommand(sql, conn);
            if(cmdType ==2)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            if(conn .State !=ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            if(paras !=null && paras.Length >0)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddRange(paras);
            }
            return cmd;

        }

        #endregion

        #region

        public static DataTable GetDataTable(string sql, int cmdType, params SqlParameter[] paras)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = CreateConn())
            {
                SqlCommand cmd = CreateCommand(conn, sql, 1, null, paras);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        #endregion
    }
}
