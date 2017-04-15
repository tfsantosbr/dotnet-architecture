using Project.Domain.Entities;
using Project.Domain.Services;
using Project.RestfulApi.Models.Usuarios;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.RestfulApi.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuariosController : ApiController
    {
        #region Properties
        private readonly UsuarioService _service;
        #endregion

        #region Constructors
        public UsuariosController()
        {
            _service = new UsuarioService();
        }
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
            // valida id
            if (!id.HasValue)
                return BadRequest("Id inválido ou não informado");

            // procura entidade pelo id
            var entity = await _service.GetById(id.Value);

            // valida a entidade
            if (entity == null)
                return NotFound();

            // converte para a model
            var model = new UsuarioGetModel
            {
                Nome = entity.Nome,
                Sobrenome = entity.Sobrenome,
                Email = entity.Email,
                Status = entity.Status
            };

            // retorna a model
            return Ok(model);
        }

        [Route("")]
        public async Task<IHttpActionResult> Post([FromBody]UsuarioCreateModel model)
        {
            // valida model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // converte pra entidade
            var entity = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                Sobrenome = model.Sobrenome,
                Status = UsuarioStatus.Ativo
            };

            // cria entidade
            await _service.Create(entity);

            // retorna resultado
            return Created($"{Request.RequestUri.AbsoluteUri}/{entity.Id}", model);
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

        // TODO: API Patch Method

        #endregion
    }
}
