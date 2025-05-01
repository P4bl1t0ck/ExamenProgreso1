using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamenProgreso1.Models;

namespace ExamenProgreso1.Controllers
{
    public class DuenoController : Controller
    {
        private readonly VeterinariaBasedeDatos _context;

        public DuenoController(VeterinariaBasedeDatos context)
        {
            _context = context;
        }

        // GET: Dueno
        public async Task<IActionResult> Index()
        {
            var veterinariaBasedeDatos = _context.Dueno.Include(d => d.Cita);
            return View(await veterinariaBasedeDatos.ToListAsync());
        }

        // GET: Dueno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno
                .Include(d => d.Cita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // GET: Dueno/Create
        public IActionResult Create()
        {
            ViewData["CitaId"] = new SelectList(_context.Cita, "Id", "Id");
            return View();
        }

        // POST: Dueno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Correo,CitaId")] Dueno dueno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CitaId"] = new SelectList(_context.Cita, "Id", "Id", dueno.CitaId);
            return View(dueno);
        }

        // GET: Dueno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno == null)
            {
                return NotFound();
            }
            ViewData["CitaId"] = new SelectList(_context.Cita, "Id", "Id", dueno.CitaId);
            return View(dueno);
        }

        // POST: Dueno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Correo,CitaId")] Dueno dueno)
        {
            if (id != dueno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoExists(dueno.Id))
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
            ViewData["CitaId"] = new SelectList(_context.Cita, "Id", "Id", dueno.CitaId);
            return View(dueno);
        }

        // GET: Dueno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueno = await _context.Dueno
                .Include(d => d.Cita)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dueno == null)
            {
                return NotFound();
            }

            return View(dueno);
        }

        // POST: Dueno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueno = await _context.Dueno.FindAsync(id);
            if (dueno != null)
            {
                _context.Dueno.Remove(dueno);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoExists(int id)
        {
            return _context.Dueno.Any(e => e.Id == id);
        }
    }
}
