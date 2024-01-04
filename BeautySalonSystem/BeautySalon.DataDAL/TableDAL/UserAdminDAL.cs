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
            sb.Append("SELECT * FROM UserAdmin WHERE UserId=@UserId AND UserStatus=1 AND IsDelete = 0");

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
                    UserName = Convert.ToString(dr["UserName"]),
                    Password = Convert.ToString(dr["Password"]),
                    RealName = Convert.ToString(dr["RealName"]),
                    Telphone = Convert.ToString(dr["Telphone"]),
                    LoginIP = Convert.ToString(dr["LoginIP"]),
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
            sb.Append("SELECT * FROM UserAdmin WHERE IsDelete = 0 ORDER BY UserId ASC");

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
                    LoginIP = Convert.ToString(dr["LoginIP"]),
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

        #region 添加用户
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool AddUserAdmin(UserAdmin input)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO UserAdmin(UserName,Password,Telphone,UserStatus) VALUES(@UserName,@Password,@Telphone,@UserStatus)");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserName",input.UserName),
                new SqlParameter ("@Password",input.Password.StringToMdFive()),
                new SqlParameter ("@Telphone",input.Telphone),
                new SqlParameter ("@UserStatus",1),
            };

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;
        }

        #endregion


        #region 更新用户状态
        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public static bool UpdateUserStatusById(UserAdmin userAdmin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE UserAdmin SET UserStatus=ABS(UserStatus-1),ModifyTime=@ModifyTime WHERE UserId=@UserId");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserId",userAdmin.UserId),
                new SqlParameter ("@ModifyTime",DateTime.Now)
            };

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;
        }
        #endregion


        #region 软删除用户
        /// <summary>
        /// 软删除用户
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public static bool SofteDelete(UserAdmin userAdmin)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE UserAdmin SET IsDelete=ABS(IsDelete-1),ModifyTime=@ModifyTime WHERE UserId=@UserId");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserId",userAdmin.UserId),
                new SqlParameter ("@ModifyTime",DateTime.Now)
            };

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;
        }
        #endregion

        #region 软删除用户
        /// <summary>
        /// 软删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SofteDelUserById(int userId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE UserAdmin SET IsDelete=ABS(IsDelete-1),ModifyTime=@ModifyTime WHERE UserId=@UserId");

            SqlParameter[] paras =
            {
                new SqlParameter ("@UserId",userId),
                new SqlParameter ("@ModifyTime",DateTime.Now)
            };

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;
        }
        #endregion


        #region 软删除用户
        /// <summary>
        /// 软删除用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool SofteDelAllUser(string[] ids)
        {
            string userIds = string.Empty;
            int count = ids.Length;
            SqlParameter[] paras = new SqlParameter[count];
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    userIds += "@UserId" + i;
                }
                else
                {
                    userIds += "@UserId" + i + ",";
                }
                // 构建SqlParameter
                paras[i] = new SqlParameter("@UserId" + i, Convert.ToInt32(ids[i]));
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE UserAdmin SET IsDelete=ABS(IsDelete-1) WHERE UserId in (" + userIds + ")");

            return SqlHelper.ExecuteNoneQuery(sb.ToString(), 1, paras) > 0;
        }
        #endregion



    }
}
