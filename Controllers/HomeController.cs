using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tilrepo.Models;

namespace tilrepo.Controllers
{
    public class HomeController : Controller
    {
        private readonly tilRepoContext _context;

        public HomeController(tilRepoContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            return View(await _context.til.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var til = await _context.til
                .SingleOrDefaultAsync(m => m.id == id);
            if (til == null)
            {
                return NotFound();
            }

            return View(til);
        }

        // GET: Home/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,content,tags,reference,addedOn")] til til)
        {
            if (ModelState.IsValid)
            {
                _context.Add(til);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(til);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var til = await _context.til.SingleOrDefaultAsync(m => m.id == id);
            if (til == null)
            {
                return NotFound();
            }
            return View(til);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,content,tags,reference,addedOn")] til til)
        {
            if (id != til.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(til);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tilExists(til.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(til);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var til = await _context.til
                .SingleOrDefaultAsync(m => m.id == id);
            if (til == null)
            {
                return NotFound();
            }

            return View(til);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var til = await _context.til.SingleOrDefaultAsync(m => m.id == id);
            _context.til.Remove(til);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tilExists(int id)
        {
            return _context.til.Any(e => e.id == id);
        }
    }
}
