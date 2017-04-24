using NSubstitute;
using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Repositories;
using System;

namespace Project.TestingProject.RepositoriesTests.UsuarioServiceTests
{
    public abstract class UsuarioServiceTestsBase
    {
        #region - PROPERTIES -

        protected readonly Func<IUnitOfWorkContextAware> UnitOfWorkContextAwareFactory;
        protected readonly IUnitOfWorkContextAware UnitOfWorkContextAware;
        protected readonly IUsuarioRepository Repository;

        #endregion

        #region - CONSTRUCTOR -

        protected UsuarioServiceTestsBase()
        {
            UnitOfWorkContextAware = Substitute.For<IUnitOfWorkContextAware>();

            UnitOfWorkContextAwareFactory = Substitute.For<Func<IUnitOfWorkContextAware>>();
            UnitOfWorkContextAwareFactory.Invoke().Returns(UnitOfWorkContextAware);

            Repository = Substitute.For<IUsuarioRepository>();

            UnitOfWorkContextAware.GetRepository<IUsuarioRepository>().Returns(Repository);
        }

        #endregion
    }
}
