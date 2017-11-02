namespace LTP2_MVC_Exemplo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Curso_Coordenacao_Relacao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coordenacaos",
                c => new
                    {
                        id_Coordenacao = c.Int(nullable: false, identity: true),
                        nome_Coordenacao = c.String(),
                        atendimento_Coordenacao = c.String(),
                    })
                .PrimaryKey(t => t.id_Coordenacao);
            
            CreateTable(
                "dbo.Cursoes",
                c => new
                    {
                        id_curso = c.Int(nullable: false),
                        codigo_curso = c.String(),
                        nome_curso = c.String(),
                        duracao_curso = c.String(),
                        enade_curso = c.String(),
                    })
                .PrimaryKey(t => t.id_curso)
                .ForeignKey("dbo.Coordenacaos", t => t.id_curso)
                .Index(t => t.id_curso);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursoes", "id_curso", "dbo.Coordenacaos");
            DropIndex("dbo.Cursoes", new[] { "id_curso" });
            DropTable("dbo.Cursoes");
            DropTable("dbo.Coordenacaos");
        }
    }
}
