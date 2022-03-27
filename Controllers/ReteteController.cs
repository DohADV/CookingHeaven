using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookingHeaven.Data;
using CookingHeaven.Models;
using Microsoft.AspNetCore.Authorization;

namespace CookingHeaven.Controllers
{
    public class ReteteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReteteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Retete
        public async Task<IActionResult> Index()
        {
            return View(await _context.Retete.ToListAsync());
        }

        // GET: Retete/CautaOReteta
        public async Task<IActionResult> CautaOReteta()
        {
            return View();
        }
        // POST: Retete/ArataRezultatul
        public async Task<IActionResult> ArataRezultatul(String NumeleRetetei)
        {
            return View("Index", await _context.Retete.Where(j =>j.RetetaNume.Contains(NumeleRetetei)).ToListAsync());
        }

        // GET: Retete/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retete = await _context.Retete
                .FirstOrDefaultAsync(m => m.ID == id);
            if (retete == null)
            {
                return NotFound();
            }

            return View(retete);
        }

        // GET: Retete/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Retete/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RetetaNume,RetetaDescriere")] Retete retete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(retete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(retete);
        }
        [Authorize]
        // GET: Retete/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retete = await _context.Retete.FindAsync(id);
            if (retete == null)
            {
                return NotFound();
            }
            return View(retete);
        }

        // POST: Retete/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RetetaNume,RetetaDescriere")] Retete retete)
        {
            if (id != retete.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReteteExists(retete.ID))
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
            return View(retete);
        }
        [Authorize]
        // GET: Retete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var retete = await _context.Retete
                .FirstOrDefaultAsync(m => m.ID == id);
            if (retete == null)
            {
                return NotFound();
            }

            return View(retete);
        }

        // POST: Retete/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var retete = await _context.Retete.FindAsync(id);
            _context.Retete.Remove(retete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReteteExists(int id)
        {
            return _context.Retete.Any(e => e.ID == id);
        }
    }
}
