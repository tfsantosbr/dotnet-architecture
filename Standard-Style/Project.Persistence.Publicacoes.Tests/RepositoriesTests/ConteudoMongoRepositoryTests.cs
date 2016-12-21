using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models.Publicacoes.Entities;
using Project.Persistence.Publicacoes.Contexts;
using Project.Persistence.Publicacoes.Interfaces;
using Project.Persistence.Publicacoes.Repositories;

namespace Project.Persistence.Publicacoes.Tests.RepositoriesTests
{
    [TestClass]
    public class ConteudoMongoRepositoryTests
    {
        [TestMethod]
        public void ConteudoMongoRepositoryTests_Insert()
        {
            IConteudoRepository rep = new ConteudoMongoRepository(new PublicacoesMongoContext());
            var entity = new Conteudo
            {
                Id = Guid.NewGuid(),
                Titulo = "Conteudo teste",
                Corpo = "Corpo do conteudo teste",
                Status = ConteudoStatus.Active,
                IdAutor = new Guid("3038d24c-1bde-4f31-8777-bcbce4865af1")
            };

            rep.Create(entity);
        }
    }
}
