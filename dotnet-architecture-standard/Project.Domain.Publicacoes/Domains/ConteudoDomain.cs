using Project.Domain.Core.Domains.Base;
using Project.Domain.Publicacoes.Interfaces;
using Project.Models.Publicacoes.Entities;
using Project.Persistence.Publicacoes.Interfaces;

namespace Project.Domain.Publicacoes.Domains
{
    public class ConteudoDomain : DomainBase<Conteudo, IConteudoRepository>, IConteudoDomain
    {
        #region - CONSTRUCTORS -

        public ConteudoDomain(IConteudoRepository repository)
            : base(repository)
        {
        }

        #endregion
    }
}