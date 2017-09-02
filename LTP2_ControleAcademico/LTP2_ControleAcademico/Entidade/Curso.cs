using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LTP2_ControleAcademico.Entidade
{
    public class Curso
    {
        public int ID_Curso { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Periodo { get; set; }
        public string Duracao { get; set; }
        public string Enade { get; set; }
    }
}