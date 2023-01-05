using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AjaxDemo.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Content("是在哈囉?", "text/html", Encoding.UTF8);
            }
            return Content("哈囉,"+name, "text/html", Encoding.UTF8);
        }
    }
}
