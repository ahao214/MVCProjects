using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    /// <summary>
    /// 商店
    /// </summary>
    public class StoreController : Controller
    {
        // 列出商店中的唱片分类
        public string Index()
        {
            return "Hello from store.index()";
        }

        // 浏览商店中某个分类中的唱片列表
        public string Browse(string genre)
        {
            return "Store.Browse,Genre=" + genre;

        }

        // 显示特定唱片的详细信息
        public string Details(int id)
        {
            return "hello from store.details(),id=" + id;
        }
    }
}