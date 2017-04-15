using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.UnitOfWork.Core;
using Project.UnitOfWork.Entities;
using Project.UnitOfWork.Repositories;
using Project.UnitOfWork.Services;
using SimpleInjector;

namespace Project.UnitOfWorkTests
{
    [TestClass]
    public class UsuarioServiceTests
    {
        public readonly IUsuarioService _service;
        public readonly Container container = new Container();

        public UsuarioServiceTests()
        {
            container.Register<IResolver, Resolver>(Lifestyle.Transient);

            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(Lifestyle.Transient);
            //container.Register<IUnitOfWorkContextAware, Project.UnitOfWork.Core.UnitOfWork>(Lifestyle.Transient);

            container.Register(typeof(IRepository<,>), new[] { typeof(IRepository<,>).Assembly });

            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Transient);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Transient);

            //container.Verify();

            _service = container.GetInstance<IUsuarioService>();
        }

        [TestMethod]
        public void UsuarioServiceTests_AdicionarUsuario_AdicionarComSucesso()
        {
            var unitOfWorkFactory = new UnitOfWorkFactory(new Resolver(container));

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                var usuarioRepository = new UsuarioRepository(unitOfWork);
                usuarioRepository.Add(new Usuario { Nome = "Roberto", Status = UsuarioStatus.Ativo });

                var result = unitOfWork.Commit();
            }
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
