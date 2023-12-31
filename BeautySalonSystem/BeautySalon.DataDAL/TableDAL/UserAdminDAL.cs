
using BeautySalon.Comm.Security;
using BeautySalon.DataDAL.SqlHelperFile;
using BeautySalon.Models.TableModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BeautySalon.DataDAL.TableDAL
{
    /// <summary>
    /// 用户数据访问类
    /// </summary>
    public abstract class UserAdminDAL
    {

        #region 得到用户信息(根据用户名和密码)
        /// <summary>
        /// 得到用户信息(根据用户名和密码)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static UserAdmin GetUserAdmin(UserAdmin input)
        {
            UserAdmin userAdmin = default;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM UserAdmin WHERE UserName=@UserName AND Password=@Password AND UserStatus=1");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserName",input.UserName),
                new SqlParameter ("@Password",input.Password.StringToMdFive())
            };

            DataTable dt = SqlHelper.GetDataTable(sb.ToString(), 1, paras);
            foreach (DataRow dr in dt.Rows)
            {
                userAdmin = new UserAdmin
                {
                    UserId = (int)dr["UserId"],
                    UserName = dr["UserName"].ToString(),
                    Password = dr["Password"].ToString(),
                };
            }
            return userAdmin;
        }
        #endregion

        #region 登录成功后,更新用户登录的IP地址
        /// <summary>
        /// 登录成功后,更新用户登录的IP地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool UpdateLoginIP(UserAdmin input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE UserAdmin SET LoginIP=@LoginIP WHERE UserId=@UserId");
            SqlParameter[] paras =
            {
                new SqlParameter ("@LoginIP",input .LoginIP),
                new SqlParameter ("@UserId",input .UserId ),
            };

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;
        }

        #endregion


    }
}
