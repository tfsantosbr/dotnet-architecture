namespace Project.Models.Core.Entities.Base
{
    public class IdentityEntityBase<TKey> : EntityBase, IIdentityEntityBase<TKey>
    {
        /// <summary>
        ///     ID
        /// </summary>
        public virtual TKey Id { get; set; }
    }
}