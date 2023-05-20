using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using Session_Cookie.Models;
using Session_Cookie.ViewModels;

namespace Session_Cookie.Controllers
{
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM model)
        {
            List<User> dbUsers = GetAll();
            var findUserByEmail = dbUsers.FirstOrDefault(m => m.Email == model.Email);
            if (findUserByEmail == null)
            {
                ViewBag.error = "Email or password is wrong";
                return View();
            }

            if(findUserByEmail.Password != model.Password)
            {
                ViewBag.error = "Email or password is wrong";
                return View();
            }

            HttpContext.Session.SetString("user", JsonSerializer.Serialize(findUserByEmail));    
            
            return RedirectToAction("Index","Home");


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


        private List<User> GetAll()
        {
            User user1 = new()
            {
                Id = 1,
                UserName = "anarmh",
                Email = "anar@gmail.com",
                Password = "anar12345"
            };
            User user2 = new()
            {
                Id = 1,
                UserName = "elnar123",
                Email = "elnar@gmail.com",
                Password = "elnar12345"
            };
            User user3 = new()
            {
                Id = 1,
                UserName = "tunarmh",
                Email = "tunar@gmail.com",
                Password = "tunar12345"
            };
            List<User> users = new List<User>() { user1, user2, user3 };
            return users;
        }
    }
}
