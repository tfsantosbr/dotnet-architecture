using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories.Base;
using System.Data.Entity;

namespace Project.Persistence.Core.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(DbContext context)
            : base(context)
        {
        }
    }
}