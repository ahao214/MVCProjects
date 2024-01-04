using BeautySalon.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautySalon.Controllers
{
    /// <summary>
    /// 项目控制器
    /// </summary>
    [BeautySalonFilter] //加特性
    public class ProjectController : Controller
    {
        #region 返回项目分类视图页面
        /// <summary>
        /// 返回项目分类视图页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        } 
        #endregion



    }
}