﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LTP2DatabaseFirst.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LTP2MVCDatabaseFirst2018Entities : DbContext
    {
        public LTP2MVCDatabaseFirst2018Entities()
            : base("name=LTP2MVCDatabaseFirst2018Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<pessoa> pessoas { get; set; }
        public virtual DbSet<produto> produtoes { get; set; }
        public virtual DbSet<categoria> categorias { get; set; }
    }
}
