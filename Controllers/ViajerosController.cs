using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JimenaCelaya_Examen3.Data;
using JimenaCelaya_Examen3.Models;

public class ViajerosController : Controller
{
    private readonly MigracionDbContext _context;

    public ViajerosController(MigracionDbContext context)
    {
        _context = context;
    }

    // GET: Viajeros
    public async Task<IActionResult> Index()
    {
        return View(await _context.Viajeros.ToListAsync());
    }

    // GET: Viajeros/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Viajeros/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IDViajero,NombreCompleto,NumeroPasaporte,Nacionalidad,FechaNacimiento")] Viajero viajero)
    {
        if (ModelState.IsValid)
        {
            _context.Add(viajero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(viajero);
    }

    // GET: Viajeros/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var viajero = await _context.Viajeros.FindAsync(id);
        if (viajero == null)
        {
            return NotFound();
        }
        return View(viajero);
    }

    // POST: Viajeros/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("IDViajero,NombreCompleto,NumeroPasaporte,Nacionalidad,FechaNacimiento")] Viajero viajero)
    {
        if (id != viajero.IDViajero)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(viajero);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajeroExists(viajero.IDViajero))
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
        return View(viajero);
    }

    // GET: Viajeros/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var viajero = await _context.Viajeros
            .FirstOrDefaultAsync(m => m.IDViajero == id);
        if (viajero == null)
        {
            return NotFound();
        }

        return View(viajero);
    }

    // POST: Viajeros/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var viajero = await _context.Viajeros.FindAsync(id);
        _context.Viajeros.Remove(viajero);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ViajeroExists(int id)
    {
        return _context.Viajeros.Any(e => e.IDViajero == id);
    }
}
