using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Core.Entities
{
    public class UsuarioClaim : IdentityEntityBase<int>
    {
        public long IdUsuario { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}