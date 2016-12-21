using System;
using System.Linq;
using System.Threading.Tasks;
using Project.Domain.Core.Domains.Base;
using Project.Domain.Core.Interfaces;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces;

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

        public override async Task CreateAsync(RefreshToken token)
        {
            var existingToken = Repository.Query(
                r => r.Subject == token.Subject && r.ClientId == token.ClientId && r.Browser == token.Browser)
                .SingleOrDefault();

            if (existingToken != null)
            {
                await Repository.DeleteAsync(existingToken);
            }

            await Repository.CreateAsync(token);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await DeleteAsync(id, null);
        }

        public async Task<bool> DeleteAsync(Guid id, string browser)
        {
            var refreshToken = await ReadAsync(r => r.Id == id && r.Browser == browser);

            if (refreshToken == null)
                return false;

            await Repository.DeleteAsync(refreshToken);

            return true;
        }

        #endregion
    }
}