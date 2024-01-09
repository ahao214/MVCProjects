using BeautySalon.Comm.JsonHelper;
using BeautySalon.Filter;
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
    /// 项目控制器
    /// </summary>
    [BeautySalonFilter] //加特性
    public class ProjectController : Controller
    {
        #region 返回json结果变量
        /// <summary>
        /// 返回json结果变量
        /// </summary>
        private readonly BsJsonResult bsJsonResult = new BsJsonResult();
        #endregion

        #region 业务逻辑

        /// <summary>
        /// 业务逻辑
        /// </summary>
        private readonly ProjectBLL projectBLL = new ProjectBLL();

        #endregion

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

        #region 添加项目业务逻辑(根目录)
        /// <summary>
        /// 添加项目业务逻辑(根目录)
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ProjectAdd(Project project)
        {
            return Content(CheckProject(project));
        }
        /// <summary>
        /// 输入返回值
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        private string CheckProject(Project project)
        {
            string projectName = project.ProjectName;
            if (string.IsNullOrEmpty(projectName) || projectName.Length == 0)
            {
                return bsJsonResult.ErrorResult("分类名称至少一个字符");
            }
            if (!projectBLL.AddProject(project))
            {
                return bsJsonResult.ErrorResult("添加项目失败");
            }
            return bsJsonResult.SuccessResult("添加项目成功");
        }


        #endregion







    }
}