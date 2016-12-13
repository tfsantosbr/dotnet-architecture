using Project.Domain.Core.Domains.Base;
using Project.Domain.Core.Interfaces;
using Project.Models.Core.Entities;
using Project.Persistence.Core.Interfaces;

namespace Project.Domain.Core.Domains
{
    public class ClientDomain : DomainBase<Client, IClientRepository>, IClientDomain
    {
        #region - CONSTRUCTORS -

        public ClientDomain(IClientRepository repository)
            : base(repository)
        {
        }

        #endregion
    }
}