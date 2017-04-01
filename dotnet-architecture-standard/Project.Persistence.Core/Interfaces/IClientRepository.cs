using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Interfaces
{
    public interface IClientRepository : IRepositoryBase<Client>, IRepositoryBaseAsync<Client>
    {
    }
}