namespace LTP2_MVC_Exemplo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicaoAlunos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunoes",
                c => new
                    {
                        id_Aluno = c.Int(nullable: false, identity: true),
                        nome_Aluno = c.String(),
                        ra_Aluno = c.String(),
                        email_Aluno = c.String(),
                    })
                .PrimaryKey(t => t.id_Aluno);
            
            CreateTable(
                "dbo.DisciplinaAlunoes",
                c => new
                    {
                        Disciplina_id_Disciplina = c.Int(nullable: false),
                        Aluno_id_Aluno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disciplina_id_Disciplina, t.Aluno_id_Aluno })
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_id_Disciplina, cascadeDelete: true)
                .ForeignKey("dbo.Alunoes", t => t.Aluno_id_Aluno, cascadeDelete: true)
                .Index(t => t.Disciplina_id_Disciplina)
                .Index(t => t.Aluno_id_Aluno);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisciplinaAlunoes", "Aluno_id_Aluno", "dbo.Alunoes");
            DropForeignKey("dbo.DisciplinaAlunoes", "Disciplina_id_Disciplina", "dbo.Disciplinas");
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Aluno_id_Aluno" });
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Disciplina_id_Disciplina" });
            DropTable("dbo.DisciplinaAlunoes");
            DropTable("dbo.Alunoes");
        }
    }
}
