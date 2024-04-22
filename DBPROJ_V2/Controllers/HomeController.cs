using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DBPROJ_V2.Models;

namespace DBPROJ_V2.Controllers
{
    public class HomeController : Controller
    {
        Database db = new Database();

        public HomeController(ILogger<HomeController> logger)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        public void LoginForm([Bind]Cred credentials, string userType)
        {
            var uType = string.IsNullOrEmpty(userType) ? "" : userType.ToLower();
            switch(uType)
            {
                case "admin":
                    Console.WriteLine("Admin");
                    break;
                case "mem":
                    Console.WriteLine("Member");
                    break;
                case "trn":
                    Console.WriteLine("Trainer");
                    break;
                case "own":
                    Console.WriteLine("Owner");
                    break;
            }
            bool flag = db.validateLogin(credentials, uType);
            if (flag)
            {
                TempData["msg"] = "Login Successful!";
            }
            else
            {
                TempData["msg"] = "Login Failed!";
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // LOGIN LOGIC USING FORM

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var reqId = Activity.Current == null ? HttpContext.TraceIdentifier : Activity.Current.Id;
            return View(new ErrorViewModel { RequestId = reqId });
        }
    }
}
