using BeautySalon.Comm.Security;
using BeautySalon.DataDAL.SqlHelperFile;
using BeautySalon.Models.TableModel;
using System;
using System.Collections.Generic;
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

        #region 得到用户信息(根据用户ID)
        /// <summary>
        /// 得到用户信息(根据用户ID)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static UserAdmin GetUserAdminById(int userId)
        {
            UserAdmin userAdmin = default;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM UserAdmin WHERE UserId=@UserId AND UserStatus=1");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserId",userId)
            };

            DataTable dt = SqlHelper.GetDataTable(sb.ToString(), 1, paras);
            foreach (DataRow dr in dt.Rows)
            {
                userAdmin = new UserAdmin
                {
                    UserId = (int)dr["UserId"],
                    UserName = (string)dr["UserName"],
                    Password = (string)dr["Password"],
                    RealName = (string)dr["RealName"],
                    Telphone = (string)dr["Telphone"],
                    LoginIP = (string)dr["LoginIP"],
                    LoginTime = (DateTime)dr["LoginTime"],
                    ModifyTime = (DateTime)dr["ModifyTime"],
                    Salary = (decimal)dr["Salary"],
                    UserStatus = (int)dr["UserStatus"],
                };
            }
            return userAdmin;
        }
        #endregion

        #region 更新用户信息
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public static bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE UserAdmin SET RealName=@RealName,Telphone=@Telphone,ModifyTime=@ModifyTime WHERE UserId=@UserId AND UserStatus=1");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserId",userAdmin.UserId),
                new SqlParameter ("@RealName",userAdmin.RealName),
                new SqlParameter ("@Telphone",userAdmin.Telphone),
                new SqlParameter ("@ModifyTime",DateTime.Now)
            };

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;

        }
        #endregion

        #region 更新用户密码
        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public static bool UpdateUserPwd(UserAdmin userAdmin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE UserAdmin SET Password=@Password,ModifyTime=@ModifyTime WHERE UserId=@UserId AND UserStatus=1");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserId",userAdmin.UserId),
                new SqlParameter ("@Password",userAdmin.Password.StringToMdFive()),
                new SqlParameter ("@ModifyTime",DateTime.Now)
            };

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;
        }
        #endregion

        #region 获取所有用户信息
        /// <summary>
        /// 获取所有用户信息
        /// </summary>        
        /// <returns></returns>
        public static List<UserAdmin> GetUserAdmin()
        {
            UserAdmin userAdmin = default;
            List<UserAdmin> list = new List<UserAdmin>();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM UserAdmin ORDER BY UserId ASC");

            DataTable dt = SqlHelper.GetDataTable(sb.ToString(), 1);
            foreach (DataRow dr in dt.Rows)
            {
                userAdmin = new UserAdmin
                {
                    UserId = (int)dr["UserId"],
                    UserName = (string)dr["UserName"],
                    Password = (string)dr["Password"],
                    RealName = (string)dr["RealName"],
                    Telphone = (string)dr["Telphone"],
                    LoginIP = (string)dr["LoginIP"],
                    LoginTime = (DateTime)dr["LoginTime"],
                    ModifyTime = (DateTime)dr["ModifyTime"],
                    Salary = (decimal)dr["Salary"],
                    UserStatus = (int)dr["UserStatus"],
                };
                list.Add(userAdmin);
            }
            return list;
        }
        #endregion

        #region 根据用户名得到用户
        /// <summary>
        /// 根据用户名得到用户
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public static UserAdmin GetUserAdminByUserName(UserAdmin userAdmin)
        {
            UserAdmin result = default;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT UserName FROM UserAdmin WHERE UserName=@UserName");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserName",userAdmin.UserName)
            };

            DataTable dt = SqlHelper.GetDataTable(sb.ToString(), 1, paras);
            foreach (DataRow dr in dt.Rows)
            {
                result = new UserAdmin
                {
                    UserName = (string)dr["UserName"]
                };
            }
            return result;
        }

        #endregion

        #region 根据手机号得到用户
        /// <summary>
        /// 根据手机号得到用户
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public static UserAdmin GetUserAdminByTelphone(UserAdmin userAdmin)
        {
            UserAdmin result = default;
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT Telphone FROM UserAdmin WHERE Telphone=@Telphone");

            SqlParameter[] paras =
            {
                new SqlParameter ("@Telphone",userAdmin.Telphone)
            };

            DataTable dt = SqlHelper.GetDataTable(sb.ToString(), 1, paras);
            foreach (DataRow dr in dt.Rows)
            {
                result = new UserAdmin
                {
                    Telphone = (string)dr["Telphone"]
                };
            }
            return result;
        }

        #endregion

    }
}
