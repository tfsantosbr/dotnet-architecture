using System;

namespace Project.Models.Core.Entities.Base
{
    /// <summary>
    ///     ENTITY BASE INTERFACE
    /// </summary>
    public interface IEntityBase
    {
        /// <summary>
        ///     CREATION DATE
        /// </summary>
        DateTime CreationDate { get; set; }

        /// <summary>
        ///     MODIFICATION DATE
        /// </summary>
        DateTime ModificationDate { get; set; }

        /// <summary>
        ///     EXCLUSION DATE
        /// </summary>
        DateTime? ExclusionDate { get; set; }
    }
}