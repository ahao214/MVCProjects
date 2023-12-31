using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.Models.TableModel;
using BeautySalon.DataDAL.TableDAL;
using BeautySalon.DataDAL.SqlHelperFile;

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


    }
}
