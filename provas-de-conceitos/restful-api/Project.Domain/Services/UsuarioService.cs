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

        public async Task<bool> Update(Usuario entity)
        {
            await Task.Yield();

            var index = _usuariosList.FindIndex(d => d.Id == entity.Id);
            if (index == -1)
                return false;

            _usuariosList[index] = entity;

            return true;
        }

        public async Task<List<Usuario>> Find()
        {
            await Task.Yield();

            var queriable = _usuariosList.AsQueryable();

            return queriable.ToList();
        }

        public async Task<bool> Delete(Guid id)
        {
            await Task.Yield();

            var index = _usuariosList.FindIndex(d => d.Id == id);
            if (index == -1)
                return false;

            _usuariosList.RemoveAt(index);

            return true;
        }

        #endregion
    }
}
