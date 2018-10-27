using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_LTP2_CodeFirst002.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }

        public string nomeCategoria { get; set; }
    }
}