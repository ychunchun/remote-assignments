using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Assignment_1.Data;

namespace YourProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                // 空值處理
                user.Email ??= string.Empty;
                user.Password ??= string.Empty;

                // 檢查是否有相同的電子郵件
                var existingUser = _dbContext.user.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser == null)
                {
                    _dbContext.user.Add(user);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Welcome");
                }
            }
            ViewBag.ErrorMessage = "該電子郵件已經被註冊過了。";
            return View("Index");
        }

        [HttpPost]
        public IActionResult SignIn(User user)
        {
            if (ModelState.IsValid)
            {
                user.Email ??= string.Empty;
                user.Password ??= string.Empty;

                // 檢查電子郵件和密碼是否匹配
                var existingUser = _dbContext.user.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (existingUser != null)
                {
                    return RedirectToAction("Welcome");
                }
            }
            ViewBag.ErrorMessage = "電子郵件或密碼錯誤。";
            return View("Index");
        }

        public IActionResult Welcome()
        {
            return View();
        }
    }


}
