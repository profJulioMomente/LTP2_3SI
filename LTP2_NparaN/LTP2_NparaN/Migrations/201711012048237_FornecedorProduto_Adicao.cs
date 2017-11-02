namespace LTP2_NparaN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FornecedorProduto_Adicao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        IdFornecedor = c.Long(nullable: false, identity: true),
                        NomeFornecedor = c.String(),
                    })
                .PrimaryKey(t => t.IdFornecedor);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        IdProduto = c.Long(nullable: false, identity: true),
                        NomeProduto = c.String(),
                    })
                .PrimaryKey(t => t.IdProduto);
            
            CreateTable(
                "dbo.ProdutosFornecedors",
                c => new
                    {
                        Produtos_IdProduto = c.Long(nullable: false),
                        Fornecedor_IdFornecedor = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Produtos_IdProduto, t.Fornecedor_IdFornecedor })
                .ForeignKey("dbo.Produtos", t => t.Produtos_IdProduto, cascadeDelete: true)
                .ForeignKey("dbo.Fornecedors", t => t.Fornecedor_IdFornecedor, cascadeDelete: true)
                .Index(t => t.Produtos_IdProduto)
                .Index(t => t.Fornecedor_IdFornecedor);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProdutosFornecedors", "Fornecedor_IdFornecedor", "dbo.Fornecedors");
            DropForeignKey("dbo.ProdutosFornecedors", "Produtos_IdProduto", "dbo.Produtos");
            DropIndex("dbo.ProdutosFornecedors", new[] { "Fornecedor_IdFornecedor" });
            DropIndex("dbo.ProdutosFornecedors", new[] { "Produtos_IdProduto" });
            DropTable("dbo.ProdutosFornecedors");
            DropTable("dbo.Produtos");
            DropTable("dbo.Fornecedors");
        }
    }
}
