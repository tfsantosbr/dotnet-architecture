using Project.UnitOfWork.Contexts;
using Project.UnitOfWork.Entities;
using System;

namespace Project.UnitOfWork.Services
{
    public class UsuarioService : IUsuarioService
    {
        // Properties

        public readonly IUnitOfWorkFactory _unitOfWorkFactory;

        // Constructos

        public UsuarioService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        // Main Methods

        public bool Add(Usuario entity)
        {
            try
            {
                using (var unitOfWork = _unitOfWorkFactory.Create())
                {
                    var usuarioRepository = unitOfWork.GetRepository<IUsuarioRepository>();

                    usuarioRepository.Add(entity);

                    var result = unitOfWork.Commit();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ChangeStatus(int id, UsuarioStatus status)
        {
            try
            {
                using (var unitOfWork = _unitOfWorkFactory.Create())
                {
                    var usuarioRepository = unitOfWork.GetRepository<IUsuarioRepository>();

                    var usuario = usuarioRepository.Get(id);
                    usuario.Status = status;

                    var result = unitOfWork.Commit();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
