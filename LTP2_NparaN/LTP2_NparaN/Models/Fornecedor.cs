using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTP2_NparaN.Models
{
    public class Fornecedor
    {
        public Fornecedor()
        {
            this.Produto = new HashSet<Produtos>();
        }

        [Key]
        public long IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }

        // navigation property to Product
        public virtual ICollection<Produtos> Produto { get; set; }
    }
}