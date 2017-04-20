using Project.UnitOfWorkProject.Entities;

namespace Project.UnitOfWorkProject.Services
{
    public interface IUsuarioService
    {
        bool Add(Usuario entity); // TODO: Mover para IService
        bool ChangeStatus(int id, UsuarioStatus status);
    }
}