﻿using BeautySalon.Filter;
using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    [BeautySalonFilter] // 特性
    public class UserAdminController : Controller
    {
        // GET: UserAdmin
        public ActionResult AccountInfo()
        {
            return View();
        }

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