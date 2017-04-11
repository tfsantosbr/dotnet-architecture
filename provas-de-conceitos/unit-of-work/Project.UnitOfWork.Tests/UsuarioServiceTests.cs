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
        public void TestMethod1()
        {
            // Arrange
            var usuario = new Usuario { Id = 1, Nome = "Tiago" };

            // Act
            var result = _service.Add(usuario);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
