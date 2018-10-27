namespace MVC2018CodeFirst001.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChaveEstrangeira : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "idCategoria", c => c.Int(nullable: false));
            CreateIndex("dbo.Produtoes", "idCategoria");
            AddForeignKey("dbo.Produtoes", "idCategoria", "dbo.categoria", "idCategoria", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "idCategoria", "dbo.categoria");
            DropIndex("dbo.Produtoes", new[] { "idCategoria" });
            DropColumn("dbo.Produtoes", "idCategoria");
        }
    }
}
