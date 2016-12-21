using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Project.Models.Core.Entities.Base
{
    public class IdentityEntityBase<TKey> : EntityBase, IIdentityEntityBase<TKey>
        where TKey : IFormattable, IComparable
    {
        /// <summary>
        ///     ID
        /// </summary>

        [BsonId]
        public virtual TKey Id { get; set; }
    }
}