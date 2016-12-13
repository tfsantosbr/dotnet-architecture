using Project.Domain.Core.Base;
using Project.Models.Universidade.Entities;
using Project.Persistence.Universidade.Repositories;

namespace Project.Domain.Universidade
{
    /// <summary>
    ///     ESTUDANTE DOMAIN
    /// </summary>
    public class EstudanteDomain : DomainBase<Estudante, EstudanteRepository>
    {
        #region - CONSTRUCTORS -

        public EstudanteDomain()
        {
        }

        public EstudanteDomain(VisibleRecord visibleRecords)
            : base(visibleRecords)
        {
        }

        #endregion
    }
}