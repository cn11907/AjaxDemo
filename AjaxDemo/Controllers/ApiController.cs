using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name,int age)
        {
            
            System.Threading.Thread.Sleep(2000);
            if (string.IsNullOrEmpty(name))
            {
                return Content("是在哈囉?", "text/html", Encoding.UTF8);
            }
            return Content("哈囉,"+name+" 今年 "+age+" 歲 ", "text/html", Encoding.UTF8);
        }
    }
}
