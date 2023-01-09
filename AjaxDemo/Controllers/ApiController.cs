using AjaxDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Xml.Linq;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;
       
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context , IWebHostEnvironment host)
        {
            _context = context;          
            _host = host;
        }



        public IActionResult Index(string name,int age,string email)
        {
            
           // System.Threading.Thread.Sleep(1000);
            if (string.IsNullOrEmpty(name))
            {
                return Content("是在哈囉?", "text/html", Encoding.UTF8);
            }
            return Content("哈囉,"+name+" 今年 "+age+" 歲。信箱: "+email, "text/html", Encoding.UTF8);
        }
        public IActionResult Register(Member member,IFormFile photo)
        {
            string fileName = photo.FileName;
            string filePath = Path.Combine(_host.WebRootPath, "Images", photo.FileName);
            //檔案上傳到uploads資料夾中
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }
            member.FileName = fileName;
            //圖檔轉成二進位
            byte[]? imgByte = null;
            using(var memoryStream=new MemoryStream())
            {
                photo.CopyTo(memoryStream);
                imgByte = memoryStream.ToArray();
            }
            member.FileData = imgByte;

            _context.Members.Add(member);
            _context.SaveChanges();

            //return Content($"Hello, {member.Name}, You are {member.Age} years old, {member.Email}。", "text/plain", Encoding.UTF8);
            // return Content($"{photo.FileName}-{photo.Length}-{photo.ContentType}", "text/plain", Encoding.UTF8);
            //return Content($"{_host.WebRootPath} - {_host.ContentRootPath}");
            return Content("上傳成功");
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
        public IActionResult Fetch(string site)
        {

            return View();

        }



        }
}
