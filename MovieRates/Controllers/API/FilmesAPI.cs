using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRates.Data;
using MovieRates.Models;

namespace MovieRates.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmesAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FilmesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmesAPIViewModel>>> GetFilmes()
        {
            return await _context.Filmes.Select(f => new FilmesAPIViewModel
            {
                IdFilmes = f.IdFilmes,
                Titulo = f.Titulo,
                Pontuacao = f.Pontuacao,
                Capa = f.Capa
            })
                                                       .OrderBy(f => f.IdFilmes)
                                                       .ToListAsync();
        }

        // GET: api/FilmesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Filmes>> GetFilmes(int id)
        {
            var filmes = await _context.Filmes.FindAsync(id);

            if (filmes == null)
            {
                return NotFound();
            }

            return filmes;
        }

        // PUT: api/FilmesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilmes(int id, Filmes filmes)
        {
            if (id != filmes.IdFilmes)
            {
                return BadRequest();
            }

            _context.Entry(filmes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FilmesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Filmes>> PostFilmes(Filmes filmes)
        {
            _context.Filmes.Add(filmes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFilmes", new { id = filmes.IdFilmes }, filmes);
        }

        // DELETE: api/FilmesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmes(int id)
        {
            var filmes = await _context.Filmes.FindAsync(id);
            if (filmes == null)
            {
                return NotFound();
            }

            _context.Filmes.Remove(filmes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmesExists(int id)
        {
            return _context.Filmes.Any(e => e.IdFilmes == id);
        }
    }
}
