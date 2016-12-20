using System.Data.Entity;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories.Base;

namespace Project.Persistence.Core.Repositories
{
    public class RefreshTokenRepository : RelationalRepositoryBase<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(DbContext context)
            : base(context)
        {
        }
    }
}