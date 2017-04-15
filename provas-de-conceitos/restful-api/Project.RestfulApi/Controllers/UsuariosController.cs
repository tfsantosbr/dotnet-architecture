using Project.RestfulApi.Entities;
using Project.RestfulApi.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.RestfulApi.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        #region Properties
        private readonly static List<Usuario> _usuariosList = new List<Usuario>();
        #endregion

        #region Main Methods

        [Route("")]
        public async Task<IHttpActionResult> Get([FromUri]UsuarioFilterModel model)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Get(Guid? id)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]UsuarioCreateModel model)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Put(Guid? id, [FromBody]UsuarioUpdateModel model)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(Guid? id)
        {
            await Task.Yield();
            throw new NotImplementedException();
        }

        // TODO: Patch

        #endregion
    }
}
