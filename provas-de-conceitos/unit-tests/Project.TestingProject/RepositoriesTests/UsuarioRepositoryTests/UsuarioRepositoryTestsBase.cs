using Project.TestingProject.Base;
using Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests.UsuarioRepositorySeed;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;

namespace Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests
{
    public abstract class UsuarioRepositoryTestsBase : BaseDatabaseTests
    {
        #region - PROPERTIES -

        public IUsuarioRepository _repository;
        public static GenericSeedData<Usuario> _seedData = new UsuarioSeedData();

        #endregion

        #region - CONSTRUCTOR -

        public UsuarioRepositoryTestsBase()
        {
            _repository = new UsuarioRepository();
            _repository.SetUnitOfWork(unitOfWorkContextAware);
        }

        #endregion
    }
}
