using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Models.Publicacoes.Entities;
using Project.Persistence.Publicacoes.Contexts;

namespace Project.Persistence.Publicacoes.Tests.ContextsTests
{
    [TestClass]
    public class PublicacoesMongoContextTests
    {
        [TestMethod]
        public void PublicacoesMongoContextTests_CreateConteudo()
        {
            var ctx = new PublicacoesMongoContext();
            var entity = new Conteudo
            {
                Titulo = "Conteudo Teste",
                Corpo = "Corpo Teste"
            };

            ctx.Conteudos.InsertOne(entity);
        }
    }
}
