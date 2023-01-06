using AjaxHomeWork.Models;
using Microsoft.AspNetCore.Mvc;

namespace AjaxHomeWork.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly ILogger<HomeworkController> _logger;
        private readonly DemoContext _context;
        public HomeworkController(ILogger<HomeworkController> logger, DemoContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult TravelCard()
        {
            return View();
        }

        public IActionResult CheckName()
        {

            return View();
        }

    }
}
