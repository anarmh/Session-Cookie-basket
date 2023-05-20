﻿using Microsoft.AspNetCore.Mvc;
using Session_Cookie.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Session_Cookie.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            //HttpContext.Session.SetInt32("age",36);
            //HttpContext.Session.SetString("name", "Anar");
            //Response.Cookies.Append("surname", "Huseynov",new CookieOptions { MaxAge=TimeSpan.FromMinutes(20)});
            // Book book1 = new()
            // {
            //     Id = 1,
            //     Name = "Shikayetname",
            //     Author = "Fuzuli"
            // };
            //var serializedObject=JsonSerializer.Serialize(book1);

            // HttpContext.Session.SetString("book", serializedObject);


            if (HttpContext.Session.GetString("user") != null)
            {
                User user=JsonSerializer.Deserialize<User>(HttpContext.Session.GetString("user"));
                ViewBag.username = user.UserName;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            //ViewBag.age = HttpContext.Session.GetInt32("age");
            //ViewBag.name = HttpContext.Session.GetString("name");
            //ViewBag.surname = Request.Cookies["surname"];

            //var model = JsonSerializer.Deserialize<Book>(HttpContext.Session.GetString("book"));
            return View();
        }
        //class Book
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Author { get; set; }
        ////}
       
    }
}