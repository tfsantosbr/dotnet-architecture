using Project.Domain.Core.Interfaces.Base;
using Project.Models.Publicacoes.Entities;

namespace Project.Domain.Publicacoes.Interfaces
{
    /// <summary>
    ///     CONTEUDO DOMAIN INTERFACE
    /// </summary>

    public interface IConteudoDomain : IDomainBase<Conteudo>, IDomainBaseAsync<Conteudo>
    {
    }
}