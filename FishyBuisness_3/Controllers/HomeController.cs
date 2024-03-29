using FishyBuisness_3.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using System.Diagnostics;

namespace FishyBuisness_3.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private IHtmlLocalizer<HomeController> _localizer;

		public HomeController(ILogger<HomeController> logger, IHtmlLocalizer<HomeController> localizer)
		{
			_logger = logger;
			_localizer = localizer;
		}

		public IActionResult Index()
		{
			ViewData["Welcome"] = _localizer["Welcome"];
			return View();
		}


		[HttpPost]
		 public IActionResult setLanguage(string culture, string returnUrl)
		{
			Response.Cookies.Append(
				CookieRequestCultureProvider.DefaultCookieName,
				CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
				new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1)
				});

			return LocalRedirect(returnUrl);

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
