using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.UnitOfWorkProject.Contexts;
using Project.UnitOfWorkProject.Core;
using System;
using System.Transactions;

namespace Project.TestingProject.Base
{
    [TestClass]
    public class BaseDatabaseTests : IDisposable
    {
        public readonly IUnitOfWorkContextAware unitOfWorkContextAware;
        public readonly UsuarioDbContext context;
        private TransactionScope transaction;

        public BaseDatabaseTests()
        {
            context = new UsuarioDbContext();
            unitOfWorkContextAware = new UnitOfWork(context, null);
        }

        [TestInitialize()]
        public void Initialize()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup()]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        public void Dispose()
        {
            unitOfWorkContextAware.Dispose();
        }
    }
}
