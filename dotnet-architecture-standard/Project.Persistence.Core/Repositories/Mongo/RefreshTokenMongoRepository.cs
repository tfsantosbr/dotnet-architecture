using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts.Base;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories.Base;

namespace Project.Persistence.Core.Repositories
{
    public class RefreshTokenMongoRepository : MongoRepositoryBase<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenMongoRepository(MongoContextBase context)
            : base(context)
        {
        }
    }
}