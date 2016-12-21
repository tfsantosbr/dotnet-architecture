using System;

namespace Project.API.Base.Models
{
    public interface IIdentityModelBase<TKey>
        where TKey : IComparable
    {
        TKey Id { get; set; }
    }
}