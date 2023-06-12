using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace Assignment_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        ///myName 路徑的GET請求
        public IActionResult MyName()
        {
        // cookies取得user name
            string userName = Request.Cookies["UserName"];

            if (!string.IsNullOrEmpty(userName))
            {
            // 如果可以取得，則回傳view
                ViewBag.UserName = userName;
            }
            // 如果無法從 cookies 中獲取使用者名字，則導向到輸入名字的表單頁面
            return View();
        }

        public IActionResult EnterName()
        {
            return View();
        }

        //trackName 路徑的POST請求
        [HttpPost]
        public IActionResult TrackName(string name)
        {
        // user name存到cookies中
            Response.Cookies.Append("UserName", name);

        // 重定到 myName
            return RedirectToAction("MyName");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
