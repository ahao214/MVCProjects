using BeautySalon.Comm.DefineHelper;
using BeautySalon.Comm.JsonHelper;
using BeautySalon.Filter;
using BeautySalon.LogicBLL.TableBLL;
using BeautySalon.Models.TableModel;
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