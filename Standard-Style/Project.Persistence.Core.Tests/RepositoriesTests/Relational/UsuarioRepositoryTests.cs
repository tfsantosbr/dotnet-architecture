using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories;

namespace Project.Persistence.Publicacoes.Tests.RepositoriesTests
{
    [TestClass]
    public class UsuarioRepositoryTests
    {
        [TestMethod]
        public void UsuarioRepositoryTests_Insert()
        {
            IUsuarioRepository<Guid> rep = new UsuarioRepository(new CoreContext());

            rep.Create(new Usuario
            {
                Id = new Guid("3038d24c-1bde-4f31-8777-bcbce4865af1"),
                CreationDate = DateTime.Now,
                Email = "teste1@gmail.com",
                EmailConfirmed = true,
                ModificationDate = DateTime.Now,
                SecurityStamp = "221504ed-c93c-46f8-a1c1-b74aad67bded",
                Senha = "AGY/LrMK2KNF7rSsvDmauCyc6hUMUF6J5KEevk1H4uzsOV2AicSHRZg9SH37UuYTEg==", // teste1@123
                UserName = "teste1@gmail.com"
            });
        }
    }
}
