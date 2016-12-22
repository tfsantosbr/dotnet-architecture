using System;

namespace Project.API.Base.Models
{
    public class IdentityModelBase<TKey> : IIdentityModelBase<TKey>
        where TKey : struct, IComparable
    {
        /// <summary>
        ///     ID
        /// </summary>
        public TKey Id { get; set; }
    }
}