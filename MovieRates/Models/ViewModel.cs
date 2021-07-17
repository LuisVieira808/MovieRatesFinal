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

        /// <summary>
        /// Nome do Realizador
        /// </summary>
        public string Realizador { get; set; }


        /// <summary>
        /// Link da Stream
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Breve descrição sobre o filme
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Duração do filme
        /// </summary>
        public string Duracao { get; set; }

        /// <summary>
        /// Nome do Elenco
        /// </summary>
        public string Elenco { get; set; }
    }
}
