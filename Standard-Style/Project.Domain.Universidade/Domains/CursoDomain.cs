using Project.Domain.Core.Domains.Base;
using Project.Domain.Universidade.Interfaces;
using Project.Models.Universidade.Entities;
using Project.Persistence.Universidade.Interfaces;

namespace Project.Domain.Universidade.Domains
{
    /// <summary>
    ///     CURSO DOMAIN
    /// </summary>

    public class CursoDomain : DomainBase<Curso, ICursoRepository<Curso>>, ICursoDomain<Curso>
    {
        #region - CONSTRUCTORS -

        public CursoDomain(ICursoRepository<Curso> repository)
            : base(repository)
        {
        }

        public CursoDomain(ICursoRepository<Curso> repository, VisibleRecords visibleRecordses)
            : base(repository, visibleRecordses)
        {
        }

        #endregion
    }
}
