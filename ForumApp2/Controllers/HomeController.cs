using System.Diagnostics;
using ForumApp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp2.Controllers
{
    /// <summary>
	/// PostController inherits Controller class 
	/// gives you access to Request, Response, ViewBag, ViewData, View, etc.
	/// </summary>
    public class HomeController : Controller
    {
        /// <summary>
		/// value of _logger is passed by constructor
		/// _logger keeps record of errors
		/// using interface for best practices
		/// </summary>
        private readonly ILogger<HomeController> _logger;

        /// <summary>
		/// using dependancy injection through constructor
		/// </summary>
		/// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
