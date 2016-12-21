namespace Project.Infrastructure.Migrations.ResourceMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conteudo_Update : DbMigration
    {
        public override void Up()
        {
            DropIndex("Publicacoes.Conteudo", new[] { "IdAuditor" });
            AlterColumn("Publicacoes.Conteudo", "IdAuditor", c => c.Guid());
            CreateIndex("Publicacoes.Conteudo", "IdAuditor");
        }
        
        public override void Down()
        {
            DropIndex("Publicacoes.Conteudo", new[] { "IdAuditor" });
            AlterColumn("Publicacoes.Conteudo", "IdAuditor", c => c.Guid(nullable: false));
            CreateIndex("Publicacoes.Conteudo", "IdAuditor");
        }
    }
}
