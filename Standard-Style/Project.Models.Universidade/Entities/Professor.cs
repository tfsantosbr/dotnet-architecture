using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Project.Models.Core.Entities;

namespace Project.Models.Universidade.Entities
{
    /// <summary>
    ///     PROFESSOR
    /// </summary>
    public class Professor : Usuario
    {
        #region - PROPERTIES -

        /// <summary>
        ///     SALARIO
        /// </summary>
        [Required]
        public decimal Salario { get; set; }

        #endregion

        #region - RELATIONSHIPS -

        /// <summary>
        ///     CURSOS
        /// </summary>
        public virtual ICollection<Curso> Cursos { get; set; }

        #endregion
    }
}