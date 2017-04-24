using Project.TestingProject.Base;
using Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests.UsuarioRepositorySeed;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;

namespace Project.TestingProject.RepositoriesTests.UsuarioRepositoryTests
{
    public abstract class UsuarioRepositoryTestsBase : BaseDatabaseTests
    {
        #region - PROPERTIES -

        protected IUsuarioRepository Repository;
        protected static GenericSeedData<Usuario> SeedData = new UsuarioSeedData();

        #endregion

        #region - CONSTRUCTOR -

        public UsuarioRepositoryTestsBase()
        {
            Repository = new UsuarioRepository();
            Repository.SetUnitOfWork(unitOfWorkContextAware);
        }

        #endregion
    }
}
