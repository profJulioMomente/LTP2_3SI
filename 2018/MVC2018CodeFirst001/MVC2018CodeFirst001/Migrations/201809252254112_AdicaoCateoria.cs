namespace MVC2018CodeFirst001.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoCateoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categoria",
                c => new
                    {
                        idCategoria = c.Int(nullable: false, identity: true),
                        nomeCategoria = c.String(),
                    })
                .PrimaryKey(t => t.idCategoria);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.categoria");
        }
    }
}
