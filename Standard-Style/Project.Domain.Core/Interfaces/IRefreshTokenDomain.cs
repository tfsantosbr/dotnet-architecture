using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities;
using System.Threading.Tasks;

namespace Project.Domain.Core.Interfaces
{
    public interface IRefreshTokenDomain : IDomainBase<RefreshToken>, IDomainBaseAsync<RefreshToken>
    {
        Task<bool> DeleteAsync(string id, string browser);
    }
}