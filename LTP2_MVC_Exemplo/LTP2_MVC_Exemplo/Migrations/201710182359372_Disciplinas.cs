namespace LTP2_MVC_Exemplo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Disciplinas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        id_Disciplina = c.Int(nullable: false, identity: true),
                        nome_Disciplia = c.String(),
                        codigo_Disciplina = c.String(),
                        periodo_Disciplina = c.String(),
                        id_Curso = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_Disciplina)
                .ForeignKey("dbo.Cursoes", t => t.id_Curso, cascadeDelete: true)
                .Index(t => t.id_Curso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Disciplinas", "id_Curso", "dbo.Cursoes");
            DropIndex("dbo.Disciplinas", new[] { "id_Curso" });
            DropTable("dbo.Disciplinas");
        }
    }
}
