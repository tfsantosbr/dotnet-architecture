using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.TestingProject.Base;
using Project.UnitOfWorkProject.Contexts;
using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Repositories;
using System;

namespace Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests
{
    [TestClass]
    public class EnderecoRepositoryAddTests : BaseDatabaseTests
    {
        #region - PROPERTIES -
        public IUnitOfWorkContextAware unitOfWorkContextAware;
        public IEnderecoRepository repository;
        #endregion

        #region - CLASS INITIALIZE -
        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            Console.WriteLine("EnderecoRepositoryAddTests Initialize");
        }
        #endregion

        #region - CONSTRUCTOR -
        public EnderecoRepositoryAddTests()
        {
            unitOfWorkContextAware = new UnitOfWork(new UsuarioDbContext(), null);
            repository = new EnderecoRepository();
            repository.SetUnitOfWork(unitOfWorkContextAware);
        }
        #endregion

        #region - TESTS -

        // Deve criar um novo endereço quando for passado dados corretos

        [TestMethod]
        public void ShouldCreateANewAdressWhenCorrectDataIsPassed()
        {
            Console.WriteLine("METHOD ShouldCreateANewUserWhenCorrectDataIsPassed");

            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        // Deve rejeitar um endereço sem logradouro

        [TestMethod]
        public void ShouldRejectAAdressWithoutLogradouro()
        {
            Console.WriteLine("METHOD ShouldRejectAAdressWithoutLogradouro");

            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        // Deve rejeitar um endereço sem número

        [TestMethod]
        public void ShouldRejectAAdressWithoutNumber()
        {
            Console.WriteLine("METHOD ShouldRejectAAdressWithoutNumber");

            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        // Deve rejeitar um endereço sem bairro

        [TestMethod]
        public void ShouldRejectAAdressWithoutBairro()
        {
            Console.WriteLine("METHOD ShouldRejectAAdressWithoutBairro");

            // Arrange

            // Act

            // Assert
            Assert.Fail();
        }

        #endregion

        #region - DISPOSE -
        public void Dispose()
        {
            repository = null;
            unitOfWorkContextAware.Dispose();
        }
        #endregion

        #region - CLASS CLEANUP -
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            Console.WriteLine("EnderecoRepositoryAddTests Cleanup");
        }
        #endregion
    }
}
