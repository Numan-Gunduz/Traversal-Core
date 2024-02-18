using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			_logger.LogInformation("Index Sayfas� �a��r�ld�");
			_logger.LogError("Error Log �a�r�ld�");
			return View();
		}

		public IActionResult Privacy()
		{
			DateTime d =  Convert.ToDateTime(DateTime.Now.ToLongDateString());
			_logger.LogInformation(d+ "Privacy Sayfas� �a��r�ld�");
			return View();
		}
		public IActionResult Test()
		{
			_logger.LogInformation("Test Sayfas� �a��r�ld�");
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
