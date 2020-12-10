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
    public class VirpresController : Controller
    {
        private readonly PaperwoffNetDbContext _context;

        public VirpresController(PaperwoffNetDbContext context)
        {
            _context = context;
        }

        // GET: Virpres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Virpres.ToListAsync());
        }

        // GET: Virpres/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virpres = await _context.Virpres
                .FirstOrDefaultAsync(m => m.IdVirPres == id);
            if (virpres == null)
            {
                return NotFound();
            }

            return View(virpres);
        }

        // GET: Virpres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Virpres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVirPres,Descrip")] Virpres virpres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(virpres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(virpres);
        }

        // GET: Virpres/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virpres = await _context.Virpres.FindAsync(id);
            if (virpres == null)
            {
                return NotFound();
            }
            return View(virpres);
        }

        // POST: Virpres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdVirPres,Descrip")] Virpres virpres)
        {
            if (id != virpres.IdVirPres)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(virpres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VirpresExists(virpres.IdVirPres))
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
            return View(virpres);
        }

        // GET: Virpres/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var virpres = await _context.Virpres
                .FirstOrDefaultAsync(m => m.IdVirPres == id);
            if (virpres == null)
            {
                return NotFound();
            }

            return View(virpres);
        }

        // POST: Virpres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var virpres = await _context.Virpres.FindAsync(id);
            _context.Virpres.Remove(virpres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VirpresExists(long id)
        {
            return _context.Virpres.Any(e => e.IdVirPres == id);
        }
    }
}
