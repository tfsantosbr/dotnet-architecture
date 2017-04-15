using System;

namespace Project.RestfulApi.Models.Usuarios
{
    public class UsuarioCreateModel : UsuarioBaseModel
    {
        public Guid Id { get; internal set; }
    }
}