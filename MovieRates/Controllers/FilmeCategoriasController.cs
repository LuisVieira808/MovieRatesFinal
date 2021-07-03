using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRates.Data;
using MovieRates.Models;

namespace MovieRates.Controllers
{
    public class FilmeCategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmeCategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FilmeCategorias
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FilmeCategorias.Include(f => f.Categoria).Include(f => f.Filme);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FilmeCategorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeCategorias = await _context.FilmeCategorias
                .Include(f => f.Categoria)
                .Include(f => f.Filme)
                .FirstOrDefaultAsync(m => m.IdFilmeCategorias == id);
            if (filmeCategorias == null)
            {
                return NotFound();
            }

            return View(filmeCategorias);
        }

        // GET: FilmeCategorias/Create
        public IActionResult Create()
        {
            ViewData["CategoriasFK"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias");
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa");
            return View();
        }

        // POST: FilmeCategorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFilmeCategorias,CategoriasFK,FilmesFK")] FilmeCategorias filmeCategorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filmeCategorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriasFK"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", filmeCategorias.CategoriasFK);
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa", filmeCategorias.FilmesFK);
            return View(filmeCategorias);
        }

        // GET: FilmeCategorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeCategorias = await _context.FilmeCategorias.FindAsync(id);
            if (filmeCategorias == null)
            {
                return NotFound();
            }
            ViewData["CategoriasFK"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", filmeCategorias.CategoriasFK);
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa", filmeCategorias.FilmesFK);
            return View(filmeCategorias);
        }

        // POST: FilmeCategorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFilmeCategorias,CategoriasFK,FilmesFK")] FilmeCategorias filmeCategorias)
        {
            if (id != filmeCategorias.IdFilmeCategorias)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmeCategorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeCategoriasExists(filmeCategorias.IdFilmeCategorias))
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
            ViewData["CategoriasFK"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", filmeCategorias.CategoriasFK);
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa", filmeCategorias.FilmesFK);
            return View(filmeCategorias);
        }

        // GET: FilmeCategorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmeCategorias = await _context.FilmeCategorias
                .Include(f => f.Categoria)
                .Include(f => f.Filme)
                .FirstOrDefaultAsync(m => m.IdFilmeCategorias == id);
            if (filmeCategorias == null)
            {
                return NotFound();
            }

            return View(filmeCategorias);
        }

        // POST: FilmeCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmeCategorias = await _context.FilmeCategorias.FindAsync(id);
            _context.FilmeCategorias.Remove(filmeCategorias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmeCategoriasExists(int id)
        {
            return _context.FilmeCategorias.Any(e => e.IdFilmeCategorias == id);
        }
    }
}