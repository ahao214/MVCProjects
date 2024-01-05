using BeautySalon.DataDAL.SqlHelperFile;
using BeautySalon.DataDAL.TableDAL;
using BeautySalon.Models.TableModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.LogicBLL.TableBLL
{
    /// <summary>
    /// 项目业务逻辑类
    /// </summary>
    public class ProjectBLL
    {
        #region 添加项目
        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool AddProject(Project input)
        {
            return ProjectDAL.AddProject(input);
        }

        #endregion

    }
}
