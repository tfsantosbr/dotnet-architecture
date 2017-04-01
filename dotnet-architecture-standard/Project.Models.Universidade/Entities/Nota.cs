using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Universidade.Entities
{
    /// <summary>
    ///     NOTA
    /// </summary>
    public class Nota : EntityBase
    {
        #region - RELATIONSHIPS -

        /// <summary>
        ///     MATRICULA
        /// </summary>
        public Matricula Matricula { get; set; }

        #endregion

        #region - PROPERTIES -

        /// <summary>
        ///     ID
        /// </summary>
        [Key, Column(Order = 0)]
        public Guid Id { get; set; }

        /// <summary>
        ///     CURSO ID
        /// </summary>
        [Key, Column(Order = 1)]
        public Guid CursoId { get; set; }

        /// <summary>
        ///     ESTUDANTE ID
        /// </summary>
        [Key, Column(Order = 2)]
        public Guid EstudanteId { get; set; }

        /// <summary>
        ///     VALOR
        /// </summary>
        [Required, Range(0, 10)]
        public decimal Valor { get; set; }

        #endregion
    }
}