using Project.Domain.Core.Interfaces.Base;
using Project.Models.Core.Entities;

namespace Project.Domain.Core.Interfaces
{
    public interface IUsuarioDomain : IDomainBase<Usuario>, IDomainBaseAsync<Usuario>
    {
    }
}