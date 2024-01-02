using Newtonsoft.Json;

namespace BeautySalon.Comm.JsonHelper
{
   
    public static class BsJsonHelper
    {
        /// <summary>
        /// 扩展方法(字符转JSON)
        /// </summary>
        public static string StringToJson(this BsJsonResult jsonResult)
        {
            return JsonConvert.SerializeObject(jsonResult);
        }
    }
}
