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

        public IActionResult LoginForm(string userType)
        {
            var uType = string.IsNullOrEmpty(userType) ? "" : userType.ToLower();
            return View();
        }

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
