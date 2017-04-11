using Project.UnitOfWork.Entities;

namespace Project.UnitOfWork.Services
{
    public interface IUsuarioService
    {
        bool Add(Usuario entity);
    }
}