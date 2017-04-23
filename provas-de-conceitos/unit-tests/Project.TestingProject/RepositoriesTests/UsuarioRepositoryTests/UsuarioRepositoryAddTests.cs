using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.TestingProject.Base;
using Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests.UsuarioRepositorySeed;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests
{
    [TestClass]
    public class UsuarioRepositoryAddTests : BaseDatabaseTests, IDisposable
    {
        #region - PROPERTIES -
        public IUsuarioRepository repository;
        public static GenericSeedData<Usuario> seedData = new UsuarioSeedData();
        #endregion

        #region - CLASS INITIALIZE -
        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            seedData.SeedDatabase();
        }
        #endregion

        #region - CONSTRUCTOR -
        public UsuarioRepositoryAddTests()
        {
            repository = new UsuarioRepository();
            repository.SetUnitOfWork(unitOfWorkContextAware);
        }
        #endregion

        #region - TESTS -

        // Deve criar um novo usuário quando os dados necessários forem passados corretamente

        [TestMethod]
        public void ShouldCreateANewUserWhenNecessaryDataPassedCorrectly()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Tiago",
                Status = UsuarioStatus.Ativo
            };

            // Act
            repository.Add(usuario);
            var result = unitOfWorkContextAware.Commit();

            // Assert
            result.Should().BeGreaterThan(0);
        }

        // Deve criar um novo usuário quando todos os dados forem passados corretamente

        [TestMethod]
        public void ShouldCreateANewUserWhenAllDataPassedCorrectly()
        {
            // Arrange
            var usuario = new Usuario
            {
                Nome = "Tiago",
                Email = "tiago@email.com",
                Status = UsuarioStatus.Ativo,

                Enderecos = new List<Endereco>
                {
                    new Endereco
                    {
                        Logradouro = "Felício Antonio Pepe",
                        Bairro = "Vila Nova Savoia",
                        Numero = "123"
                    }
                }
            };

            // Act
            repository.Add(usuario);
            var result = unitOfWorkContextAware.Commit();

            // Assert
            result.Should().BeGreaterThan(0);
        }

        // Deve rejeitar um usuário com email já cadastrado

        [TestMethod]
        public void ShouldRejectAUserWithEmailAlreadyRegistered()
        {
            // Arrange
            var usuarioCadastrado = seedData.DataList.FirstOrDefault(x => x.Email != null);

            var usuario = new Usuario
            {
                Nome = "Tiago",
                Email = usuarioCadastrado.Email,
                Status = UsuarioStatus.Ativo
            };

            // Act & Assert

            try
            {
                repository.Add(usuario);
                unitOfWorkContextAware.Commit();
            }
            catch (DbUpdateException ex)
            {
                ex.InnerException.InnerException.Message.Should().Contain("duplicate key");
            }
        }

        // Deve rejeitar um usuário sem nome

        [TestMethod]
        public void ShouldRejectAUserWithoutName()
        {
            // Arrange

            var isRequiredNameErrorRaised = false;
            var usuario = new Usuario { };

            // Act

            try
            {
                repository.Add(usuario);
                unitOfWorkContextAware.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item in ex.EntityValidationErrors)
                {
                    isRequiredNameErrorRaised = item.ValidationErrors.Any(x =>
                        x.ErrorMessage.Contains("obrigatório") ||
                        x.PropertyName == "Nome"
                        );
                    if (isRequiredNameErrorRaised)
                        break;
                }
            }

            // Assert

            isRequiredNameErrorRaised.Should().BeTrue();
        }

        // Deve rejeitar um usuário sem status

        [TestMethod]
        public void ShouldRejectAUserWithoutStatus()
        {
            // Arrange

            var isRequiredStatusErrorRaised = false;
            var usuario = new Usuario { };

            // Act

            try
            {
                repository.Add(usuario);
                unitOfWorkContextAware.Commit();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item in ex.EntityValidationErrors)
                {
                    isRequiredStatusErrorRaised = item.ValidationErrors.Any(x =>
                        x.ErrorMessage.Contains("obrigatório") ||
                        x.PropertyName == "Status"
                        );
                    if (isRequiredStatusErrorRaised)
                        break;
                }
            }

            // Assert

            isRequiredStatusErrorRaised.Should().BeTrue();
        }

        #endregion

        #region - CLASS CLEANUP -
        [ClassCleanup()]
        public static void ClassCleanup()
        {
            seedData.EmptyDatabase();
        }
        #endregion
    }
}
