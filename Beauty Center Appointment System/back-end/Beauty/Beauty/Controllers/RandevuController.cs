#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Beauty.Data;

namespace Beauty.Controllers
{
    public class RandevuController : Controller
    {
        private readonly BeautyContext _context;

        public RandevuController()
        {
            _context = new BeautyContext();
        }

        // GET: Randevu
        public async Task<IActionResult> Index()
        {
            var beautyContext = _context.Randevus.Include(r => r.CidNavigation).Include(r => r.HnoNavigation).Include(r => r.UidNavigation);
            return View(await beautyContext.ToListAsync());
        }

        // GET: Randevu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .Include(r => r.CidNavigation)
                .Include(r => r.HnoNavigation)
                .Include(r => r.UidNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // GET: Randevu/Create
        public IActionResult Create()
        {
            ViewData["Cid"] = new SelectList(_context.Calisans, "Cid", "Cid");
            ViewData["Hno"] = new SelectList(_context.Hizmets, "Hno", "Hno");
            ViewData["Uid"] = new SelectList(_context.Uyes, "Uid", "Uid");
            return View();
        }

        // POST: Randevu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Uid,Hno,Cid,Tarih")] Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cid"] = new SelectList(_context.Calisans, "Cid", "Cid", randevu.Cid);
            ViewData["Hno"] = new SelectList(_context.Hizmets, "Hno", "Hno", randevu.Hno);
            ViewData["Uid"] = new SelectList(_context.Uyes, "Uid", "Uid", randevu.Uid);
            return View(randevu);
        }

        // GET: Randevu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus.FindAsync(id);
            if (randevu == null)
            {
                return NotFound();
            }
            ViewData["Cid"] = new SelectList(_context.Calisans, "Cid", "Cid", randevu.Cid);
            ViewData["Hno"] = new SelectList(_context.Hizmets, "Hno", "Hno", randevu.Hno);
            ViewData["Uid"] = new SelectList(_context.Uyes, "Uid", "Uid", randevu.Uid);
            return View(randevu);
        }

        // POST: Randevu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Uid,Hno,Cid,Tarih")] Randevu randevu)
        {
            if (id != randevu.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RandevuExists(randevu.id))
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
            ViewData["Cid"] = new SelectList(_context.Calisans, "Cid", "Cid", randevu.Cid);
            ViewData["Hno"] = new SelectList(_context.Hizmets, "Hno", "Hno", randevu.Hno);
            ViewData["Uid"] = new SelectList(_context.Uyes, "Uid", "Uid", randevu.Uid);
            return View(randevu);
        }

        // GET: Randevu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var randevu = await _context.Randevus
                .Include(r => r.CidNavigation)
                .Include(r => r.HnoNavigation)
                .Include(r => r.UidNavigation)
                .FirstOrDefaultAsync(m => m.id == id);
            if (randevu == null)
            {
                return NotFound();
            }

            return View(randevu);
        }

        // POST: Randevu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevu = await _context.Randevus.FindAsync(id);
            _context.Randevus.Remove(randevu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RandevuExists(int id)
        {
            return _context.Randevus.Any(e => e.id == id);
        }
    }
}
