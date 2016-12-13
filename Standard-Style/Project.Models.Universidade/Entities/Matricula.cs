using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Universidade.Entities
{
    /// <summary>
    ///     MATRICULA
    /// </summary>
    public class Matricula : EntityBase
    {
        #region - PROPERTIES -

        /// <summary>
        ///     CURSO ID
        /// </summary>
        [Key, Column(Order = 0)]
        public short CursoId { get; set; }

        /// <summary>
        ///     ESTUDANTE ID
        /// </summary>
        [Key, Column(Order = 1)]
        public long EstudanteId { get; set; }

        #endregion

        #region - RELATIONSHIPS -

        /// <summary>
        ///     ESTUDANTE
        /// </summary>
        public Estudante Estudante { get; set; }

        /// <summary>
        ///     CURSO
        /// </summary>
        public Curso Curso { get; set; }

        /// <summary>
        ///     NOTAS
        /// </summary>
        public List<Nota> Notas { get; set; }

        #endregion
    }
}