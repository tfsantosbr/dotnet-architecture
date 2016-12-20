using System.Data.Entity.Migrations;
using Project.Infrastructure.Contexts;

namespace Project.Infrastructure.Migrations.ResourceMigrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ResourceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
            MigrationsDirectory = @"Migrations\ResourceMigrations";
        }

        protected override void Seed(ResourceContext context)
        {
            //SeedClients(context);
            //SeedUsuarios(context);
            //SeedConteudos(context);
            //SeedEstudantes(context);
        }

        //private void SeedClients(ResourceContext context)
        //{
        //    if (context.Clients.Any())
        //        return;

        //    context.Clients.AddRange(new List<Client>
        //    {
        //        new Client
        //        {
        //            Id = "webApp",
        //            Secret = HashHelper.GetHash("abc@123"),
        //            Name = "AngularJS front-end Application",
        //            ApplicationType = ApplicationTypes.JavaScript,
        //            Active = true,
        //            RefreshTokenLifeTime = 12,
        //            AllowedOrigin = "http://localhost:21259"
        //        },
        //        new Client
        //        {
        //            Id = "consoleApp",
        //            Secret = HashHelper.GetHash("123@abc"),
        //            Name = "Console Application",
        //            ApplicationType = ApplicationTypes.NativeConfidential,
        //            Active = true,
        //            RefreshTokenLifeTime = 12,
        //            AllowedOrigin = "*"
        //        }
        //    });
        //    context.SaveChanges();
        //}

        //private void SeedUsuarios(ResourceContext context)
        //{
        //    if (context.Usuarios.Any())
        //        return;

        //    context.Usuarios.AddRange(new List<Usuario>()
        //    {
        //        new Usuario
        //        {
        //            CreationDate = DateTime.Now,
        //            Email = "teste1@gmail.com",
        //            EmailConfirmed = true,
        //            ModificationDate = DateTime.Now,
        //            SecurityStamp = "221504ed-c93c-46f8-a1c1-b74aad67bded",
        //            Senha = "AGY/LrMK2KNF7rSsvDmauCyc6hUMUF6J5KEevk1H4uzsOV2AicSHRZg9SH37UuYTEg==", // teste1@123
        //            UserName = "teste1@gmail.com"
        //        }
        //    });

        //    context.SaveChanges();
        //}

        //private void SeedConteudos(ResourceContext context)
        //{
        //    if (context.Conteudos.Any())
        //        return;


        //    context.Conteudos.AddRange(new List<Conteudo>()
        //    {
        //        new Conteudo
        //        {
        //            Titulo = "Conteudo Teste 01",
        //            Corpo = "Corpo do conteudo 01",
        //            Status = ConteudoStatus.Active,
        //            IdAutor = 1
        //        },
        //        new Conteudo
        //        {
        //            Titulo = "Conteudo Teste 02",
        //            Corpo = "Corpo do conteudo 02",
        //            Status = ConteudoStatus.Approved,
        //            IdAutor = 1
        //        },
        //        new Conteudo
        //        {
        //            Titulo = "Conteudo Teste 03",
        //            Corpo = "Corpo do conteudo 03",
        //            Status = ConteudoStatus.Evaluation,
        //            IdAutor = 1
        //        }
        //    });

        //    context.SaveChanges();
        //}

        //private void SeedEstudantes(ResourceContext context)
        //{
        //    if (context.Estudantes.Any())
        //        return;

        //    context.Estudantes.AddRange(new List<Estudante>()
        //    {
        //        new Estudante
        //        {
        //            Nome = "Estudante Teste 01",
        //        },
        //        new Estudante
        //        {
        //            Nome = "Estudante Teste 02",
        //        },
        //        new Estudante
        //        {
        //            Nome = "Estudante Teste 03",
        //        }
        //    });

        //    context.SaveChanges();
        //}
    }
}