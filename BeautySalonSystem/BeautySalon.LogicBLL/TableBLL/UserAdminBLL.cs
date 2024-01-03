using BeautySalon.Models.TableModel;
using BeautySalon.DataDAL.TableDAL;
using BeautySalon.DataDAL.SqlHelperFile;
using System.Data.SqlClient;
using System.Text;
using System;
using System.Collections.Generic;
using System.Data;

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

        #region 更新用户密码
        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public bool UpdateUserPwd(UserAdmin userAdmin)
        {
            return UserAdminDAL.UpdateUserPwd(userAdmin);
        }
        #endregion

        #region 获取所有用户信息
        /// <summary>
        /// 获取所有用户信息
        /// </summary>        
        /// <returns></returns>
        public List<UserAdmin> GetUserAdmin()
        {
            return UserAdminDAL.GetUserAdmin();

        }
        #endregion

        #region 根据用户名得到用户
        /// <summary>
        /// 根据用户名得到用户
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public UserAdmin GetUserAdminByUserName(UserAdmin userAdmin)
        {
            return UserAdminDAL.GetUserAdminByUserName(userAdmin);
        }

        #endregion

    }
}
