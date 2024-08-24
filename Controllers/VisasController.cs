using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JimenaCelaya_Examen3.Data;
using JimenaCelaya_Examen3.Models;

namespace JimenaCelaya_Examen3.Controllers
{
    public class VisasController : Controller
    {
        private readonly MigracionDbContext _context;

        public VisasController(MigracionDbContext context)
        {
            _context = context;
        }

        // GET: Visas
        public async Task<IActionResult> Index()
        {
            var migracionDbContext = _context.Visas.Include(v => v.Pais).Include(v => v.Viajero);
            return View(await migracionDbContext.ToListAsync());
        }

        // GET: Visas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visa = await _context.Visas
                .Include(v => v.Pais)
                .Include(v => v.Viajero)
                .FirstOrDefaultAsync(m => m.IDVisa == id);
            if (visa == null)
            {
                return NotFound();
            }

            return View(visa);
        }

        // GET: Visas/Create
        public IActionResult Create()
        {
            ViewData["IDPais"] = new SelectList(_context.Paises, "IDPais", "NombrePais");
            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "Nacionalidad");
            return View();
        }

        // POST: Visas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDVisa,FechaEmision,FechaVencimiento,IDViajero,IDPais")] Visa visa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPais"] = new SelectList(_context.Paises, "IDPais", "NombrePais", visa.IDPais);
            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "Nacionalidad", visa.IDViajero);
            return View(visa);
        }

        // GET: Visas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visa = await _context.Visas.FindAsync(id);
            if (visa == null)
            {
                return NotFound();
            }
            ViewData["IDPais"] = new SelectList(_context.Paises, "IDPais", "NombrePais", visa.IDPais);
            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "Nacionalidad", visa.IDViajero);
            return View(visa);
        }

        // POST: Visas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDVisa,FechaEmision,FechaVencimiento,IDViajero,IDPais")] Visa visa)
        {
            if (id != visa.IDVisa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisaExists(visa.IDVisa))
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
            ViewData["IDPais"] = new SelectList(_context.Paises, "IDPais", "NombrePais", visa.IDPais);
            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "Nacionalidad", visa.IDViajero);
            return View(visa);
        }

        // GET: Visas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visa = await _context.Visas
                .Include(v => v.Pais)
                .Include(v => v.Viajero)
                .FirstOrDefaultAsync(m => m.IDVisa == id);
            if (visa == null)
            {
                return NotFound();
            }

            return View(visa);
        }

        // POST: Visas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visa = await _context.Visas.FindAsync(id);
            if (visa != null)
            {
                _context.Visas.Remove(visa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisaExists(int id)
        {
            return _context.Visas.Any(e => e.IDVisa == id);
        }
    }
}
