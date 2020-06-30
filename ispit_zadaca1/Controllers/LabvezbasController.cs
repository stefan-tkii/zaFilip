using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ispit_zadaca1.Models;

namespace ispit_zadaca1.Controllers
{
    public class LabvezbasController : Controller
    {
        private readonly MVCFacultyContext _context;

        public LabvezbasController(MVCFacultyContext context)
        {
            _context = context;
        }

        // GET: Labvezbas
        public async Task<IActionResult> Index()
        {
            return View(await _context.vezbi.ToListAsync());
        }

        public async Task<IActionResult> search(string title_filter, string desc_filter)
        {
            IQueryable<Labvezba> all = _context.vezbi.AsQueryable();
            if(!String.IsNullOrEmpty(title_filter))
            {
                all = all.Where(s => s.title.Contains(title_filter));
            }

            if(!String.IsNullOrEmpty(desc_filter))
            {
                all = all.Where(s => s.desc.Contains(desc_filter));
            }

            var list = await all.ToListAsync();
            return View(list);
        }

        // GET: Labvezbas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labvezba = await _context.vezbi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labvezba == null)
            {
                return NotFound();
            }

            return View(labvezba);
        }

        // GET: Labvezbas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labvezbas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,title,desc")] Labvezba labvezba)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labvezba);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labvezba);
        }

        // GET: Labvezbas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labvezba = await _context.vezbi.FindAsync(id);
            if (labvezba == null)
            {
                return NotFound();
            }
            return View(labvezba);
        }

        // POST: Labvezbas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,title,desc")] Labvezba labvezba)
        {
            if (id != labvezba.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labvezba);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabvezbaExists(labvezba.Id))
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
            return View(labvezba);
        }

        // GET: Labvezbas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labvezba = await _context.vezbi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labvezba == null)
            {
                return NotFound();
            }

            return View(labvezba);
        }

        // POST: Labvezbas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labvezba = await _context.vezbi.FindAsync(id);
            _context.vezbi.Remove(labvezba);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabvezbaExists(int id)
        {
            return _context.vezbi.Any(e => e.Id == id);
        }
    }
}
