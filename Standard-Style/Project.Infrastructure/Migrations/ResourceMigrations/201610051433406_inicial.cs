namespace Project.Infrastructure.Migrations.ResourceMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Core.Client",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Secret = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        ApplicationType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RefreshTokenLifeTime = c.Int(nullable: false),
                        AllowedOrigin = c.String(maxLength: 100),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Publicacoes.Conteudo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Corpo = c.String(nullable: false),
                        IdAutor = c.Long(nullable: false),
                        IdAuditor = c.Long(),
                        Status = c.Byte(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Usuario", t => t.IdAuditor)
                .ForeignKey("Core.Usuario", t => t.IdAutor)
                .Index(t => t.IdAutor)
                .Index(t => t.IdAuditor);
            
            CreateTable(
                "Core.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        Senha = c.String(),
                        SecurityStamp = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Universidade.Curso",
                c => new
                    {
                        Id = c.Short(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 30),
                        ProfessorId = c.Long(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Universidade.Professor", t => t.ProfessorId)
                .Index(t => t.ProfessorId);
            
            CreateTable(
                "Universidade.Matricula",
                c => new
                    {
                        CursoId = c.Short(nullable: false),
                        EstudanteId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.CursoId, t.EstudanteId })
                .ForeignKey("Universidade.Curso", t => t.CursoId)
                .ForeignKey("Universidade.Estudante", t => t.EstudanteId)
                .Index(t => t.CursoId)
                .Index(t => t.EstudanteId);
            
            CreateTable(
                "Universidade.Estudante",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Universidade.Nota",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CursoId = c.Short(nullable: false),
                        EstudanteId = c.Long(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.Id, t.CursoId, t.EstudanteId })
                .ForeignKey("Universidade.Matricula", t => new { t.CursoId, t.EstudanteId })
                .Index(t => new { t.CursoId, t.EstudanteId });
            
            CreateTable(
                "Core.RefreshToken",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Browser = c.String(nullable: false, maxLength: 50),
                        Subject = c.String(nullable: false, maxLength: 50),
                        ClientId = c.String(nullable: false, maxLength: 50),
                        IssuedUtc = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExpiresUtc = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ProtectedTicket = c.Binary(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.Id, t.Browser });
            
            CreateTable(
                "Core.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Core.UsuarioClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUsuario = c.Long(nullable: false),
                        Tipo = c.String(),
                        Valor = c.String(),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario);
            
            CreateTable(
                "Core.UsuarioRole",
                c => new
                    {
                        IdUsuario = c.Long(nullable: false),
                        IdPerfil = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModificationDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ExclusionDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => new { t.IdUsuario, t.IdPerfil })
                .ForeignKey("Core.Role", t => t.IdPerfil)
                .ForeignKey("Core.Usuario", t => t.IdUsuario)
                .Index(t => t.IdUsuario)
                .Index(t => t.IdPerfil);
            
            CreateTable(
                "Universidade.Professor",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Salario = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Core.Usuario", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Universidade.Professor", "Id", "Core.Usuario");
            DropForeignKey("Core.UsuarioRole", "IdUsuario", "Core.Usuario");
            DropForeignKey("Core.UsuarioRole", "IdPerfil", "Core.Role");
            DropForeignKey("Core.UsuarioClaim", "IdUsuario", "Core.Usuario");
            DropForeignKey("Publicacoes.Conteudo", "IdAutor", "Core.Usuario");
            DropForeignKey("Publicacoes.Conteudo", "IdAuditor", "Core.Usuario");
            DropForeignKey("Universidade.Curso", "ProfessorId", "Universidade.Professor");
            DropForeignKey("Universidade.Nota", new[] { "CursoId", "EstudanteId" }, "Universidade.Matricula");
            DropForeignKey("Universidade.Matricula", "EstudanteId", "Universidade.Estudante");
            DropForeignKey("Universidade.Matricula", "CursoId", "Universidade.Curso");
            DropIndex("Universidade.Professor", new[] { "Id" });
            DropIndex("Core.UsuarioRole", new[] { "IdPerfil" });
            DropIndex("Core.UsuarioRole", new[] { "IdUsuario" });
            DropIndex("Core.UsuarioClaim", new[] { "IdUsuario" });
            DropIndex("Universidade.Nota", new[] { "CursoId", "EstudanteId" });
            DropIndex("Universidade.Matricula", new[] { "EstudanteId" });
            DropIndex("Universidade.Matricula", new[] { "CursoId" });
            DropIndex("Universidade.Curso", new[] { "ProfessorId" });
            DropIndex("Publicacoes.Conteudo", new[] { "IdAuditor" });
            DropIndex("Publicacoes.Conteudo", new[] { "IdAutor" });
            DropTable("Universidade.Professor");
            DropTable("Core.UsuarioRole");
            DropTable("Core.UsuarioClaim");
            DropTable("Core.Role");
            DropTable("Core.RefreshToken");
            DropTable("Universidade.Nota");
            DropTable("Universidade.Estudante");
            DropTable("Universidade.Matricula");
            DropTable("Universidade.Curso");
            DropTable("Core.Usuario");
            DropTable("Publicacoes.Conteudo");
            DropTable("Core.Client");
        }
    }
}
