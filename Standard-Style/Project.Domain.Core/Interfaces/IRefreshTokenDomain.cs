using System;
using System.Threading.Tasks;
using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities;

namespace Project.Domain.Core.Interfaces
{
    public interface IRefreshTokenDomain : IDomainBase<RefreshToken>, IDomainBaseAsync<RefreshToken>
    {
        Task<bool> DeleteAsync(Guid id, string browser);
    }
}