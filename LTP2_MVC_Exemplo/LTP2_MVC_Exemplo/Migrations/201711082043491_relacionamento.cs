namespace LTP2_MVC_Exemplo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionamento : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DisciplinaAlunoes", "Disciplina_id_Disciplina", "dbo.Disciplinas");
            DropForeignKey("dbo.DisciplinaAlunoes", "Aluno_id_Aluno", "dbo.Alunoes");
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Disciplina_id_Disciplina" });
            DropIndex("dbo.DisciplinaAlunoes", new[] { "Aluno_id_Aluno" });
            CreateTable(
                "dbo.AlunoDisciplinas",
                c => new
                    {
                        id_AlunoDisciplina = c.Int(nullable: false, identity: true),
                        id_Aluno = c.Int(nullable: false),
                        id_Disciplina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id_AlunoDisciplina)
                .ForeignKey("dbo.Alunoes", t => t.id_Aluno, cascadeDelete: true)
                .ForeignKey("dbo.Disciplinas", t => t.id_Disciplina, cascadeDelete: true)
                .Index(t => t.id_Aluno)
                .Index(t => t.id_Disciplina);
            
            DropTable("dbo.DisciplinaAlunoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DisciplinaAlunoes",
                c => new
                    {
                        Disciplina_id_Disciplina = c.Int(nullable: false),
                        Aluno_id_Aluno = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disciplina_id_Disciplina, t.Aluno_id_Aluno });
            
            DropForeignKey("dbo.AlunoDisciplinas", "id_Disciplina", "dbo.Disciplinas");
            DropForeignKey("dbo.AlunoDisciplinas", "id_Aluno", "dbo.Alunoes");
            DropIndex("dbo.AlunoDisciplinas", new[] { "id_Disciplina" });
            DropIndex("dbo.AlunoDisciplinas", new[] { "id_Aluno" });
            DropTable("dbo.AlunoDisciplinas");
            CreateIndex("dbo.DisciplinaAlunoes", "Aluno_id_Aluno");
            CreateIndex("dbo.DisciplinaAlunoes", "Disciplina_id_Disciplina");
            AddForeignKey("dbo.DisciplinaAlunoes", "Aluno_id_Aluno", "dbo.Alunoes", "id_Aluno", cascadeDelete: true);
            AddForeignKey("dbo.DisciplinaAlunoes", "Disciplina_id_Disciplina", "dbo.Disciplinas", "id_Disciplina", cascadeDelete: true);
        }
    }
}
