using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTP2_MVC_Exemplo.Models
{
    public class Disciplina
    {
        [Key]
        public int id_Disciplina { get; set; }
        [Display(Name ="Nome")]
        public string nome_Disciplia { get; set; }
        [Display(Name ="Código")]
        public string codigo_Disciplina { get; set; }
        [Display(Name ="Período")]
        public string periodo_Disciplina { get; set; }

        [ForeignKey("Curso")]
        public int id_Curso { get; set; }

        public virtual Curso Curso { get; set; }

        public ICollection<AlunoDisciplina>

    }
}