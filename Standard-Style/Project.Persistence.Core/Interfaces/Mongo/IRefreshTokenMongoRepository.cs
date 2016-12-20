using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Interfaces
{
    public interface IRefreshTokenMongoRepository : IRepositoryMongoBase<RefreshToken>, IRepositoryMongoBaseAsync<RefreshToken>
    {
    }
}