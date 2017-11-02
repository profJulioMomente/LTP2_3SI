using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTP2_MVC_Exemplo.Models
{
    public class Coordenacao
    {
        [Key]
        public int id_Coordenacao { get; set; }
        [Display(Name ="Coordenador")]
        public string nome_Coordenacao { get; set; }
        [Display (Name = "Atendimento")]
        public string atendimento_Coordenacao { get; set; }

        public virtual Curso Curso { get; set; }
    }
}