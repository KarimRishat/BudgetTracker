using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tracker.Models;

namespace Tracker.Controllers
{
    //[Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string userName = null;

            if (Request.Cookies["UserName"] != null)
            {
                userName = Request.Cookies["UserName"];
            }

            if (Request.Query.Keys.Contains("role"))
            {
                var t = Request.Query["role"].ToString();
                @ViewData["role"] = t;
                HttpContext.Session.SetString("role", t);
            }

            if (HttpContext.Session.Keys.Contains("UserName"))
            {
                var t = HttpContext.Session.GetString("UserName");
                @ViewData["UserName"] = t;
            }

            ViewBag.UserName = userName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
