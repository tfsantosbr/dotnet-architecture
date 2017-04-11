using Project.UnitOfWork.Core;
using Project.UnitOfWork.Entities;
using System;

namespace Project.UnitOfWork.Services
{
    public class UsuarioService : IUsuarioService
    {
        public readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UsuarioService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

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
    }
}
