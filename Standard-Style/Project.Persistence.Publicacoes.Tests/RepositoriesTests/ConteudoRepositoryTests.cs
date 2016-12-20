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
        [TestMethod]
        public void ConteudoRepositoryTests_Insert()
        {
            IConteudoRepository rep = new ConteudoRepository(new PublicacoesContext());
            var entity = new Conteudo
            {
                Titulo = "Conteudo teste",
                Corpo = "Corpo do conteudo teste",
                Status = ConteudoStatus.Active,
                IdAutor = 1
            };

            rep.Create(entity);
        }
    }
}
