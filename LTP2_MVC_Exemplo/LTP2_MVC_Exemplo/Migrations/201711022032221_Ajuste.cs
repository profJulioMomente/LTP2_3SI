namespace LTP2_MVC_Exemplo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajuste : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Alunoes", "nome_Aluno", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Alunoes", "nome_Aluno", c => c.String());
        }
    }
}
