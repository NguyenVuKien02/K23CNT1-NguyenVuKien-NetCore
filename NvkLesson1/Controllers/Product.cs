using Microsoft.AspNetCore.Mvc;

namespace NvkLesson1.Controllers
{
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
