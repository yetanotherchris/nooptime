using Microsoft.AspNetCore.Mvc;
using Nooptime.Web.Models;

namespace Nooptime.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Status()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult Activity()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = System.Diagnostics.Activity.Current?.Id
                            ?? HttpContext.TraceIdentifier
            });
        }
    }
}