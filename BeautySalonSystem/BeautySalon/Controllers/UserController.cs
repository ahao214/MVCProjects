using BeautySalon.Comm.CommHelper;
using BeautySalon.LogicBLL.TableBLL;
using BeautySalon.Models.TableModel;
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
        #region 业务逻辑

        /// <summary>
        /// 业务逻辑(用户)
        /// </summary>
        private readonly UserAdminBLL userAdminBLL = new UserAdminBLL();

        #endregion



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
        public ActionResult Login(UserAdmin userAdmin)
        {
            return Content(CheckUserInfo(userAdmin));
        }
        #endregion

        #region 验证返回值
        /// <summary>
        /// 验证返回值
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        private string CheckUserInfo(UserAdmin userAdmin)
        {
            string userName = userAdmin.UserName;
            string password = userAdmin.Password;
            string imgcode = userAdmin.ImgCode;
            if (string.IsNullOrEmpty(userName) || userName.Length == 0)
            {
                return "Fail";
            }
            if (string.IsNullOrEmpty(password) || password.Length == 0)
            {
                return "Fail";
            }
            if (string.IsNullOrEmpty(imgcode) || imgcode.Length == 0)
            {
                return "Fail";
            }
            if (Session["CheckCode"] is null)
            {
                return "Fail";
            }
            if (!Session["CheckCode"].ToString().Equals(imgcode, StringComparison.InvariantCultureIgnoreCase))
            {
                return "WrongCode";
            }
            if (userAdminBLL.GetUserAdmin(userAdmin) is null)
            {
                return "Fail";
            }
            return "OK";
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