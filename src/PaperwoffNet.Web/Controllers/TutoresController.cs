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
    public class TutoresController : Controller
    {
        private readonly PaperwoffNetDbContext _context;

        public TutoresController(PaperwoffNetDbContext context)
        {
            _context = context;
        }

        // GET: Tutores
        public async Task<IActionResult> Index()
        {
            var paperwoffNetDbContext = _context.Tutores.Include(t => t.UsersIdUserNavigation);
            return View(await paperwoffNetDbContext.ToListAsync());
        }

        // GET: Tutores/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutores = await _context.Tutores
                .Include(t => t.UsersIdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdTutores == id);
            if (tutores == null)
            {
                return NotFound();
            }

            return View(tutores);
        }

        // GET: Tutores/Create
        public IActionResult Create()
        {
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser");
            return View();
        }

        // POST: Tutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTutores,UsersIdUser,FechaIngreso,Profesion")] Tutores tutores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", tutores.UsersIdUser);
            return View(tutores);
        }

        // GET: Tutores/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutores = await _context.Tutores.FindAsync(id);
            if (tutores == null)
            {
                return NotFound();
            }
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", tutores.UsersIdUser);
            return View(tutores);
        }

        // POST: Tutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdTutores,UsersIdUser,FechaIngreso,Profesion")] Tutores tutores)
        {
            if (id != tutores.IdTutores)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutoresExists(tutores.IdTutores))
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
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", tutores.UsersIdUser);
            return View(tutores);
        }

        // GET: Tutores/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutores = await _context.Tutores
                .Include(t => t.UsersIdUserNavigation)
                .FirstOrDefaultAsync(m => m.IdTutores == id);
            if (tutores == null)
            {
                return NotFound();
            }

            return View(tutores);
        }

        // POST: Tutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tutores = await _context.Tutores.FindAsync(id);
            _context.Tutores.Remove(tutores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutoresExists(long id)
        {
            return _context.Tutores.Any(e => e.IdTutores == id);
        }
    }
}
