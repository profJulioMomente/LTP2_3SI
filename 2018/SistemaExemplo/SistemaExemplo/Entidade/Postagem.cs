using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaExemplo.Entidade
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string TipoMidia { get; set; }
        public string Midia { get; set; }
        public string Texto { get; set; }
        public int Autor { get; set; }
    }
}