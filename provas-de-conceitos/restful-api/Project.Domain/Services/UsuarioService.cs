using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Domain.Services
{
    public class UsuarioService
    {
        #region Properties
        private readonly static List<Usuario> _usuariosList = new List<Usuario>();
        #endregion

        #region Main Methods

        public async Task Create(Usuario entity)
        {
            await Task.Yield();

            _usuariosList.Add(entity);
        }

        public async Task<Usuario> GetById(Guid id)
        {
            await Task.Yield();

            return _usuariosList.FirstOrDefault(x => x.Id == id);
        }

        #endregion
    }
}
