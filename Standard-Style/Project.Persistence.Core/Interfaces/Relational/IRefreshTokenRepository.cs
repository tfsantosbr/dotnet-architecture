using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Core.Interfaces
{
    public interface IRefreshTokenRepository : IRepositoryRelationalBase<RefreshToken>, IRepositoryRelationalBaseAsync<RefreshToken>
    {
    }
}