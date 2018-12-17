namespace WASTcnologia.AcessoDados.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarTabelaAluno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluno",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Endereco = c.String(nullable: false, maxLength: 100),
                        Mensalidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Aluno");
        }
    }
}
