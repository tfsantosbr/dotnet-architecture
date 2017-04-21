using Project.UnitOfWorkProject.Entities;
using System.Threading.Tasks;

namespace Project.UnitOfWorkProject.Services
{
    public interface IUsuarioService
    {
        Task<bool> AddAsync(Usuario entity);
    }
}