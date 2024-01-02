using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        #region 判断输入的是否为汉字
        /// <summary>
        /// 判断输入的是否为汉字
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsChinese(string val)
        {
            return Regex.IsMatch(val, @"^[\u4e00-\u9fa5]{2,10}$");
        }

        #endregion


    }
}
