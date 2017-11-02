using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LTP2_MVC_Exemplo.Models
{
    public class Aluno
    {
        [Key]
        public int  id_Aluno { get; set; }

        [Required]
        [Display (Name ="Nome")]
        public string nome_Aluno { get; set; }
        
        [Index(IsUnique =true)]
        [Display (Name ="RA")]
        public string ra_Aluno { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display (Name= "E-mail")]
        public string email_Aluno { get; set; }

        public virtual ICollection<Disciplina> Disciplinas { get; set; }

        public Aluno()
        {
            Disciplinas = new HashSet<Disciplina>();
        }
    }
}