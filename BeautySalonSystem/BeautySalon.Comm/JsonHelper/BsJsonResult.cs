using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Comm.JsonHelper
{
    /// <summary>
    /// Ajax请求后返回的json格式数据
    /// </summary>
    public class BsJsonResult
    {
        private JsonResultType resultType;
        private string msg;

        public BsJsonResult()
        {

        }

        public BsJsonResult(JsonResultType _resultType, string _msg)
        {
            resultType = _resultType;
            msg = _msg;
        }

        public string SuccessResult(string msg = "登录成功")
        {
            return new BsJsonResult(JsonResultType.Success, msg).StringToJson();
        }

        public string WrongCodeResult(string msg = "验证码错误")
        {
            return new BsJsonResult(JsonResultType.WrongCode, msg).StringToJson();
        }

        public string FailResult(string msg = "登录失败")
        {
            return new BsJsonResult(JsonResultType.Error, msg).StringToJson();
        }
    }

    #region 枚举返回JSON数据类型

    public enum JsonResultType
    {
        Success = 1,
        WrongCode = 2,
        Error = 3
    }

    #endregion


}
