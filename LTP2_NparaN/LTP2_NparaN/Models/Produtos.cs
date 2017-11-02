using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTP2_NparaN.Models
{
    public class Produtos
    {
        public Produtos()
        {
            this.Fornecedor = new HashSet<Fornecedor>();
        }

        [Key]
        public long IdProduto { get; set; }
        public string NomeProduto { get; set; }

        //navigation property to Supplier
        public virtual ICollection<Fornecedor> Fornecedor { get; set; }
    }
}
