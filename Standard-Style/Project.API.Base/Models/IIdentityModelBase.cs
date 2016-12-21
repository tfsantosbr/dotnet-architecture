using System;

namespace Project.API.Base.Models
{
    public interface IIdentityModelBase<TKey>
        where TKey : IFormattable, IComparable
    {
        TKey Id { get; set; }
    }
}