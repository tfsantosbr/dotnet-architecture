using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Services;
using System;

namespace Project.TestingProject.ServicesTests.UsuarioServiceTests
{
    [TestClass]
    public class UsuarioServiceAddAsyncTests
    {
        #region - PROPERTIES -
        #endregion

        #region - CLASS INITIALIZE -
        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
        }
        #endregion

        #region - CONSTRUCTOR -
        public UsuarioServiceAddAsyncTests()
        {
        }
        #endregion

        #region - TESTS -

        // Deve criar um novo usuário quando os dados necessários forem passados corretamente

        [TestMethod, TestProperty("Usuário", "Service")]
        public void ShouldCreateANewUserWhenNecessaryDataPassedCorrectly()
        {
            // Arrange
            var unitOfWork = Substitute.For<IUnitOfWork>();
            unitOfWork.Commit().Returns(1);

            var unitOfWorkContextAwareFactory = Substitute.For<Func<IUnitOfWorkContextAware>>();
            unitOfWorkContextAwareFactory.Invoke().Returns(unitOfWork);

            var service = new UsuarioService(unitOfWorkContextAwareFactory);
            var usuario = new Usuario { Nome = "Tiago", Status = UsuarioStatus.Ativo };

            // Act

            var result = service.Add(usuario);

            // Assert

            result.Should().NotBeNull();
        }

        // Deve criar um novo usuário quando todos os dados forem passados corretamente

        [TestMethod, TestProperty("Usuário", "Service")]
        public void ShouldCreateANewUserWhenAllDataPassedCorrectly()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        // Deve rejeitar um usuário com email já cadastrado

        [TestMethod, TestProperty("Usuário", "Service")]
        public void ShouldRejectAUserWithEmailAlreadyRegistered()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        // Deve rejeitar um usuário sem nome

        [TestMethod, TestProperty("Usuário", "Service")]
        public void ShouldRejectAUserWithoutName()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        // Deve rejeitar um usuário sem status

        [TestMethod, TestProperty("Usuário", "Service")]
        public void ShouldRejectAUserWithoutStatus()
        {
            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        #endregion

        #region - CLASS CLEANUP -
        [ClassCleanup()]
        public static void ClassCleanup()
        {
        }
        #endregion
    }
}
