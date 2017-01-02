using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models.Publicacoes.Entities;
using Project.Persistence.Publicacoes.Contexts;
using Project.Persistence.Publicacoes.Interfaces;
using Project.Persistence.Publicacoes.Repositories;

namespace Project.Persistence.Publicacoes.Tests.RepositoriesTests
{
    [TestClass]
    public class ConteudoRepositoryTests
    {
        private IConteudoRepository repository = null;

        public ConteudoRepositoryTests()
        {
            repository = new ConteudoRepository(new PublicacoesContext());
        }

        [TestMethod]
        public void ConteudoRepositoryTests_Insert_One()
        {
            InsertNewEntity(Guid.NewGuid());
        }

        [TestMethod]
        public void ConteudoRepositoryTests_Select_One()
        {
            var id = Guid.NewGuid();
            InsertNewEntity(id);

            var entity = repository.SingleOrDefault(x => x.Id == id);

            Assert.IsNotNull(entity);
        }

        [TestMethod]
        public void ConteudoRepositoryTests_Update_One()
        {
            var id = Guid.NewGuid();
            InsertNewEntity(id);

            var entity = repository.SingleOrDefault(x => x.Id == id);
            entity.Titulo = "Titulo teste UPDATED";
            entity.Corpo = "Corpo teste UPDATED";
            entity.Status = ConteudoStatus.Approved;

            repository.Update(null, entity);
        }

        [TestMethod]
        public void ConteudoRepositoryTests_Delete_One()
        {
            repository.Delete(x => x.Id == new Guid("F02C7BDC-A134-473D-9377-98F3EFC21D5E"));
        }

        [TestMethod]
        public void ConteudoRepositoryTests_List_All()
        {
            var list = repository.Query().ToList();

            Assert.IsNotNull(list);
        }

        private void InsertNewEntity(Guid id)
        {
            var entity = new Conteudo
            {
                Id = id,
                Titulo = "Titulo teste",
                Corpo = "Corpo teste",
                Status = ConteudoStatus.Active,
                IdAutor = new Guid("3038d24c-1bde-4f31-8777-bcbce4865af1")
            };

            repository.Create(entity);
        }
    }
}
