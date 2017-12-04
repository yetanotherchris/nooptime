using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Nooptime.Web.Models;
using Nooptime.Domain.Services;

namespace Nooptime.Web.Controllers
{
    public class CanaryController : Controller
    {
        private readonly CanaryService _service;

        public CanaryController(CanaryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return Json(_service.RunTests());
        }
    }
}