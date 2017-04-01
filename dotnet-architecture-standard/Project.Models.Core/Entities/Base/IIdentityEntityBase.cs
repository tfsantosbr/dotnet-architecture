namespace Project.Models.Core.Entities.Base
{
    internal interface IIdentityEntityBase<TKey>
    {
        TKey Id { get; set; }
    }
}