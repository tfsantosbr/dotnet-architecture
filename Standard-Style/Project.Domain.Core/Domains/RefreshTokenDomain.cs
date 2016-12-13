using Project.Domain.Core.Domains.Base;
using Project.Domain.Core.Interfaces;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Domain.Core.Domains
{
    public class RefreshTokenDomain : DomainBase<RefreshToken, IRefreshTokenRepository>, IRefreshTokenDomain
    {
        #region - CONSTRUCTORS -

        public RefreshTokenDomain(IRefreshTokenRepository repository)
            : base(repository)
        {
        }

        #endregion

        #region - MAIN METHODS -

        public override async Task<bool> CreateAsync(RefreshToken token)
        {
            var existingToken = Repository.Query(
                r => r.Subject == token.Subject && r.ClientId == token.ClientId && r.Browser == token.Browser)
                .SingleOrDefault();

            if (existingToken != null)
            {
                Repository.Delete(existingToken);
                await Repository.SaveAsync();
            }

            Repository.Create(token);
            return await Repository.SaveAsync() > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await DeleteAsync(id, null);
        }

        public async Task<bool> DeleteAsync(string id, string browser)
        {
            var refreshToken = await ReadAsync(id, browser);

            if (refreshToken == null)
                return false;

            Repository.Delete(refreshToken);
            return await Repository.SaveAsync() > 0;
        }

        #endregion
    }
}