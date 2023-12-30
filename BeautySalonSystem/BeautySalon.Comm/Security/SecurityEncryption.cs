using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Comm.Security
{
    /// <summary>
    /// MD5加密(静态类)
    /// </summary>
    public static class SecurityEncryption
    {
        #region 扩展方法MD5加密
        /// <summary>
        /// 扩展方法MD5加密
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>返回MD5加密字符串</returns>
        public static string StringToMdFive(this string str)
        {
            MD5 mdFive = new MD5CryptoServiceProvider();
            byte[] bytes = mdFive.ComputeHash(Encoding.Default.GetBytes(str));
            return BitConverter.ToString(bytes).Replace("-", "");
        } 
        #endregion

    }
}
