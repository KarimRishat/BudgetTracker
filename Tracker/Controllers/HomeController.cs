using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using Tracker.Models;

namespace Tracker.Controllers
{
    //[Authorize(Roles ="admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMemoryCache _cache;


        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            string userName = null;
            string loggedInUsername = _cache.Get<string>("Username");

            if (Request.Cookies["UserName"] != null)
            {
                userName = Request.Cookies["UserName"];
            }

            ViewData["LoggedInUsername"] = loggedInUsername;

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
