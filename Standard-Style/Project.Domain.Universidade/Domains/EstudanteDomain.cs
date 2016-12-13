using Project.Domain.Core.Domains.Base;
using Project.Domain.Universidade.Interfaces;
using Project.Models.Universidade.Entities;
using Project.Persistence.Universidade.Interfaces;

namespace Project.Domain.Universidade.Domains
{
    /// <summary>
    ///     ESTUDANTE DOMAIN
    /// </summary>

    public class EstudanteDomain : DomainBase<Estudante, IEstudanteRepository>, IEstudanteDomain
    {
        #region - CONSTRUCTORS -

        public EstudanteDomain(IEstudanteRepository repository)
            : base(repository)
        {
        }

        #endregion
    }
}