using BeautySalon.Models.TableModel;
using BeautySalon.DataDAL.TableDAL;
using BeautySalon.DataDAL.SqlHelperFile;
using System.Data.SqlClient;
using System.Text;
using System;

namespace BeautySalon.LogicBLL.TableBLL
{
    /// <summary>
    /// 用户业务逻辑类
    /// </summary>
    public sealed class UserAdminBLL
    {
        #region 得到用户信息(根据用户名和密码)
        /// <summary>
        /// 得到用户信息(根据用户名和密码)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public UserAdmin GetUserAdmin(UserAdmin input)
        {
            return UserAdminDAL.GetUserAdmin(input);
        }
        #endregion

        #region 登录成功后,更新用户登录的IP地址
        /// <summary>
        /// 登录成功后,更新用户登录的IP地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool UpdateLoginIP(UserAdmin input)
        {
            return UserAdminDAL.UpdateLoginIP(input);
        }

        #endregion

        #region 得到用户信息(根据用户ID)
        /// <summary>
        /// 得到用户信息(根据用户ID)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public UserAdmin GetUserAdminById(int userId)
        {
            return UserAdminDAL.GetUserAdminById(userId);
        }
        #endregion

        #region 更新用户信息
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool UpdateUserAdmin(UserAdmin userAdmin)
        {
            return UserAdminDAL.UpdateUserAdmin(userAdmin);
        }
        #endregion





    }
}
