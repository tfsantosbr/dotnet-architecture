using Microsoft.AspNet.Identity;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Core.Entities
{
    /// <summary>
    ///     USER DOMAIN MODEL
    /// </summary>
    public class Usuario : IdentityEntityBase<long>, IUser<long>
    {
        #region - PROPERTIES -

        /// <summary>
        ///     USERNAME
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        ///     EMAIL
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     EMAIL CONFIRMED
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        ///     SENHA HASH
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        ///     SECURITY STAMP
        /// </summary>
        public string SecurityStamp { get; set; }

        #endregion
    }
}