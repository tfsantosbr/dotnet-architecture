using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Services;
using System;
using System.Threading.Tasks;

namespace Project.TestingProject.RepositoriesTests.UsuarioServiceTests
{
    [TestClass]
    public class AddAsyncShould : UsuarioServiceTestsBase
    {
        #region - TESTS -

        // Deve retornar o Id do usuário quando criado corretamente no banco de dados

        [TestMethod, TestProperty("Usuário", "Service")]
        public async Task ReturnIdWhenUserCreatedCorrectlyOnDatabase()
        {
            // Arrange & Act

            UnitOfWorkContextAware.CommitAsync().Returns(1);

            var result = await AddAsync(new Usuario());

            // Assert

            result.Should().NotBeNull();
        }

        // Deve retornar um erro quando um valor nulo for passado

        [TestMethod, TestProperty("Usuário", "Service")]
        public void ReturnErrorWhenNullDataHasPassed()
        {
            // Arrange & Act
            Func<Task> act = async () => await AddAsync(null);

            act.ShouldThrow<ArgumentNullException>();
        }

        // Deve retornar um erro quando o banco de dados retorna um erro ao criar um usuário

        [TestMethod, TestProperty("Usuário", "Service")]
        public async Task ReturnErrorWhenDatabaseReturnErrorOnCreateAUser()
        {
            // Arrange & Act

            UnitOfWorkContextAware.When(x => x.CommitAsync()).Throw<Exception>();

            try
            {
                await AddAsync(Arg.Any<Usuario>());
            }
            catch (Exception ex)
            {
                // Assert
                ex.Message.Should().NotBeNullOrWhiteSpace();
            }
        }

        #endregion

        #region - SECONDARY METHODS -

        private async Task<int?> AddAsync(Usuario usuario)
        {
            var service = new UsuarioService(UnitOfWorkContextAwareFactory);
            return await service.AddAsync(usuario);
        }

        #endregion
    }
}
