using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRates.Data;
using MovieRates.Models;


namespace MovieRates.Controllers
{

    public class FilmesController : Controller
    {
        /// <summary>
        /// atributo que representa a base de dados do projeto
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// atributo que contém os dados da app web no servidor
        /// </summary>
        private readonly IWebHostEnvironment _caminho;
        
        /// <summary>
        /// variavel que recolhe os dados da pessoa que se autenticou
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;


        public FilmesController(ApplicationDbContext context, IWebHostEnvironment caminho, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _caminho = caminho;
            _userManager = userManager;
        }

        // GET: Filmes
        public async Task<IActionResult> Index()
        {


            return View(await _context.Filmes.ToListAsync());
        }

        // GET: Filmes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filmes
                .Where(f => f.IdFilmes == id)
                .Include(f => f.ListaDeReviews)
                .ThenInclude(r => r.Utilizador)
                .OrderByDescending(f => f.Data)
                .Include(fc => fc.ListaDeCategorias)
                .FirstOrDefaultAsync();
            if (filme == null)
            {
                return NotFound();
            }
            if (User.Identity.IsAuthenticated) {
                //recolher dados do utilizador
                var utilizador = _context.Utilizadores.Where(u => u.UserNameId == _userManager.GetUserId(User)).FirstOrDefault();

                var favorito = await _context.Favoritos.Where(f => f.FilmesFK == id && f.UtilizadoresFK == utilizador.IdUtilizador).FirstOrDefaultAsync();

                if (favorito == null) {
                    ViewBag.Favorito = false;
                } else {
                    ViewBag.Favorito = true;
                }

            }



            return View(filme);
        }



        /// <summary>
        /// Metodo para apresentar os comentarios feitos pelos utilizadores
        /// </summary>
        /// <param name="IdFilmes"></param>
        /// <param name="comentario"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateComentario(int IdFilmes, string comentario, int rating) {
            //recolher dados do utilizador
            var utilizador = _context.Utilizadores.Where(u => u.UserNameId == _userManager.GetUserId(User)).FirstOrDefault();

            // será que este user já fez um comentário sobre este filme?
            var oldComentario = await _context.Reviews.Where(r => r.Utilizador == utilizador && r.FilmesFK == IdFilmes).FirstOrDefaultAsync();

