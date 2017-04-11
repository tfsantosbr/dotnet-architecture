using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.UnitOfWork.Core;
using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Services;

namespace Project.UnitOfWork.Tests
{
    [TestClass]
    public class UsuarioServiceTests
    {
        public readonly IUsuarioService _service;

        public UsuarioServiceTests()
        {
            var unitOfWorkFactory = new UnitOfWorkFactory();
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
