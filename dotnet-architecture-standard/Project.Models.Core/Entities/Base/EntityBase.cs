using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Models.Core.Entities.Base
{
    /// <summary>
    ///     ENTITY BASE ABSTRACT CLASS
    /// </summary>
    public abstract class EntityBase : IEntityBase, IRowVersion
    {
        /// <summary>
        ///     CREATION DATE
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        ///     MODIFICATION DATE
        /// </summary>
        public DateTime ModificationDate { get; set; }

        /// <summary>
        ///     EXCLUSION DATE
        /// </summary>
        public DateTime? ExclusionDate { get; set; }

        /// <summary>
        ///     ROW VERSION FOR DBCONCURRENCY
        /// </summary>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}