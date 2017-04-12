using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.UnitOfWork.Contexts;
using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Services;
using SimpleInjector;

namespace Project.UnitOfWork.Tests
{
    [TestClass]
    public class UsuarioServiceTests
    {
        public readonly IUsuarioService _service;

        public UsuarioServiceTests()
        {
            var provider = new Container();
            var unitOfWorkFactory = new UnitOfWorkFactory(provider);
            _service = new UsuarioService(unitOfWorkFactory);
        }

        [TestMethod]
        public void UsuarioServiceTests_AdicionarUsuario_AdicionarComSucesso()
        {
            // Arrange
            var usuario = new Usuario { Id = 1, Nome = "Tiago", Status = UsuarioStatus.Ativo };

            // Act
            var result = _service.Add(usuario);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UsuarioServiceTests_ChangeStatus_ComSucesso()
        {
            // Arrange & Act
            var result = _service.ChangeStatus(1, UsuarioStatus.Inativo);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
