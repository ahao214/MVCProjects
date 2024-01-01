using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    /// <summary>
    /// 使用该控制器，做权限验证，其他控制继承该控制器即可进行权限验证
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 权限验证
            // 如果Session是null，则跳转到登录页面
            // 后台权限验证
            if (filterContext.HttpContext.Session["LoginUser"] is null)
            {
                filterContext.HttpContext.Response.Redirect("/");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}