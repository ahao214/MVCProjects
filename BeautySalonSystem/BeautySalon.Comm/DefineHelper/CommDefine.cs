using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BeautySalon.Comm.DefineHelper
{
    /// <summary>
    /// 公共函数
    /// </summary>
    public sealed class CommDefine
    {
        #region 获取客户端的IP地址
        /// <summary>
        /// 获取客户端的IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetClientIP()
        {
            string clientIP = string.Empty;
            // 分代理和不代理,代理分普通匿名,高级匿名
            clientIP = HttpContext.Current.Request.ServerVariables["HTTP_VIA"] == null ? HttpContext.Current.Request.UserHostAddress : HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            return clientIP;
        }
        #endregion

    }
}
