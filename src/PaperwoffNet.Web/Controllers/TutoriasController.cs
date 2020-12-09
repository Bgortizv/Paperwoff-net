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
    public class TutoriasController : Controller
    {
        private readonly PaperwoffNetDbContext _context;

        public TutoriasController(PaperwoffNetDbContext context)
        {
            _context = context;
        }

        // GET: Tutorias
        public async Task<IActionResult> Index()
        {
            var paperwoffNetDbContext = _context.Tutorias.Include(t => t.AsignaturaIdAsignaturaNavigation).Include(t => t.EstudiantesIdEstudiantesNavigation).Include(t => t.TipoClaseIdTipoClaseNavigation).Include(t => t.TutoresIdTutoresNavigation).Include(t => t.UsersIdUserNavigation).Include(t => t.VirPresIdVirPresNavigation);
            return View(await paperwoffNetDbContext.ToListAsync());
        }

        // GET: Tutorias/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorias = await _context.Tutorias
                .Include(t => t.AsignaturaIdAsignaturaNavigation)
                .Include(t => t.EstudiantesIdEstudiantesNavigation)
                .Include(t => t.TipoClaseIdTipoClaseNavigation)
                .Include(t => t.TutoresIdTutoresNavigation)
                .Include(t => t.UsersIdUserNavigation)
                .Include(t => t.VirPresIdVirPresNavigation)
                .FirstOrDefaultAsync(m => m.IdTutorias == id);
            if (tutorias == null)
            {
                return NotFound();
            }

            return View(tutorias);
        }

        // GET: Tutorias/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura");
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes");
            ViewData["TipoClaseIdTipoClase"] = new SelectList(_context.TipoClase, "IdTipoClase", "IdTipoClase");
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores");
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser");
            ViewData["VirPresIdVirPres"] = new SelectList(_context.Virpres, "IdVirPres", "IdVirPres");
            return View();
        }

        // POST: Tutorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTutorias,UsersIdUser,TutoresIdTutores,AsignaturaIdAsignatura,EstudiantesIdEstudiantes,TipoClaseIdTipoClase,VirPresIdVirPres,Transporte,Total,HoraInicio,HoraFin,CantidadHoras,Paga")] Tutorias tutorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tutorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", tutorias.AsignaturaIdAsignatura);
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes", tutorias.EstudiantesIdEstudiantes);
            ViewData["TipoClaseIdTipoClase"] = new SelectList(_context.TipoClase, "IdTipoClase", "IdTipoClase", tutorias.TipoClaseIdTipoClase);
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores", tutorias.TutoresIdTutores);
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", tutorias.UsersIdUser);
            ViewData["VirPresIdVirPres"] = new SelectList(_context.Virpres, "IdVirPres", "IdVirPres", tutorias.VirPresIdVirPres);
            return View(tutorias);
        }

        // GET: Tutorias/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorias = await _context.Tutorias.FindAsync(id);
            if (tutorias == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", tutorias.AsignaturaIdAsignatura);
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes", tutorias.EstudiantesIdEstudiantes);
            ViewData["TipoClaseIdTipoClase"] = new SelectList(_context.TipoClase, "IdTipoClase", "IdTipoClase", tutorias.TipoClaseIdTipoClase);
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores", tutorias.TutoresIdTutores);
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", tutorias.UsersIdUser);
            ViewData["VirPresIdVirPres"] = new SelectList(_context.Virpres, "IdVirPres", "IdVirPres", tutorias.VirPresIdVirPres);
            return View(tutorias);
        }

        // POST: Tutorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdTutorias,UsersIdUser,TutoresIdTutores,AsignaturaIdAsignatura,EstudiantesIdEstudiantes,TipoClaseIdTipoClase,VirPresIdVirPres,Transporte,Total,HoraInicio,HoraFin,CantidadHoras,Paga")] Tutorias tutorias)
        {
            if (id != tutorias.IdTutorias)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tutorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TutoriasExists(tutorias.IdTutorias))
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
            ViewData["AsignaturaIdAsignatura"] = new SelectList(_context.Asignatura, "IdAsignatura", "IdAsignatura", tutorias.AsignaturaIdAsignatura);
            ViewData["EstudiantesIdEstudiantes"] = new SelectList(_context.Estudiantes, "IdEstudiantes", "IdEstudiantes", tutorias.EstudiantesIdEstudiantes);
            ViewData["TipoClaseIdTipoClase"] = new SelectList(_context.TipoClase, "IdTipoClase", "IdTipoClase", tutorias.TipoClaseIdTipoClase);
            ViewData["TutoresIdTutores"] = new SelectList(_context.Tutores, "IdTutores", "IdTutores", tutorias.TutoresIdTutores);
            ViewData["UsersIdUser"] = new SelectList(_context.Users, "IdUser", "IdUser", tutorias.UsersIdUser);
            ViewData["VirPresIdVirPres"] = new SelectList(_context.Virpres, "IdVirPres", "IdVirPres", tutorias.VirPresIdVirPres);
            return View(tutorias);
        }

        // GET: Tutorias/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorias = await _context.Tutorias
                .Include(t => t.AsignaturaIdAsignaturaNavigation)
                .Include(t => t.EstudiantesIdEstudiantesNavigation)
                .Include(t => t.TipoClaseIdTipoClaseNavigation)
                .Include(t => t.TutoresIdTutoresNavigation)
                .Include(t => t.UsersIdUserNavigation)
                .Include(t => t.VirPresIdVirPresNavigation)
                .FirstOrDefaultAsync(m => m.IdTutorias == id);
            if (tutorias == null)
            {
                return NotFound();
            }

            return View(tutorias);
        }

        // POST: Tutorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var tutorias = await _context.Tutorias.FindAsync(id);
            _context.Tutorias.Remove(tutorias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TutoriasExists(long id)
        {
            return _context.Tutorias.Any(e => e.IdTutorias == id);
        }
    }
}
