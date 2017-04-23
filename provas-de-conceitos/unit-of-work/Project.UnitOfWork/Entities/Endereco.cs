using System.ComponentModel.DataAnnotations;

namespace Project.UnitOfWorkProject.Entities
{
    public class Endereco : Entity<int>
    {
        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Bairro { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
