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
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(Lifestyle.Transient);
            container.Register<IUnitOfWork, Project.UnitOfWork.Core.UnitOfWork>(Lifestyle.Transient);

            container.Register(typeof(IRepository<,>), new[] { typeof(GenericRepository<,>).Assembly });

            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Transient);
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Transient);

            //container.Verify();

            _service = container.GetInstance<IUsuarioService>();
        }

        [TestMethod]
        public void UsuarioServiceTests_AdicionarUsuario_AdicionarComSucesso()
        {
            _service.Add(new Usuario { Nome = "teste", Status = UsuarioStatus.Ativo });
        }

        [TestMethod]
        public void UnitOfWorkMultipleRepositoriesTest()
        {
            var unitOfWorkFactory = new UnitOfWorkFactory();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                var paisRepository = new PaisRepository(unitOfWork);
                var usuarioRepository = new UsuarioRepository(unitOfWork);

                var pais = new Pais { Nome = "Nova Iorque" };
                paisRepository.Add(pais);

                var usuario = new Usuario { PaisId = pais.Id, Nome = "Arovaldo", Status = UsuarioStatus.Inativo };
                usuarioRepository.Add(usuario);

                var result = unitOfWork.Commit();
            }
        }
    }
}
