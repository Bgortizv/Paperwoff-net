using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaperwoffNet.Infrastructure;
using PaperwoffNet.Infrastructure.Data;

namespace PaperwoffNet.Web.Controllers
{
    public class BolsaPagosController : Controller
    {
        private readonly PaperwoffNetDbContext _context;

        public BolsaPagosController(PaperwoffNetDbContext context)
        {
            _context = context;
        }

        // GET: BolsaPagos
        public async Task<IActionResult> Index()
        {
            var paperwoffNetDbContext = _context.BolsaPagos.Include(b => b.EstudiantesIdEstudiantesNavigation);
            return View(await paperwoffNetDbContext.ToListAsync());
        }

        // GET: BolsaPagos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolsaPagos = await _context.BolsaPagos
                .Include(b => b.EstudiantesIdEstudiantesNavigation)
                .FirstOrDefaultAsync(m => m.IdBolsaPagos == id);
            if (bolsaPagos == null)
            {
                return NotFound();
            }

            return View(bolsaPagos);
        }

        // GET: BolsaPagos/Create
        public IActionResult Create()
        {
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes");
            return View();
        }

        // POST: BolsaPagos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBolsaPagos,EstudiantesIdEstudiantes,TotalAbonos,TotalDescuentos")] BolsaPagos bolsaPagos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolsaPagos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes", bolsaPagos.EstudiantesIdEstudiantes);
            return View(bolsaPagos);
        }

        // GET: BolsaPagos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolsaPagos = await _context.BolsaPagos.FindAsync(id);
            if (bolsaPagos == null)
            {
                return NotFound();
            }
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes", bolsaPagos.EstudiantesIdEstudiantes);
            return View(bolsaPagos);
        }

        // POST: BolsaPagos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdBolsaPagos,EstudiantesIdEstudiantes,TotalAbonos,TotalDescuentos")] BolsaPagos bolsaPagos)
        {
            if (id != bolsaPagos.IdBolsaPagos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolsaPagos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolsaPagosExists(bolsaPagos.IdBolsaPagos))
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
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes", bolsaPagos.EstudiantesIdEstudiantes);
            return View(bolsaPagos);
        }

        // GET: BolsaPagos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolsaPagos = await _context.BolsaPagos
                .Include(b => b.EstudiantesIdEstudiantesNavigation)
                .FirstOrDefaultAsync(m => m.IdBolsaPagos == id);
            if (bolsaPagos == null)
            {
                return NotFound();
            }

            return View(bolsaPagos);
        }

        // POST: BolsaPagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bolsaPagos = await _context.BolsaPagos.FindAsync(id);
            _context.BolsaPagos.Remove(bolsaPagos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolsaPagosExists(long id)
        {
            return _context.BolsaPagos.Any(e => e.IdBolsaPagos == id);
        }
    }
}
