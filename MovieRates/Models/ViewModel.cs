using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRates.Models
{
    public class FilmesAPIViewModel
    {
        /// <summary>
        /// Identificador do filme
        /// </summary>
        public int IdFilmes { get; set; }

        /// <summary>
        /// Título do filme
        /// </summary> 
        public string Titulo { get; set; }

        /// <summary>
        /// Capa do filme
        /// </summary>
        public string Capa { get; set; }

        /// <summary>
        /// Pontuação do filme
        /// </summary>
        public double Pontuacao { get; set; }
    }
}
