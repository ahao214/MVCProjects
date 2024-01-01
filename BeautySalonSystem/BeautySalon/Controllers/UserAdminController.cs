using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace BeautySalon.Controllers
{
    public class UserAdminController : Controller
    {
        // GET: UserAdmin
        public ActionResult AccountInfo()
        {
            return View();
        }

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