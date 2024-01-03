using BeautySalon.Comm.DefineHelper;
using BeautySalon.Comm.JsonHelper;
using BeautySalon.Filter;
using BeautySalon.LogicBLL.TableBLL;
using BeautySalon.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    [BeautySalonFilter] // 特性
    public class UserAdminController : Controller
    {
        #region 返回json结果变量
        /// <summary>
        /// 返回json结果变量
        /// </summary>
        private readonly BsJsonResult bsJsonResult = new BsJsonResult();
        #endregion

        #region 业务逻辑(用户)
        /// <summary>
        /// 业务逻辑(用户)
        /// </summary>
        private readonly UserAdminBLL userAdminBLL = new UserAdminBLL();
        #endregion

        #region 登录账户信息页面
        /// <summary>
        /// 登录账户信息页面
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

        #region 发送资料更新验证
        /// <summary>
        /// 发送资料更新验证
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public ActionResult UpdateAccount(UserAdmin userAdmin)
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
            string realName = userAdmin.RealName;
            string telephone = userAdmin.Telphone;
            userAdmin.UserId = ((UserAdmin)(Session["LoginUser"])).UserId;
            if (string.IsNullOrEmpty(realName) || realName.Length == 0)
            {
                return bsJsonResult.ErrorResult("真实姓名必须为汉字");
            }
            if (!CommDefine.IsChinese(realName))
            {
                return bsJsonResult.ErrorResult("真实姓名必须为汉字");
            }
            if (!CommDefine.IsPhone(telephone))
            {
                return bsJsonResult.ErrorResult("手机号必须是11位");
            }
            if (!userAdminBLL.UpdateUserAdmin(userAdmin))
            {
                return bsJsonResult.ErrorResult("更新失败");
            }
            return bsJsonResult.SuccessResult("资料更新成功");
        }

        #endregion

        #region 修改密码页面
        /// <summary>
        /// 修改密码页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ModifyPass()
        {
            UserAdmin userAdmin = default;
            if (!(Session["LoginUser"] is null))
            {
                userAdmin = Session["LoginUser"] as UserAdmin;
            }
            return View(userAdmin);
        }
        #endregion

        #region 密码验证
        /// <summary>
        /// 密码验证
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        public ActionResult UpdatePwd(UserAdmin userAdmin)
        {
            return Content(CheckPassword(userAdmin));
        }

        #endregion

        #region 验证返回值
        /// <summary>
        /// 验证返回值
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        private string CheckPassword(UserAdmin userAdmin)
        {
            string password = userAdmin.Password;
            string rePassword = userAdmin.RePassword;
            userAdmin.UserId = ((UserAdmin)(Session["LoginUser"])).UserId;
            if (string.IsNullOrEmpty(password))
            {
                return bsJsonResult.ErrorResult("密码不能为空");
            }
            if (password.Length < 6 || password.Length > 12)
            {
                return bsJsonResult.ErrorResult("密码必须6到12位");
            }
            if (!password.Equals(rePassword))
            {
                return bsJsonResult.ErrorResult("两次密码不一致");
            }

            if (!userAdminBLL.UpdateUserPwd(userAdmin))
            {
                return bsJsonResult.ErrorResult("密码更新失败");
            }
            return bsJsonResult.SuccessResult("密码更新成功");
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

        #region 返回管理员视图界面
        /// <summary>
        /// 返回管理员视图界面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminList()
        {
            List<UserAdmin> userAdmins = userAdminBLL.GetUserAdmin();

            return View(userAdmins);
        }

        #endregion

        #region 添加管理员视图页面
        /// <summary>
        /// 添加管理员视图页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult AddUserAdmin()
        {
            return View();
        }

        #endregion

        #region 添加管理员视图页面
        /// <summary>
        /// 添加管理员视图页面
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddUserAdmin(UserAdmin userAdmin)
        {
            return Content(CheckAddUser(userAdmin));
        }

        #endregion

        #region 验证添加用户的返回值
        /// <summary>
        /// 验证添加用户的返回值
        /// </summary>
        /// <param name="userAdmin"></param>
        /// <returns></returns>
        private string CheckAddUser(UserAdmin userAdmin)
        {
            string userName = userAdmin.UserName;
            string telephone = userAdmin.Telphone;
            string password = userAdmin.Password;
            string repass = userAdmin.RePassword;

            userAdmin.UserId = ((UserAdmin)(Session["LoginUser"])).UserId;
            if (string.IsNullOrEmpty(userName) || userName.Length < 5 || userName.Length > 12)
            {
                return bsJsonResult.ErrorResult("登录名必须在5到12位之间");
            }

            if (!CommDefine.IsPhone(telephone))
            {
                return bsJsonResult.ErrorResult("手机号必须是11位");
            }
            if (string.IsNullOrEmpty(password))
            {
                return bsJsonResult.ErrorResult("密码不能为空");
            }
            if (password.Length > 12 || password.Length < 6)
            {
                return bsJsonResult.ErrorResult("密码必须在6到12位");
            }
            if (!repass.Equals(password))
            {
                return bsJsonResult.ErrorResult("两次密码输入不一致");
            }
            if (!(userAdminBLL.GetUserAdminByUserName(userAdmin) is null))
            {
                return bsJsonResult.ErrorResult("该用户已经存在");
            }
            if (!(userAdminBLL.GetUserAdminByTelphone(userAdmin) is null))
            {
                return bsJsonResult.ErrorResult("该手机号已经存在");
            }
            if (!userAdminBLL.AddUserAdmin(userAdmin))
            {
                return bsJsonResult.ErrorResult("用户添加失败");
            }
            return bsJsonResult.SuccessResult("用户添加成功");
        }

        #endregion

        #region 编辑管理员视图页面
        /// <summary>
        /// 编辑管理员视图页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult EditUserAdmin(string userId)
        {
            // 先对UserId进行验证
            if (!CommDefine.IsDigital(userId))
            {
                return RedirectToAction("Index", "Error", new { ErrorMessage = "传递参数不合法" });
            }
            UserAdmin userAdmin = userAdminBLL.GetUserAdminById(Convert.ToInt32(userId));
            if (userAdmin is null)
            {
                return RedirectToAction("Index", "Error", new { ErrorMessage = "查询不到相关信息" });
            }
            return View(userAdmin);
        }

        #endregion

    }
}