            if (oldComentario == null) {
                //variavel que contem os dados da review, do utilizador e sobre qual filme foi feita review
                var comment = new Reviews {
                FilmesFK = IdFilmes,
                Comentario = comentario.Replace("\r\n", "<br />"),
                Pontuacao = rating,
                Data = DateTime.Now,
                Visibilidade = true,
                Utilizador = utilizador
            };
                //adiciona a review à Base de Dados
                _context.Reviews.Add(comment);
                //o utilizador já fez a sua review
                utilizador.ControlarReview = true;
                //guardar a alteração na Base de Dados
                _context.Utilizadores.Update(utilizador);
                //Guarda as alterações na Base de Dados
                await _context.SaveChangesAsync();
                //redirecionar para a página dos details do filme
                return RedirectToAction(nameof(Details),new { id = IdFilmes});
            } else {
                return RedirectToAction(nameof(Details), new { id = IdFilmes });
            }
            
            
        }

        public async Task<IActionResult> AdicionarFavoritos(int IdFilmes) {
            //recolher dados do utilizador
            var utilizador = _context.Utilizadores.Where(u => u.UserNameId == _userManager.GetUserId(User)).FirstOrDefault();

            var favorito = await _context.Favoritos.Where(f => f.FilmesFK == IdFilmes && f.UtilizadoresFK == utilizador.IdUtilizador).FirstOrDefaultAsync();

            if (favorito == null) {
                //variavel que contem dados do utilizador e do filme 
                var fav = new Favoritos {
                    FilmesFK = IdFilmes,
                    UtilizadoresFK = utilizador.IdUtilizador
                };
                //Adiciona o filme à Base de Dados
                _context.Favoritos.Add(fav);
                //Guarda as alterações na Base de Dados
                await _context.SaveChangesAsync();
                //redirecionar para a página dos details do filme
                return RedirectToAction(nameof(Details), new { id = IdFilmes });
            } else {
                //remove da base de dados 
                _context.Favoritos.Remove(favorito);
                //Guarda as alterações na Base de Dados
                await _context.SaveChangesAsync();
                //redirecionar para a página dos details do filme
                return RedirectToAction(nameof(Details), new { id = IdFilmes });
            }
        }

        // GET: Filmes/Create
        public IActionResult Create()
        {
            ViewBag.ListaDeCategorias = _context.ListaDeCategorias.OrderBy(c => c.IdCategorias).ToList();
            return View();
        }
        
        // POST: Filmes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFilmes,Titulo,Data,Capa,Realizador,Elenco,Descricao,Categoria,Link,Duracao,Pontuacao")] Filmes filmes,
            IFormFile imgFile, int[] CategoriaEscolhida)
        {

            // avalia se o array com a lista de categorias escolhidas associadas ao filme está vazio ou não
            if (CategoriaEscolhida.Length == 0) {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                // gerar a lista Categorias que podem ser associadas ao filme
                ViewBag.ListaDeCategorias = _context.ListaDeCategorias.OrderBy(c => c.IdCategorias).ToList();
                // devolver controlo à View
                return View(filmes);
            }

            // criar uma lista com os objetos escolhidos das Categorias
            List<Categorias> listaDeCategoriasEscolhidas = new List<Categorias>();
            // Para cada objeto escolhido..
            foreach (int item in CategoriaEscolhida) {
                //procurar a categoria
                Categorias Categoria = _context.ListaDeCategorias.Find(item);
                // adicionar a Categoria à lista
                listaDeCategoriasEscolhidas.Add(Categoria);
            }

            // adicionar a lista ao objeto de "filme"
            filmes.ListaDeCategorias = listaDeCategoriasEscolhidas;





            filmes.Capa = imgFile.FileName;

            //_webhost.WebRootPath vai ter o path para a pasta wwwroot
            var saveimg = Path.Combine(_caminho.WebRootPath, "fotos", imgFile.FileName);

            var imgext = Path.GetExtension(imgFile.FileName);

            if (imgext == ".jpg" || imgext == ".png" || imgext == ".JPG" || imgext == ".PNG") {
                using (var uploadimg = new FileStream(saveimg, FileMode.Create)) {
                    await imgFile.CopyToAsync(uploadimg);

                }
            }

            if (ModelState.IsValid) {
                _context.Add(filmes);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(filmes);

        }
        
        // GET: Filmes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.ListaDeCategorias = _context.ListaDeCategorias.OrderBy(c => c.IdCategorias).ToList();
            var filmes = await _context.Filmes.FindAsync(id);
            if (filmes == null)
            {
                return NotFound();
            }
            return View(filmes);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFilmes,Titulo,Data,Capa,Realizador,Elenco,Descricao,Categoria,Link,Duracao,Pontuacao")] Filmes filmes,
            IFormFile imgFile, int[] CategoriaEscolhida)
        {
            if (id != filmes.IdFilmes) {
                return NotFound();
            }
            // avalia se o array com a lista de categorias escolhidas associadas ao filme está vazio ou não
            if (CategoriaEscolhida.Length == 0) {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                // gerar a lista Categorias que podem ser associadas ao filme
                ViewBag.ListaDeCategorias = _context.ListaDeCategorias.OrderBy(c => c.IdCategorias).ToList();
                // devolver controlo à View
                return View(filmes);
            }

            // criar uma lista com os objetos escolhidos das Categorias
            List<Categorias> listaDeCategoriasEscolhidas = new List<Categorias>();
            // Para cada objeto escolhido..
            foreach (int item in CategoriaEscolhida) {
                //procurar a categoria
                Categorias Categoria = _context.ListaDeCategorias.Find(item);
                // adicionar a Categoria à lista
                listaDeCategoriasEscolhidas.Add(Categoria);
            }

            // adicionar a lista ao objeto de "filme"
            filmes.ListaDeCategorias = listaDeCategoriasEscolhidas;




            /**************************************************/
            if (imgFile !=null) {
                filmes.Capa = imgFile.FileName;

                //_webhost.WebRootPath vai ter o path para a pasta wwwroot
                var saveimg = Path.Combine(_caminho.WebRootPath, "fotos", imgFile.FileName);

                var imgext = Path.GetExtension(imgFile.FileName);

                if (imgext == ".jpg" || imgext == ".png" || imgext == ".JPG" || imgext == ".PNG") {
                    using (var uploadimg = new FileStream(saveimg, FileMode.Create)) {
                        await imgFile.CopyToAsync(uploadimg);

                    }
                }
            } else {
                Filmes filmes1 = _context.Filmes.Find(filmes.IdFilmes);

                _context.Entry<Filmes>(filmes1).State = EntityState.Detached;


                filmes.Capa = filmes1.Capa;
            }
            
            /***************************************************/
            if (ModelState.IsValid) {
                _context.Update(filmes);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            return View(filmes);





















            /*
            if (id != filmes.IdFilmes)
            {
                return NotFound();
            }
            if (CategoriaEscolhida.Length == 0) {
                //É gerada uma mensagem de erro
                ModelState.AddModelError("", "É necessário selecionar pelo menos uma categoria.");
                // gerar a lista Categorias que podem ser associadas ao anime
                ViewBag.ListaDeCategorias = _context.ListaDeCategorias.OrderBy(c => c.IdCategorias).ToList();
                // devolver controlo à View
                return View(filmes);
            }

            // criar uma lista com os objetos escolhidos das Categorias
            List<Categorias> listaDeCategoriasEscolhidas = new List<Categorias>();
            // Para cada objeto escolhido..
            foreach (int item in CategoriaEscolhida) {
                //procurar a categoria
                Categorias Categoria = _context.ListaDeCategorias.Find(item);
                // adicionar a Categoria à lista
                listaDeCategoriasEscolhidas.Add(Categoria);
            }

            // adicionar a lista ao objeto de "Lesson"
            filmes.ListaDeCategorias = listaDeCategoriasEscolhidas;
            filmes.Capa = imgFile.FileName;
            //_webhost.WebRootPath vai ter o path para a pasta wwwroot
            var saveimg = Path.Combine(_caminho.WebRootPath, "fotos", imgFile.FileName);

            var imgext = Path.GetExtension(imgFile.FileName);

            if (imgext == ".jpg" || imgext == ".png" || imgext == ".JPG" || imgext == ".PNG") {
                using (var uploadimg = new FileStream(saveimg, FileMode.Create)) {
                    await imgFile.CopyToAsync(uploadimg);

                }
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(filmes);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!FilmesExists(filmes.IdFilmes)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filmes);*/
        }

        // GET: Filmes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmes = await _context.Filmes
                .FirstOrDefaultAsync(m => m.IdFilmes == id);
            if (filmes == null)
            {
                return NotFound();
            }

            return View(filmes);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filmes = await _context.Filmes.FindAsync(id);
            _context.Filmes.Remove(filmes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmesExists(int id)
        {
            return _context.Filmes.Any(e => e.IdFilmes == id);
        }
    }
}
