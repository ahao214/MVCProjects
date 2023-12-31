using Newtonsoft.Json;

namespace BeautySalon.Comm.JsonHelper
{
    /// <summary>
    /// 扩展方法(字符转JSON)
    /// </summary>
    public static class BsJsonHelper
    {
        public static string StringToJson(this BsJsonResult jsonResult)
        {
            return JsonConvert.SerializeObject(jsonResult);

        }


    }
}
