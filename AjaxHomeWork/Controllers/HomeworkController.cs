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
            //foreach(var member in _context.Members)
            //{
            //    if (member.Name.ToLower() == name.ToLower())               
            //        return Content("姓名已存在");                      
            //}
            //return Content(name+"可以使用");
            //------------老師建議----------------||
            var exists = _context.Members.Any(m => m.Name == name);
            if(exists)
                return Content("姓名已存在");
            else
                return Content(name + "可以使用");
        }

        public IActionResult Post()
        {

            return View();
        }

        public IActionResult City()
        {
            //var cities = _context.Address.Select(c => new { c.City }).Distinct().OrderBy(c => c.City);
            var cities = _context.Address.Select(c => c.City).Distinct();
            return Json(cities);
        }
        public IActionResult Site(string city)
        {
            // var sities = _context.Address.Where(s=>s.City==city).Select(s => new { s.SiteId }).Distinct().OrderBy(s => s.SiteId);
            var sites = _context.Address.Where(s => s.City == city).Select(s => s.SiteId).Distinct();
            return Json(sites);
        }
        public IActionResult Road(string site)
        {
            //var roads = _context.Address.Where(r => r.SiteId == site).Select(r => new { r.Road }).Distinct().OrderBy(r => r.Road);
            var roads = _context.Address.Where(s => s.SiteId == site).Select(s => s.Road).Distinct();
            return Json(roads);
        }

    }
}
