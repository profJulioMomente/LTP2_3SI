namespace LTP2_MVC_Exemplo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoCursos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        id_curso = c.Int(nullable: false, identity: true),
                        codigo_curso = c.String(),
                        nome_curso = c.String(),
                        duracao_curso = c.String(),
                        enade_curso = c.String(),
                    })
                .PrimaryKey(t => t.id_curso);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cursoes");
        }
    }
}
