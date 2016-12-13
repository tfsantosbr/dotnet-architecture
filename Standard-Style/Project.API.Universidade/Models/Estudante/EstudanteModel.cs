using System.ComponentModel.DataAnnotations;
using Project.API.Base.Models;
using Project.Resources.Core.Messages;

namespace Project.API.Universidade.Models.Estudante
{
    public class EstudanteModel : IdentityModelBase<long>, IIdentityModelBase<long>
    {
        /// <summary>
        ///     NOME
        /// </summary>
        [Display(Name = "Nome")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual object Nome { get; set; }
    }
}