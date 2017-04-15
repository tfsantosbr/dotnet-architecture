using Project.Domain.Entities;

namespace Project.RestfulApi.Models.Usuarios
{
    public class UsuarioGetModel : UsuarioBaseModel
    {
        public UsuarioStatus Status { get; set; }
    }
}