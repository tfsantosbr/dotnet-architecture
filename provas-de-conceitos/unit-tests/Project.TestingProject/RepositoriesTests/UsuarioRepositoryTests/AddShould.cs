using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.UnitOfWorkProject.Entities;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests
{
    [TestClass]
    public class AddShould : UsuarioRepositoryTestsBase
    {
        // Deve criar um novo usuário quando os dados necessários forem passados corretamente

        [TestMethod, TestProperty("Usuário", "Repository")]
        public void CreateUserWhenNecessaryDataPassedCorrectly()
        {
            // Arrange & Act

            var usuario = new Usuario { Nome = "Tiago", Status = UsuarioStatus.Ativo };
            var result = Add(usuario);

            // Assert

            result.Should().BeGreaterThan(0);
        }

        // Deve criar um novo usuário quando todos os dados forem passados corretamente

        [TestMethod, TestProperty("Usuário", "Repository")]
        public void CreateUserWhenAllDataPassedCorrectly()
        {
            // Arrange & Act

            var usuario = new Usuario
            {
                Nome = "Tiago",
                Email = "tiago@email.com",
                Status = UsuarioStatus.Ativo,
                Enderecos = new List<Endereco>
                {
                    new Endereco {
                        Logradouro = "Felício Antonio Pepe",
                        Bairro = "Vila Nova Savoia",
                        Numero = "123"
                    }
                }
            };

            var result = Add(usuario);

            // Assert

            result.Should().BeGreaterThan(0);
        }

        // Deve retornar um erro quando o email já estiver cadastrado

        [TestMethod, TestProperty("Usuário", "Repository")]
        public void ReturnErrorWhenEmailAlreadyRegistered()
        {
            // Arrange & Act

            var usuarioCadastrado = _seedData.DataList.FirstOrDefault(x => x.Email != null);
            var usuario = new Usuario { Nome = "Tiago", Email = usuarioCadastrado.Email, Status = UsuarioStatus.Ativo };

            try
            {
                Add(usuario);
            }
            catch (DbUpdateException ex)
            {
                // Assert

                ex.InnerException.InnerException.Message.Should().Contain("duplicate key");
            }
        }

        // Deve retornar um erro quando não for passado a propriedade Nome

        [TestMethod, TestProperty("Usuário", "Repository")]
        public void ReturnErrorWhenNotPassedPropertyNome()
        {
            // Arrange & Act

            var hasRequiredNameError = false;
            var usuario = new Usuario { };

            try
            {
                Add(usuario);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item in ex.EntityValidationErrors)
                {
                    hasRequiredNameError = item.ValidationErrors.Any(x =>
                        x.ErrorMessage.Contains("obrigatório") ||
                        x.PropertyName == "Nome"
                        );
                    if (hasRequiredNameError)
                        break;
                }
            }

            // Assert

            hasRequiredNameError.Should().BeTrue();
        }

        // Deve retornar um erro quando não for passado a propriedade Status

        [TestMethod, TestProperty("Usuário", "Repository")]
        public void ReturnErrorWhenNotPassedPropertyStatus()
        {
            // Arrange & Act

            var hasRequiredStatusError = false;
            var usuario = new Usuario { };

            try
            {
                Add(usuario);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var item in ex.EntityValidationErrors)
                {
                    hasRequiredStatusError = item.ValidationErrors.Any(x =>
                        x.ErrorMessage.Contains("obrigatório") ||
                        x.PropertyName == "Status"
                        );
                    if (hasRequiredStatusError)
                        break;
                }
            }

            // Assert

            hasRequiredStatusError.Should().BeTrue();
        }

        #region - SECONDARY METHODS -

        private int Add(Usuario usuario)
        {
            _repository.Add(usuario);
            return unitOfWorkContextAware.Commit();
        }

        #endregion

        #region - INITIALIZE and CLEANUP -

        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            _seedData.SeedDatabase();
        }

        [ClassCleanup()]
        public static void ClassCleanup()
        {
            _seedData.EmptyDatabase();
        }

        #endregion
    }
}
