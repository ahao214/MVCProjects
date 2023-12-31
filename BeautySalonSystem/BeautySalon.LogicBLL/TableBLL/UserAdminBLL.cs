using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautySalon.Models.TableModel;
using BeautySalon.DataDAL.TableDAL;

namespace BeautySalon.LogicBLL.TableBLL
{
    /// <summary>
    /// 用户信息业务逻辑层
    /// </summary>
    public class UserAdminBLL
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

    }
}
