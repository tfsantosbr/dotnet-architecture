namespace Project.UnitOfWork.Entities
{
    public class Usuario : Entity<int>
    {
        public string Nome { get; set; }
        public UsuarioStatus Status { get; set; }
    }

    public enum UsuarioStatus
    {
        Ativo = 1,
        Inativo = 2
    }
}
