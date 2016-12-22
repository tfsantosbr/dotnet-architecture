using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Core.Entities
{
    /// <summary>
    ///     CLIENT
    /// </summary>
    public class Client : EntityBase
    {
        /// <summary>
        ///     CODE
        /// </summary>
        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public String Id { get; set; }

        /// <summary>
        ///     SECRET
        /// </summary>
        [Required]
        public string Secret { get; set; }

        /// <summary>
        ///     NAME
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        ///     APPLICATIONTYPE
        /// </summary>
        public ApplicationTypes ApplicationType { get; set; }

        /// <summary>
        ///     ACTIVE
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        ///     REFRESHTOKENLIFETIME
        /// </summary>
        public int RefreshTokenLifeTime { get; set; }

        /// <summary>
        ///     ALLOWEDORIGIN
        /// </summary>
        [MaxLength(100)]
        public string AllowedOrigin { get; set; }
    }

    public enum ApplicationTypes
    {
        JavaScript = 0,
        NativeConfidential = 1
    }
}