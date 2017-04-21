using System;

namespace Project.UnitOfWorkProjectProject.Entities
{
    public class Entity { }

    public class Entity<TIdentifier> : Entity
        where TIdentifier : IConvertible
    {
        public TIdentifier Id { get; set; }
    }
}