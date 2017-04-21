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

        public async Task<bool> AddAsync(Usuario usuario)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Invoke())
                {
                    var paisRepository = unitOfWork.GetRepository<IPaisRepository>();
                    var usuarioRepository = unitOfWork.GetRepository<IUsuarioRepository>();

                    // para teste do unit of work utilizando 2 repositórios no mesmo contexto

                    // adiciona um pais para cada usuário cadastrado
                    var pais = new Pais { Nome = "PaisTeste" + DateTime.Now.ToShortDateString() };
                    paisRepository.Add(pais);

                    // associa o pais cadatsrado ao usuario que será cadastrado
                    usuario.PaisId = pais.Id;

                    // adiciona o usuario com o pais
                    usuarioRepository.Add(usuario);

                    var result = await unitOfWork.CommitAsync();

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
