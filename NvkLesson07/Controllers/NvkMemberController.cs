using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NvkLesson07.Controllers
{
    public class NvkMemberController : Controller
    {
        // GET: NvkMemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NvkMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NvkMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NvkMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NvkMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NvkMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NvkMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
