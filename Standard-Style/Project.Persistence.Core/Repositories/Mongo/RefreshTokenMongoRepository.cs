using Project.Models.Core.Entities;
using Project.Persistence.Core.Contexts.Base;
using Project.Persistence.Core.Interfaces;
using Project.Persistence.Core.Repositories.Base;

namespace Project.Persistence.Core.Repositories.Mongo
{
    public class RefreshTokenMongoRepository : RepositoryMongoBase<RefreshToken>, IRefreshTokenMongoRepository
    {
        public RefreshTokenMongoRepository(MongoContextBase context)
            : base(context)
        {
        }
    }
}