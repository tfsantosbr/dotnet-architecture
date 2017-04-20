using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Project.UnitOfWorkProjectTests
{
    [TestClass]
    public class UsuarioServiceTests
    {
        [TestMethod]
        public void UnitOfWorkMultipleRepositoriesTest()
        {
            //var unitOfWorkFactory = new UnitOfWorkFactory();

            //using (var unitOfWork = unitOfWorkFactory.Create())
            //{
            //    var paisRepository = new PaisRepository(unitOfWork);
            //    var usuarioRepository = new UsuarioRepository(unitOfWork);

            //    var pais = new Pais { Nome = "Nova Iorque 2" };
            //    paisRepository.Add(pais);

            //    var usuario = new Usuario { PaisId = pais.Id, Nome = "Arovaldo 2", Status = UsuarioStatus.Inativo };
            //    usuarioRepository.Add(usuario);

            //    var result = unitOfWork.Commit();
            //}
        }
    }
}
