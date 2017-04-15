using Project.Domain.Entities;
using System;

namespace Project.RestfulApi.Models.Usuarios
{
    public class UsuarioListItemModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public UsuarioStatus Status { get; set; }
    }
}