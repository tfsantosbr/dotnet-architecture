using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.TestingProject.Base;
using Project.UnitOfWorkProject.Contexts;
using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;
using System;

namespace Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests
{
    [TestClass]
    public class UsuarioRepositoryAddTests : BaseDatabaseTests
    {
        #region - PROPERTIES -
        public IUnitOfWorkContextAware unitOfWorkContextAware;
        public IUsuarioRepository repository;
        #endregion

        #region - CLASS INITIALIZE -
        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            Console.WriteLine("UsuarioRepositoryAddTests Initialize");
        }
        #endregion

        #region - CONSTRUCTOR -
        public UsuarioRepositoryAddTests()
        {
            unitOfWorkContextAware = new UnitOfWork(new UsuarioDbContext(), null);
            repository = new UsuarioRepository();
            repository.SetUnitOfWork(unitOfWorkContextAware);
        }
        #endregion

        #region - TESTS -

        // Deve criar um novo usuário quando os dados necessários forem passados corretamente

        [TestMethod]
        public void ShouldCreateANewUserWhenNecessaryDataPassedCorrectly()
        {
            Console.WriteLine("METHOD ShouldCreateANewUserWhenCorrectDataIsPassed");

            var entity = new Usuario
            {
                Nome = "Tiago",
                Email = "Santos",
                Status = UsuarioStatus.Ativo
            };

            // Arrange

            // Act

            // Assert
        }

        // Deve criar um novo usuário quando todos os dados forem passados corretamente

        [TestMethod]
        public void ShouldCreateANewUserWhenAllDataPassedCorrectly()
        {
            Console.WriteLine("METHOD ShouldCreateANewUserWhenAllDataPassedCorrectly");

            var entity = new Usuario
            {
                Nome = "Tiago",
                Email = "Santos",
                Status = UsuarioStatus.Ativo
            };

            // Arrange

            // Act

            // Assert
        }

        // Deve rejeitar um usuário com email já cadastrado

        [TestMethod]
        public void ShouldRejectAUserWithEmailAlreadyRegistered()
        {
            Console.WriteLine("METHOD ShouldRejectAUserWithEmailAlreadyRegistered");

            // Arrange

            // Act

            // Assert
        }

        // Deve rejeitar um usuário sem nome

        [TestMethod]
        public void ShouldRejectAUserWithoutName()
        {
            Console.WriteLine("METHOD ShouldRejectAUserWithoutName");

            // Arrange

            // Act

            // Assert
        }

        // Deve rejeitar um usuário sem status

        [TestMethod]
        public void ShouldRejectAUserWithoutStatus()
        {
            Console.WriteLine("METHOD ShouldRejectAUserWithoutStatus");

            // Arrange

            // Act

            // Assert
        }

        #endregion

        #region - CLASS CLEANUP -
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            Console.WriteLine("UsuarioRepositoryAddTests Cleanup");
        }
        #endregion
    }

}
