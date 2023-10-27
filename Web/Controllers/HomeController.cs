using Contract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _service;


        public HomeController(ILogger<HomeController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            var items = _service.GetAll();
            return View(items);
        }

        public IActionResult Details(Guid id)
        {
            var ts = _service.GetById(id);
            if (ts == null)
            {
                return NotFound();
            }

            return View(ts);
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