using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories.Base;
using System.Data.Entity;

namespace Project.Persistence.Core.Repositories
{
    public class RefreshTokenRepository : RepositoryBase<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(DbContext context)
            : base(context)
        {
        }
    }
}