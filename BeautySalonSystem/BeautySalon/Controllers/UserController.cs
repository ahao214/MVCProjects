using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }


        #region 显示验证码 
        /// <summary>
        /// 显示验证码
        /// </summary>
        public void VerifyCode()
        {

        }

        #endregion




    }
}