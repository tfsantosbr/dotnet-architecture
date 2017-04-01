using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Universidade.Entities
{
    /// <summary>
    ///     CURSO
    /// </summary>
    public class Curso : IdentityEntityBase<Guid>
    {
        #region - PROPERTIES -

        /// <summary>
        ///     TITULO
        /// </summary>
        [Required, StringLength(30)]
        public string Titulo { get; set; }

        /// <summary>
        ///     PROFESSORID
        /// </summary>
        public long? ProfessorId { get; set; }

        #endregion

        #region - RELATIONSHIPS -

        /// <summary>
        ///     MATRICULAS
        /// </summary>
        public virtual ICollection<Matricula> Matriculas { get; set; }

        /// <summary>
        ///     PROFESSOR
        /// </summary>
        public virtual Professor Professor { get; set; }

        #endregion
    }
}