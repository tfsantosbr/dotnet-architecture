using System;
using System.Threading.Tasks;
using System.Web.Http;
using Project.API.Base.Controllers;
using Project.API.Base.Filters;
using Project.API.Base.MapperAdapters;
using Project.API.Core.Models.Conta;
using Project.Domain.Core.Interfaces;
using Project.Models.Core.Entities;

namespace Project.API.Core.Controllers
{
    public class ContaController : BaseApiController
        <IAccountDomain<Guid>, Usuario, Guid>
    {
        #region - CONSTRUCTORS -

        public ContaController(IAccountDomain<Guid> domain, IMapperAdapter mapperAdapter)
            : base(domain, mapperAdapter)
        {
        }

        #endregion

        #region - MAIN METHODS -

        // POST: Cadastrar Usuário

        [NullParametersFilter, ModelStateFilter]
        public async Task<IHttpActionResult> Post([FromBody] ContaPostModel viewModel)
        {
            var domainModel = MapperAdapter.Adapt<ContaPostModel, Usuario>(viewModel);

            var identityResult = await Domain.CreateAsync(domainModel, domainModel.Senha);

            if (!identityResult.Succeeded)
                return GetErrorResult(identityResult);

            viewModel.Id = domainModel.Id;

            await Domain.EnviarSolicitacaoAtivacaoConta(domainModel);

            return Created(Request.RequestUri, viewModel);
        }

        // GET: Ativar Conta

        [HttpGet, NullParametersFilter]
        public async Task<IHttpActionResult> Ativar(Guid? id, string token)
        {
            var identityResult = await Domain.ConfirmEmailAsync(id.Value, token);

            if (!identityResult.Succeeded)
                return GetErrorResult(identityResult);

            await Domain.EnviarNotificacaoAtivacaoConta(id.Value);

            return Ok();
        }

        // POST: Solicitar redefinição de senha

        [Route("SolicitarRedefinicaoSenha"), HttpPost, NullParametersFilter, ModelStateFilter]
        public async Task<IHttpActionResult> SolicitarRedefinicaoSenha(
            [FromBody] ContaSolicitarRedefinicaoSenhaModel viewModel)
        {
            await Domain.EnviarSolicitacaoRedefinicaoSenha(viewModel.Email);

            return Ok();
        }

        // POST: Redefinir senha

        [Route("RedefinirSenha"), HttpPost, NullParametersFilter, ModelStateFilter]
        public async Task<IHttpActionResult> RedefinirSenha([FromUri] Guid? id, [FromUri] string token,
            [FromBody] ContaRedefinirSenhaViewModel viewModel)
        {
            var identityResult = await Domain.ResetPasswordAsync(id.Value, token, viewModel.Senha);

            if (!identityResult.Succeeded)
                return GetErrorResult(identityResult);

            await Domain.EnviarNotificacaoRedefinicaoSenha(id.Value);

            return Ok();
        }

        #endregion
    }
}
