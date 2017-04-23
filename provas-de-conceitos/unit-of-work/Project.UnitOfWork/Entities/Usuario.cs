using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.UnitOfWorkProject.Entities
{
    public class Usuario : Entity<int>
    {
        [Required]
        public string Nome { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public UsuarioStatus? Status { get; set; }

        public virtual List<Endereco> Enderecos { get; set; }
    }

    public enum UsuarioStatus
    {
        Ativo = 1,
        Inativo = 2
    }
}
