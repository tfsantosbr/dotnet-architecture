using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Core.Entities
{
    public class RefreshToken : IdentityEntityBase<string>
    {
        /// <summary>
        ///     ID
        /// </summary>
        [Key, Column(Order = 0)]
        public override string Id { get; set; }

        /// <summary>
        ///     BROWSER
        /// </summary>
        [Key, Column(Order = 1)]
        [MaxLength(50)]
        public string Browser { get; set; }

        /// <summary>
        ///     SUBJECT
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        /// <summary>
        ///     CLIENTID
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }


        /// <summary>
        ///     ISSUEDUTC
        /// </summary>
        public DateTime IssuedUtc { get; set; }

        /// <summary>
        ///     EXPIRESUTC
        /// </summary>
        public DateTime ExpiresUtc { get; set; }

        /// <summary>
        ///     PROTECTEDTICKET
        /// </summary>
        [Required]
        public byte[] ProtectedTicket { get; set; }
    }
}