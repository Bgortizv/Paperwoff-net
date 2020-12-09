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
    public class TipoClaseController : Controller
    {
        private readonly PaperwoffNetDbContext _context;

        public TipoClaseController(PaperwoffNetDbContext context)
        {
            _context = context;
        }

        // GET: TipoClase
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoClase.ToListAsync());
        }

        // GET: TipoClase/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClase = await _context.TipoClase
                .FirstOrDefaultAsync(m => m.IdTipoClase == id);
            if (tipoClase == null)
            {
                return NotFound();
            }

            return View(tipoClase);
        }

        // GET: TipoClase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoClase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoClase,Descripcion")] TipoClase tipoClase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoClase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoClase);
        }

        // GET: TipoClase/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClase = await _context.TipoClase.FindAsync(id);
            if (tipoClase == null)
            {
                return NotFound();
            }
            return View(tipoClase);
        }

        // POST: TipoClase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdTipoClase,Descripcion")] TipoClase tipoClase)
        {
            if (id != tipoClase.IdTipoClase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoClase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoClaseExists(tipoClase.IdTipoClase))
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
            return View(tipoClase);
        }

        // GET: TipoClase/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoClase = await _context.TipoClase
                .FirstOrDefaultAsync(m => m.IdTipoClase == id);
            if (tipoClase == null)
            {
                return NotFound();
            }

            return View(tipoClase);
        }

        // POST: TipoClase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tipoClase = await _context.TipoClase.FindAsync(id);
            _context.TipoClase.Remove(tipoClase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoClaseExists(long id)
        {
            return _context.TipoClase.Any(e => e.IdTipoClase == id);
        }
    }
}
