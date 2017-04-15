using System.ComponentModel.DataAnnotations;

namespace Project.RestfulApi.Models.Usuarios
{
    public abstract class UsuarioBaseModel
    {
        [Required]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        [Required]
        public string Email { get; set; }
    }
}