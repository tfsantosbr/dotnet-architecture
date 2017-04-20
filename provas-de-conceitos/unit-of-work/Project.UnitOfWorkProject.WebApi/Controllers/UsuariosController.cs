using System.Web.Http;

namespace Project.UnitOfWorkProject.WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new { nome = "Tiago", sobrenome = "Santos" });
        }
    }
}
