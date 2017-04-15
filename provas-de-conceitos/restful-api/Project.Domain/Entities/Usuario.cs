using System;

namespace Project.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public UsuarioStatus Status { get; set; }
    }

    public enum UsuarioStatus
    {
        Ativo = 1,
        Inativo = 2
    }
}
