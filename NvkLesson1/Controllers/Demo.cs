using Microsoft.AspNetCore.Mvc;

namespace NvkLesson1.Controllers
{
    public class Demo : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
