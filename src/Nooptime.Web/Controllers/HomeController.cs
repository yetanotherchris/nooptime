using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nooptime.Web.Models;

namespace Nooptime.Web.Controllers
{
	public class MyModel
	{
		public Dictionary<string, string> Properties { get; set; }
	}

	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(MyModel model)
		{
			var stringBuilder = new StringBuilder();
			foreach (string key in model.Properties.Keys)
			{
				stringBuilder.AppendLine($"{key} - {model.Properties[key]}");
			}

			return Content(stringBuilder.ToString());
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}