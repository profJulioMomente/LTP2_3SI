using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace MVC2018CodeFirst001.Models
{
    [Table("categoria")]
    public class categoria
    {
        [Key]
        public int idCategoria { get; set; }

        [Display(Name ="Categoria")]
        public string nomeCategoria { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }

}