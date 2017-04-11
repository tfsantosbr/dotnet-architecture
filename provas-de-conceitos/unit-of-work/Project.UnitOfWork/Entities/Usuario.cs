namespace Project.UnitOfWork.Entities
{
    public class Usuario
    {
        public int Id { get; set; } // TODO: Mover para base entity
        public string Nome { get; set; }
        public UsuarioStatus Status { get; set; }
    }

    public enum UsuarioStatus
    {
        Ativo = 1,
        Inativo = 2
    }
}
