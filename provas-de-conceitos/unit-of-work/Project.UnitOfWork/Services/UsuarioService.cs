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

        // Constructors

        public UsuarioService(Func<IUnitOfWorkContextAware> unitOfWorkFactory)
        {
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        // Main Methods

        public async Task<int?> AddAsync(Usuario usuario)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Invoke())
                {
                    var usuarioRepository = unitOfWork.GetRepository<IUsuarioRepository>();
                    usuarioRepository.Add(usuario);

                    var result = await unitOfWork.CommitAsync();

                    if (result == 0)
                        return null;

                    return usuario.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
