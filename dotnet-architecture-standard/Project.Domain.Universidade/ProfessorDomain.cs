using Project.Domain.Core.Base;
using Project.Models.Universidade.Entities;
using Project.Persistence.Universidade.Repositories;

namespace Project.Domain.Universidade
{
    /// <summary>
    ///     Professor DOMAIN
    /// </summary>
    public class ProfessorDomain : DomainBase<Professor, ProfessorRepository>
    {
        #region - CONSTRUCTORS -

        public ProfessorDomain()
        {
        }

        public ProfessorDomain(VisibleRecord visibleRecords)
            : base(visibleRecords)
        {
        }

        #endregion
    }
}