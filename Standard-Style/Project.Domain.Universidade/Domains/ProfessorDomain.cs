using Project.Domain.Core.Domains.Base;
using Project.Domain.Universidade.Interfaces;
using Project.Models.Universidade.Entities;
using Project.Persistence.Universidade.Interfaces;

namespace Project.Domain.Universidade.Domains
{
    /// <summary>
    ///     PROFESSOR DOMAIN
    /// </summary>

    public class ProfessorDomain : DomainBase<Professor, IProfessorRepository<Professor>>, IProfessorDomain<Professor>
    {
        #region - CONSTRUCTORS -

        public ProfessorDomain(IProfessorRepository<Professor> repository)
            : base(repository)
        {
        }

        public ProfessorDomain(IProfessorRepository<Professor> repository, VisibleRecords visibleRecordses)
            : base(repository, visibleRecordses)
        {
        }

        #endregion
    }
}