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
    public class NvkPublishersController : Controller
    {
        private readonly NvkBookStoreContext _context;

        public NvkPublishersController(NvkBookStoreContext context)
        {
            _context = context;
        }

        // GET: NvkPublishers
        public async Task<IActionResult> NvkIndex2()
        {
            return View(await _context.Publishers.ToListAsync());
        }

        // GET: NvkPublishers/Details/5
        public async Task<IActionResult> NvkDetails(int? Nvkid)
        {
            if (Nvkid == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == Nvkid);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: NvkPublishers/Create
        public IActionResult NvkCreate()
        {
            return View();
        }

        // POST: NvkPublishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkCreate([Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publisher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NvkIndex2));
            }
            return View(publisher);
        }

        // GET: NvkPublishers/Edit/5
        public async Task<IActionResult> NvkEdit(int? Nvkid)
        {
            if (Nvkid == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers.FindAsync(Nvkid);
            if (publisher == null)
            {
                return NotFound();
            }
            return View(publisher);
        }

        // POST: NvkPublishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkEdit(int Nvkid, [Bind("PublisherId,PublisherName,Phone,Address")] Publisher publisher)
        {
            if (Nvkid != publisher.PublisherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publisher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublisherExists(publisher.PublisherId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(NvkIndex2));
            }
            return View(publisher);
        }

        // GET: NvkPublishers/Delete/5
        public async Task<IActionResult> NvkDelete(int? Nvkid)
        {
            if (Nvkid == null)
            {
                return NotFound();
            }

            var publisher = await _context.Publishers
                .FirstOrDefaultAsync(m => m.PublisherId == Nvkid);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: NvkPublishers/Delete/5
        [HttpPost, ActionName("NvkDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NvkDeleteConfirmed(int Nvkid)
        {
            var publisher = await _context.Publishers.FindAsync(Nvkid);
            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(NvkIndex2));
        }

        private bool PublisherExists(int Nvkid)
        {
            return _context.Publishers.Any(e => e.PublisherId == Nvkid);
        }
    }
}
