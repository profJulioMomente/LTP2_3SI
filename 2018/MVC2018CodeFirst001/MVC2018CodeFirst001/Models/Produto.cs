using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC2018CodeFirst001.Models
{
    public class Produto
    {
        [Key]
        public int idProduto { get; set; }

        [Display(Name ="Nome")]
        public string nomeProduto { get; set; }

        [Display(Name ="Descrição")]
        public string descricaoProduto { get; set; }

        [Display(Name ="Preço")]
        public decimal preco { get; set; }

        [Display(Name ="Categoria")]
        public int idCategoria { get; set; }

        [ForeignKey("idCategoria")]
        public virtual categoria categoria { get; set; }

    }
}