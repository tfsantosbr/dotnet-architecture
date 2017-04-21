using Project.UnitOfWorkProject.Entities;
using Project.UnitOfWorkProject.Services;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.UnitOfWorkProject.WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
        private readonly IUsuarioService service;

        public UsuariosController(IUsuarioService service)
        {
            this.service = service;
        }

        public async Task<IHttpActionResult> Post(Usuario usuario)
        {
            var result = await service.AddAsync(usuario);
            return Ok(result);
        }
    }
}
