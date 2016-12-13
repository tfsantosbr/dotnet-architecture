using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Project.Models.Core.Entities;
using Project.Models.Core.Entities.Base;
using Project.Resources.Core.Messages;

namespace Project.Models.Publicacoes.Entities
{
    public class Conteudo : IdentityEntityBase<int>
    {
        #region - PROPERTIES -

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Corpo { get; set; }

        [Required]
        public long IdAutor { get; set; }

        public long? IdAuditor { get; set; }

        [Required]
        public ConteudoStatus Status { get; set; }

        #endregion

        #region - RELATIONSHIPS -

        [ForeignKey("IdAutor")]
        public Usuario Autor { get; set; }

        [ForeignKey("IdAuditor")]
        public Usuario Auditor { get; set; }

        #endregion
    }

    public enum ConteudoStatus : byte
    {
        [Display(Description = "ACTIVE", ResourceType = typeof (STATUS_RESOURCES))] Active = 0,

        [Display(Description = "INACTIVE", ResourceType = typeof (STATUS_RESOURCES))] Inactive = 1,

        [Display(Description = "APPROVED", ResourceType = typeof (STATUS_RESOURCES))] Approved = 2,

        [Display(Description = "DISAPPROVED", ResourceType = typeof (STATUS_RESOURCES))] Disapproved = 3,

        [Display(Description = "EVALUATION", ResourceType = typeof (STATUS_RESOURCES))] Evaluation = 4
    }
}