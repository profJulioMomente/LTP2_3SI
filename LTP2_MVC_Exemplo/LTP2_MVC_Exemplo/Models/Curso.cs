using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTP2_MVC_Exemplo.Models
{
    public class Curso
    {
        [Key, ForeignKey("Coord")]
        public int id_curso { get; set; }
        [Display(Name ="Código")]
        public string codigo_curso { get; set; }
        [Display (Name ="Nome do Curso")]
        public string nome_curso { get; set; }
        [Display(Name ="Duração")]
        public string duracao_curso { get; set; }
        [Display(Name ="Enade")]
        public string enade_curso { get; set; }

        public virtual Coordenacao Coord { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }
    }
}