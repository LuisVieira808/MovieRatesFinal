﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRates.Data;
using MovieRates.Models;

namespace MovieRates.Controllers
{
    public class ReviewsController : Controller
    {
        /// <summary>
        /// atributo que representa a Base de Dados do projeto
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// variavel que recolhe os dados da pessoa que se autenticou
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reviews.Include(r => r.Filme).Include(r => r.Utilizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Filme)
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.IdReview == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa");
            ViewData["UtilizadoresFK"] = new SelectList(_context.Utilizadores, "IdUtilizador", "Email");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdReview,Comentario,Pontuacao,Data,UtilizadoresFK,FilmesFK")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa", reviews.FilmesFK);
            ViewData["UtilizadoresFK"] = new SelectList(_context.Utilizadores, "IdUtilizador", "Email", reviews.UtilizadoresFK);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa", reviews.FilmesFK);
            ViewData["UtilizadoresFK"] = new SelectList(_context.Utilizadores, "IdUtilizador", "Email", reviews.UtilizadoresFK);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdReview,Comentario,Pontuacao,Data,UtilizadoresFK,FilmesFK,Visibilidade")] Reviews reviews)
        {
            if (id != reviews.IdReview)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.IdReview))
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
            ViewData["FilmesFK"] = new SelectList(_context.Filmes, "IdFilmes", "Capa", reviews.FilmesFK);
            ViewData["UtilizadoresFK"] = new SelectList(_context.Utilizadores, "IdUtilizador", "Email", reviews.UtilizadoresFK);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Filme)
                .Include(r => r.Utilizador)
                .FirstOrDefaultAsync(m => m.IdReview == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //recolher dados do utilizador
            var utilizador = _context.Utilizadores.Where(u => u.UserNameId == _userManager.GetUserId(User)).FirstOrDefault();
            //como foi apagada a Review o utilizador pode colocar outra
            utilizador.ControlarReview = false;
            //guardar a alteração na Base de Dados
            _context.Utilizadores.Update(utilizador);

            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Filmes", new { id = reviews.FilmesFK });
        }


        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.IdReview == id);
        }
    }
}
