using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Core.Entities
{
    public class UsuarioRole : EntityBase
    {
        [Key, Column(Order = 0)]
        public Guid IdUsuario { get; set; }

        [Key, Column(Order = 1)]
        public Guid IdPerfil { get; set; }
    }
}