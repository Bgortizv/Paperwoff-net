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
    public class AsignaturaxtutorController : Controller
    {
        private readonly PaperwoffNetDbContext _context;

        public AsignaturaxtutorController(PaperwoffNetDbContext context)
        {
            _context = context;
        }

        // GET: Asignaturaxtutor
        public async Task<IActionResult> Index()
        {
            var paperwoffNetDbContext = _context.Asignaturaxtutor.Include(a => a.AsignaturaIdAsignaturaNavigation).Include(a => a.TutoresIdTutoresNavigation);
            return View(await paperwoffNetDbContext.ToListAsync());
        }

        // GET: Asignaturaxtutor/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaxtutor = await _context.Asignaturaxtutor
                .Include(a => a.AsignaturaIdAsignaturaNavigation)
                .Include(a => a.TutoresIdTutoresNavigation)
                .FirstOrDefaultAsync(m => m.IdAxT == id);
            if (asignaturaxtutor == null)
            {
                return NotFound();
            }

            return View(asignaturaxtutor);
        }

        // GET: Asignaturaxtutor/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura");
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores");
            return View();
        }

        // POST: Asignaturaxtutor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAxT,TutoresIdTutores,AsignaturaIdAsignatura,Estado")] Asignaturaxtutor asignaturaxtutor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignaturaxtutor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", asignaturaxtutor.AsignaturaIdAsignatura);
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores", asignaturaxtutor.TutoresIdTutores);
            return View(asignaturaxtutor);
        }

        // GET: Asignaturaxtutor/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaxtutor = await _context.Asignaturaxtutor.FindAsync(id);
            if (asignaturaxtutor == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", asignaturaxtutor.AsignaturaIdAsignatura);
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores", asignaturaxtutor.TutoresIdTutores);
            return View(asignaturaxtutor);
        }

        // POST: Asignaturaxtutor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdAxT,TutoresIdTutores,AsignaturaIdAsignatura,Estado")] Asignaturaxtutor asignaturaxtutor)
        {
            if (id != asignaturaxtutor.IdAxT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignaturaxtutor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturaxtutorExists(asignaturaxtutor.IdAxT))
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
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", asignaturaxtutor.AsignaturaIdAsignatura);
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores", asignaturaxtutor.TutoresIdTutores);
            return View(asignaturaxtutor);
        }

        // GET: Asignaturaxtutor/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturaxtutor = await _context.Asignaturaxtutor
                .Include(a => a.AsignaturaIdAsignaturaNavigation)
                .Include(a => a.TutoresIdTutoresNavigation)
                .FirstOrDefaultAsync(m => m.IdAxT == id);
            if (asignaturaxtutor == null)
            {
                return NotFound();
            }

            return View(asignaturaxtutor);
        }

        // POST: Asignaturaxtutor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var asignaturaxtutor = await _context.Asignaturaxtutor.FindAsync(id);
            _context.Asignaturaxtutor.Remove(asignaturaxtutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturaxtutorExists(long id)
        {
            return _context.Asignaturaxtutor.Any(e => e.IdAxT == id);
        }
    }
}
