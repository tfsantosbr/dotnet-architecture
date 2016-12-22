using System;

namespace Project.API.Base.Models
{
    public interface IIdentityModelBase<TKey>
        where TKey : struct, IComparable
    {
        TKey Id { get; set; }
    }
}