using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTP2_MVC_Exemplo.Models
{
    public class AlunoDisciplina
    {
        [Key]
        public int id_AlunoDisciplina { get; set; }

        [ForeignKey("Aluno")]
        public int id_Aluno { get; set; }

        public virtual Aluno Aluno { get; set; }

        [ForeignKey("Disciplina")]
        public int id_Disciplina { get; set; }

        public virtual Disciplina Disciplina { get; set; }
    }
}