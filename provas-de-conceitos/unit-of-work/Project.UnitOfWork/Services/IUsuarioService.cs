using Project.UnitOfWorkProjectProject.Entities;
using System.Threading.Tasks;

namespace Project.UnitOfWorkProjectProject.Services
{
    public interface IUsuarioService
    {
        Task<bool> AddAsync(Usuario entity);
    }
}