﻿using System;
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
    public class PaisesController : Controller
    {
        private readonly MigracionDbContext _context;

        public PaisesController(MigracionDbContext context)
        {
            _context = context;
        }

        // GET: Paises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paises.ToListAsync());
        }

        // GET: Paises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .FirstOrDefaultAsync(m => m.IDPais == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // GET: Paises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPais,NombrePais")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        // GET: Paises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return View(pais);
        }

        // POST: Paises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPais,NombrePais")] Pais pais)
        {
            if (id != pais.IDPais)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaisExists(pais.IDPais))
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
            return View(pais);
        }

        // GET: Paises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _context.Paises
                .FirstOrDefaultAsync(m => m.IDPais == id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais != null)
            {
                _context.Paises.Remove(pais);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.IDPais == id);
        }
    }
}
