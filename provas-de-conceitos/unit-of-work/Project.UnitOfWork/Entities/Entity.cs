namespace Project.UnitOfWork.Entities
{
    public class Entity<TIdentity> // TODO: Adicionar constrains para o tipo de Id
    {
        public TIdentity Id { get; set; }
    }
}