using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRates.Models {
    public class Favoritos {

        /// <summary>
        /// Identificador da lista de favoritos
        /// </summary>
        [Key]
        public int IdFavoritos { get; set; }

        //*****************************
        /// <summary>
        /// Fk para o Utilizador
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadoresFK { get; set; }
        public Utilizadores Utilizador { get; set; }


        /// <summary>
        /// FK para o Filme
        /// </summary>
        [ForeignKey(nameof(Filme))]
        public int FilmesFK { get; set; }
        public Filmes Filme { get; set; }



    }
}
