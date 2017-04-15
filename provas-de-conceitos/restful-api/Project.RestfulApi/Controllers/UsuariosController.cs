using Project.Domain.Entities;
using Project.Domain.Services;
using Project.RestfulApi.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
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
            // valida a model

            // retorna as entidades
            var entityList = await _service.Find();

            // verifica se retornou alguma entidade
            if (entityList == null || entityList.Count == 0)
                return NotFound();


            var modelList = new List<UsuarioListItemModel>();
            foreach (var entity in entityList)
            {
                // converte para a model
                var modelItem = new UsuarioListItemModel
                {
                    Id = entity.Id,
                    Nome = entity.Nome,
                    Status = entity.Status
                };

                // adiciona na lista de models
                modelList.Add(modelItem);
            }

            // adiciona os headers de paginação

            var response = Request.CreateResponse(HttpStatusCode.PartialContent, modelList);

            response.Headers.Add("Total-Count", "150");
            response.Headers.Add("Pagination-Pages", "15");
            response.Headers.Add("Pagination-Offset", "0");
            response.Headers.Add("Pagination-Limit", "10");

            return ResponseMessage(response);
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

            // atribui o Id da entidade criada para a model
            model.Id = entity.Id;

            // retorna resultado
            return Created($"{Request.RequestUri.AbsoluteUri}/{entity.Id}", model);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Put(Guid? id, [FromBody]UsuarioUpdateModel model)
        {
            // valida id
            if (!id.HasValue)
                return BadRequest("Id inválido ou não informado");

            // valida model
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // pega a entidade pelo id
            var entity = await _service.GetById(id.Value);

            // verifica se a entidade existe
            if (entity == null)
                return NotFound();

            // atualiza valores entidade
            entity.Nome = model.Nome;
            entity.Email = model.Email;
            entity.Sobrenome = model.Sobrenome;

            // atualiza a entidade no banco
            await _service.Update(entity);

            // retorna resultado
            return Ok(model);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(Guid? id)
        {
            // valida id
            if (!id.HasValue)
                return BadRequest("Id inválido ou não informado");

            // deleta entidade
            var result = await _service.Delete(id.Value);

            // verifica se foi deletado com sucesso
            if (!result)
                return NotFound();

            // retorna confirmação do delete
            return StatusCode(HttpStatusCode.NoContent);
        }

        // TODO: API Patch Method

        #endregion
    }
}
