using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class MonstersController : Controller
    {
        private readonly MonstersContext _context;

        public MonstersController(MonstersContext context)
        {
            _context = context;
        }

        // GET: Monsters
        public async Task<IActionResult> Index()
        {
              return _context.Monsters != null ? 
                          View(await _context.Monsters.ToListAsync()) :
                          Problem("Entity set 'MonstersContext.Monsters'  is null.");
        }

        // GET: Monsters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Monsters == null)
            {
                return NotFound();
            }

            var monsters = await _context.Monsters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsters == null)
            {
                return NotFound();
            }

            return View(monsters);
        }

        // GET: Monsters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monsters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MonsterName,MonsterCount,MonsterThreatLvl")] Monsters monsters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monsters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monsters);
        }

        // GET: Monsters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Monsters == null)
            {
                return NotFound();
            }

            var monsters = await _context.Monsters.FindAsync(id);
            if (monsters == null)
            {
                return NotFound();
            }
            return View(monsters);
        }

        // POST: Monsters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MonsterName,MonsterCount,MonsterThreatLvl")] Monsters monsters)
        {
            if (id != monsters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monsters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonstersExists(monsters.Id))
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
            return View(monsters);
        }

        // GET: Monsters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Monsters == null)
            {
                return NotFound();
            }

            var monsters = await _context.Monsters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monsters == null)
            {
                return NotFound();
            }

            return View(monsters);
        }

        // POST: Monsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Monsters == null)
            {
                return Problem("Entity set 'MonstersContext.Monsters'  is null.");
            }
            var monsters = await _context.Monsters.FindAsync(id);
            if (monsters != null)
            {
                _context.Monsters.Remove(monsters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonstersExists(int id)
        {
          return (_context.Monsters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
