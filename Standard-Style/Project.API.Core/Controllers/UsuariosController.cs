using Project.API.Base.Controllers;
using Project.API.Base.Filters;
using Project.API.Base.MapperAdapters;
using Project.API.Core.Models.Usuario;
using Project.Domain.Core.Interfaces;
using Project.Models.Core.Entities;
using System.Threading.Tasks;
using System.Web.Http;

namespace Project.API.Core.Controllers
{
    public class UsuariosController : GenericBaseApiControllerAsync
        <long, IUsuarioDomain, Usuario, UsuarioModel, UsuarioGetModel, UsuarioListItemModel, UsuarioPostModel, UsuarioPutModel>
    {
        #region - CONSTRUCTORS -

        public UsuariosController(IUsuarioDomain domain, IMapperAdapter mapperAdapter)
            : base(domain, mapperAdapter)
        {
        }

        #endregion

        #region - MAIN METHODS -

        [Authorize, NullParametersFilter]
        public override async Task<IHttpActionResult> Get(long id)
        {
            return await base.Get(id);
        }

        #endregion
    }
}