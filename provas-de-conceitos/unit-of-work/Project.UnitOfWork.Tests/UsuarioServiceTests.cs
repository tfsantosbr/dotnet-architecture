using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.UnitOfWork.Core;
using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Repositories;
using Project.UnitOfWork.Services;
using SimpleInjector;
using System;

namespace Project.UnitOfWorkTests
{
    [TestClass]
    public class UsuarioServiceTests
    {
        public readonly IUsuarioService _service;

        public UsuarioServiceTests()
        {
            var container = new Container();

            container.Register<IServiceProvider, Container>(Lifestyle.Transient);
            container.Register<IUnitOfWork, Project.UnitOfWork.Core.UnitOfWork>(Lifestyle.Transient);
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(Lifestyle.Transient);
            container.Register(typeof(IRepository), typeof(IRepository), Lifestyle.Transient);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Transient);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Transient);

            //container.Verify();

            _service = container.GetInstance<IUsuarioService>();
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
