using BeautySalon.Comm.CommHelper;
using BeautySalon.Comm.DefineHelper;
using BeautySalon.Comm.JsonHelper;
using BeautySalon.LogicBLL.TableBLL;
using BeautySalon.Models.TableModel;
using System;
using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    /// <summary>
    /// 用户控制器
    /// </summary>
    public class UserController : Controller
    {

        #region 返回json结果变量
        /// <summary>
        /// 返回json结果变量
        /// </summary>
        private readonly BsJsonResult bsJsonResult = new BsJsonResult();
        #endregion

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
                return bsJsonResult.ErrorResult();
                //return "Fail";
            }
            if (string.IsNullOrEmpty(password) || password.Length == 0)
            {
                return bsJsonResult.ErrorResult();
                //return "Fail";
            }
            if (string.IsNullOrEmpty(imgcode) || imgcode.Length == 0)
            {
                return bsJsonResult.ErrorResult();
                //return "Fail";
            }
            if (Session["CheckCode"] is null)
            {
                return bsJsonResult.ErrorResult();
                //return "Fail";
            }
            if (!Session["CheckCode"].ToString().Equals(imgcode, StringComparison.InvariantCultureIgnoreCase))
            {
                return bsJsonResult.WrongCodeResult();
                //return "WrongCode";
            }
            UserAdmin successAdmin = userAdminBLL.GetUserAdmin(userAdmin);
            if (successAdmin is null)
            {
                return bsJsonResult.ErrorResult();
                //return "Fail";
            }
            // 登录成功后,获取用户登录的IP地址
            successAdmin.LoginIP = CommDefine.GetClientIP();
            if(!userAdminBLL.UpdateLoginIP(successAdmin ))
            {
                return bsJsonResult.ErrorResult();
                //return "Fail";
            }
            Session["LoginUser"] = successAdmin;
            return bsJsonResult.SuccessResult();
            
            //return "OK";
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