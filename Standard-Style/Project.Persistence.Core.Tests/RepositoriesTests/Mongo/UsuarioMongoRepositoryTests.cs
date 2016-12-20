﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories;

namespace Project.Persistence.Publicacoes.Tests.RepositoriesTests
{
    [TestClass]
    public class UsuarioMongoRepositoryTests
    {
        [TestMethod]
        public void UsuarioMongoRepositoryTests_Insert()
        {
            IUsuarioRepository<Guid> rep = new UsuarioMongoRepository(new CoreMongoContext());

            rep.Create(new Usuario
            {
                Id = Guid.NewGuid(),
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
