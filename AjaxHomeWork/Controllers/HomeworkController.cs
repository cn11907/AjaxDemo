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
        [HttpPost]
        public IActionResult CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Content("請輸入姓名");
            foreach(var member in _context.Members)
            {
                if (member.Name.ToLower() == name.ToLower())               
                    return Content("姓名已存在");
                      
            }
            return Content(name+"可以使用");
        }

    }
}
