using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Helpers.Security;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories;

namespace Project.Persistence.Publicacoes.Tests.RepositoriesTests
{
    [TestClass]
    public class ClientMongoRepositoryTests
    {
        [TestMethod]
        public void ClientMongoRepositoryTests_Insert()
        {
            IClientRepository rep = new ClientMongoRepository(new CoreMongoContext());

            rep.Create(new Client
            {
                Id = "webApp",
                Secret = HashHelper.GetHash("abc@123"),
                Name = "AngularJS front-end Application",
                ApplicationType = ApplicationTypes.JavaScript,
                Active = true,
                RefreshTokenLifeTime = 12,
                AllowedOrigin = "http://localhost:2001"
            });

            rep.Create(new Client
            {
                Id = "consoleApp",
                Secret = HashHelper.GetHash("123@abc"),
                Name = "Console Application",
                ApplicationType = ApplicationTypes.NativeConfidential,
                Active = true,
                RefreshTokenLifeTime = 12,
                AllowedOrigin = "*"
            });
        }
    }
}
