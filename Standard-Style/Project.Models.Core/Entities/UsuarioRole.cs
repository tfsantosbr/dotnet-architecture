using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Core.Entities
{
    public class UsuarioRole : EntityBase
    {
        [Key, Column(Order = 0)]
        public long IdUsuario { get; set; }

        [Key, Column(Order = 1)]
        public int IdPerfil { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        [ForeignKey("IdPerfil")]
        public Role Perfil { get; set; }
    }
}