using System.Collections.Generic;
using Project.Models.Core.Entities.Base;

namespace Project.Models.Universidade.Entities
{
    /// <summary>
    ///     ESTUDANTE
    /// </summary>
    public class Estudante : IdentityEntityBase<long>
    {
        #region - PROPERTIES -

        /// <summary>
        ///     NOME
        /// </summary>
        public string Nome { get; set; }

        #endregion

        #region - RELATIONSHIPS -

        /// <summary>
        ///     MATRICULAS
        /// </summary>
        public virtual ICollection<Matricula> Matriculas { get; set; }

        #endregion
    }
}