using BeautySalon.Filter;
using BeautySalon.LogicBLL.TableBLL;
using BeautySalon.Models.TableModel;
using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    [BeautySalonFilter] // 特性
    public class UserAdminController : Controller
    {
        #region 业务逻辑(用户)
        /// <summary>
        /// 业务逻辑(用户)
        /// </summary>
        private readonly UserAdminBLL userAdminBLL = new UserAdminBLL();
        #endregion


        #region 登录账户信息
        /// <summary>
        /// 登录账户信息
        /// </summary>
        /// <returns></returns>
        public ActionResult AccountInfo()
        {
            UserAdmin userAdmin = new UserAdmin();
            if (!(Session["LoginUser"] is null))
            {
                userAdmin = Session["LoginUser"] as UserAdmin;
            }
            userAdmin = userAdminBLL.GetUserAdminById(userAdmin.UserId);

            return View(userAdmin);
        }
        #endregion

        #region 修改密码
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult ModifyPass()
        {
            return View();
        }
        #endregion

        #region 退出登录
        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            Session["LoginUser"] = null;
            Session.Clear();
            return base.Redirect("/");
        }
        #endregion

    }
}