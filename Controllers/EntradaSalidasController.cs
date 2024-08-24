using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JimenaCelaya_Examen3.Data;
using JimenaCelaya_Examen3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JimenaCelaya_Examen3.Controllers
{
    public class EntradaSalidasController : Controller
    {
        private readonly MigracionDbContext _context;

        public EntradaSalidasController(MigracionDbContext context)
        {
            _context = context;
        }

        // GET: EntradaSalidas
        public async Task<IActionResult> Index()
        {
            var migracionDbContext = _context.EntradasSalidas.Include(e => e.Viajero);
            return View(await migracionDbContext.ToListAsync());
        }

        // GET: EntradaSalidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var entradaSalida = await _context.EntradasSalidas
                .Include(e => e.Viajero)
                .FirstOrDefaultAsync(m => m.IDRegistro == id);
            if (entradaSalida == null) return NotFound();

            return View(entradaSalida);
        }

        // GET: EntradaSalidas/Create
        public IActionResult Create()
        {
            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "NombreCompleto");
            return View();
        }

        // POST: EntradaSalidas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDRegistro,FechaEntrada,LugarEntrada,FechaSalida,LugarSalida,IDViajero")] EntradaSalida entradaSalida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entradaSalida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "NombreCompleto", entradaSalida.IDViajero);
            return View(entradaSalida);
        }

        // GET: EntradaSalidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var entradaSalida = await _context.EntradasSalidas.FindAsync(id);
            if (entradaSalida == null) return NotFound();

            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "NombreCompleto", entradaSalida.IDViajero);
            return View(entradaSalida);
        }

        // POST: EntradaSalidas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDRegistro,FechaEntrada,LugarEntrada,FechaSalida,LugarSalida,IDViajero")] EntradaSalida entradaSalida)
        {
            if (id != entradaSalida.IDRegistro) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaSalida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaSalidaExists(entradaSalida.IDRegistro)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDViajero"] = new SelectList(_context.Viajeros, "IDViajero", "NombreCompleto", entradaSalida.IDViajero);
            return View(entradaSalida);
        }

        // GET: EntradaSalidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var entradaSalida = await _context.EntradasSalidas
                .Include(e => e.Viajero)
                .FirstOrDefaultAsync(m => m.IDRegistro == id);
            if (entradaSalida == null) return NotFound();

            return View(entradaSalida);
        }

        // POST: EntradaSalidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entradaSalida = await _context.EntradasSalidas.FindAsync(id);
            _context.EntradasSalidas.Remove(entradaSalida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaSalidaExists(int id)
        {
            return _context.EntradasSalidas.Any(e => e.IDRegistro == id);
        }
    }
}
