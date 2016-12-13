using Project.Models.Publicacoes.Entities;
using Project.Persistence.Core.Interfaces.Base;

namespace Project.Persistence.Publicacoes.Interfaces
{
    /// <summary>
    ///     CONTEUDO REPOSITORY INTERFACE
    /// </summary>

    public interface IConteudoRepository : IRepositoryBase<Conteudo>, IRepositoryBaseAsync<Conteudo>
    {
    }
}