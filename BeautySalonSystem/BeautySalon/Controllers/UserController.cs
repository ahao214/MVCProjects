using BeautySalon.Comm.CommHelper;
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
        #region Get请求登录页面
        /// <summary>
        /// Get请求登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region Post发送验证请求
        /// <summary>
        /// Post发送验证请求
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string userName, string password, string imgcode)
        {
            if (string.IsNullOrEmpty(userName) || userName.Length == 0)
            {
                return Content("Fail");
            }
            if (string.IsNullOrEmpty(password) || password.Length == 0)
            {
                return Content("Fail");
            }
            if (string.IsNullOrEmpty(imgcode) || imgcode.Length == 0)
            {
                return Content("Fail");
            }
            if (Session["CheckCode"] == null)
            {
                return Content("Fail");
            }
            if (!Session["CheckCode"].ToString().Equals(imgcode))
            {
                return Content("Fail");
            }

            return Content("OK");
        }
        #endregion




        #region 显示验证码 

        /// <summary>
        /// 显示验证码
        /// </summary>
        public void VerifyCode()
        {
            ImageVerifyCode imageVerify = new ImageVerifyCode();
            imageVerify.ValidateCode();
            string code = Session["CheckCode"].ToString();
        }

        #endregion




    }
}