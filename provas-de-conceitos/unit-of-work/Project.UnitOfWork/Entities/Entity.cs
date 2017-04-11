using System;

namespace Project.UnitOfWork.Entities
{
    public class Entity<TIdentifier> where TIdentifier : IConvertible
    {
        public TIdentifier Id { get; set; }
    }
}