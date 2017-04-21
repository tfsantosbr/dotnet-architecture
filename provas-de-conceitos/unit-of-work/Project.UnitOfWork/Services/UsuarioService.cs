using Project.UnitOfWorkProject.Core;
using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Repositories;
using System;
using System.Threading.Tasks;

namespace Project.UnitOfWorkProject.Services
{
    public class UsuarioService : IUsuarioService
    {
        // Properties

        private readonly Func<IUnitOfWorkContextAware> unitOfWorkFactory;

        // Constructos

        public UsuarioService(Func<IUnitOfWorkContextAware> unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        // Main Methods

        public async Task<bool> AddAsync(Usuario entity)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Invoke())
                {
                    var usuarioRepository = unitOfWork.GetRepository<IUsuarioRepository>();

                    usuarioRepository.Add(entity);

                    var result = await unitOfWork.CommitAsync();

                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task<bool> ChangeStatus(int id, UsuarioStatus status)
        //{
        //    try
        //    {
        //        using (var unitOfWork = _unitOfWorkFactory.Create())
        //        {
        //            var usuarioRepository = unitOfWork.GetRepository<IUsuarioRepository>();

        //            var usuario = usuarioRepository.Get(id);
        //            usuario.Status = status;

        //            var result = unitOfWork.Commit();

        //            return result > 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
