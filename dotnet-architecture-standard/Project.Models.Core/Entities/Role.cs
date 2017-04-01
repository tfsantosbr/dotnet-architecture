using System;
using Microsoft.AspNet.Identity;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Core.Entities
{
    public class Role : IdentityEntityBase<Guid>, IRole<Guid>
    {
        #region - PROPERTIES -

        public string Name { get; set; }

        #endregion

        #region - CONSTRUCTORS -

        public Role()
        {
        }

        public Role(string name)
            : this()
        {
            Name = name;
        }

        public Role(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        #endregion
    }
}