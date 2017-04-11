using Project.UnitOfWork.Entities;

namespace Project.UnitOfWork.Services
{
    internal interface IUsuarioRepository
    {
        void Add(Usuario entity); // TODO: Mover para o GenericRepository
    }
}