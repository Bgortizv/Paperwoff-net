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
    public class DetalleFacturaController : Controller
    {
        private readonly PaperwoffNetDbContext _context;

        public DetalleFacturaController(PaperwoffNetDbContext context)
        {
            _context = context;
        }

        // GET: DetalleFactura
        public async Task<IActionResult> Index()
        {
            var paperwoffNetDbContext = _context.DetalleFactura.Include(d => d.AsignaturaIdAsignaturaNavigation).Include(d => d.FacturaIdFacturaNavigation);
            return View(await paperwoffNetDbContext.ToListAsync());
        }

        // GET: DetalleFactura/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.AsignaturaIdAsignaturaNavigation)
                .Include(d => d.FacturaIdFacturaNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleFactura == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFactura/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura");
            ViewData["FacturaIdFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura");
            return View();
        }

        // POST: DetalleFactura/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleFactura,FacturaIdFactura,AsignaturaIdAsignatura,CantidadHoras,ValorTotal")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", detalleFactura.AsignaturaIdAsignatura);
            ViewData["FacturaIdFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura", detalleFactura.FacturaIdFactura);
            return View(detalleFactura);
        }

        // GET: DetalleFactura/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", detalleFactura.AsignaturaIdAsignatura);
            ViewData["FacturaIdFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura", detalleFactura.FacturaIdFactura);
            return View(detalleFactura);
        }

        // POST: DetalleFactura/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdDetalleFactura,FacturaIdFactura,AsignaturaIdAsignatura,CantidadHoras,ValorTotal")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.IdDetalleFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.IdDetalleFactura))
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
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", detalleFactura.AsignaturaIdAsignatura);
            ViewData["FacturaIdFactura"] = new SelectList(_context.Factura, "IdFactura", "IdFactura", detalleFactura.FacturaIdFactura);
            return View(detalleFactura);
        }

        // GET: DetalleFactura/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFactura
                .Include(d => d.AsignaturaIdAsignaturaNavigation)
                .Include(d => d.FacturaIdFacturaNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleFactura == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFactura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var detalleFactura = await _context.DetalleFactura.FindAsync(id);
            _context.DetalleFactura.Remove(detalleFactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(long id)
        {
            return _context.DetalleFactura.Any(e => e.IdDetalleFactura == id);
        }
    }
}
