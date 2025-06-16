using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NvkLesson09.Models;

namespace NvkLesson09.Controllers
{
    public class NvkCategoriesController : Controller
    {
        private readonly NvkBookStoreContext _context;

        public NvkCategoriesController(NvkBookStoreContext context)
        {
            _context = context;
        }

        // GET: NvkCategories
        public async Task<IActionResult> NvkIndex1()
        {
            return View(await _context.Categories.ToListAsync());
        }

        // GET: NvkCategories/Details/5
        public async Task<IActionResult> NvkDetails(int? Nvkid)
        {
            if (Nvkid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == Nvkid);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: NvkCategories/Create
        public IActionResult NvkCreate()
        {
            return View();
        }

        // POST: NvkCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkCreate([Bind("CategoryId,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvkIndex1));
            }
            return View(category);
        }

        // GET: NvkCategories/Edit/5
        public async Task<IActionResult> NvkEdit(int? Nvkid)
        {
            if (Nvkid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(Nvkid);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: NvkCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkEdit(int Nvkid, [Bind("CategoryId,CategoryName")] Category category)
        {
            if (Nvkid != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.CategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NvkIndex1));
            }
            return View(category);
        }

        // GET: NvkCategories/Delete/5
        public async Task<IActionResult> NvkDelete(int? Nvkid)
        {
            if (Nvkid == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == Nvkid);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: NvkCategories/Delete/5
        [HttpPost, ActionName("NvkDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkDeleteConfirmed(int Nvkid)
        {
            var category = await _context.Categories.FindAsync(Nvkid);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NvkIndex1));
        }

        private bool CategoryExists(int Nvkid)
        {
            return _context.Categories.Any(e => e.CategoryId == Nvkid);
        }
    }
}
