using System.ComponentModel.DataAnnotations;
using Project.API.Base.Models;
using Project.Resources.Core.Messages;

namespace Project.API.Publicacoes.Models.Conteudo
{
    public class ConteudoModel : IdentityModelBase<int>, IIdentityModelBase<int>
    {
        /// <summary>
        ///     TITULO
        /// </summary>
        [Display(Name = "Titulo")]
        [Required(ErrorMessageResourceName = "REQUIRED_FIELD", ErrorMessageResourceType = typeof (VALIDATION_MESSAGES))]
        public virtual object Titulo { get; set; }
    }
}